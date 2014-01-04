using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace BytecodeRunner
{
        
    class RunnerError : System.Exception
    {
        public ErrorCode e;

        public RunnerError(ErrorCode e)
            : base(getRunnerError(e))
        {
            this.e = e;
        }

        static string getRunnerError(ErrorCode e)
        {
            string str = "Error " + Convert.ChangeType(e, e.GetTypeCode()).ToString() + ": ";
            switch (e)
            {
                case ErrorCode.MISSING_ARGS:
                    str += "Missing Args";
                    break;
                case ErrorCode.FILE_NOT_FOUND:
                    str += "File not found";
                    break;
                case ErrorCode.BAD_OPERATOR:
                    str += "Bad operator";
                    break;
                case ErrorCode.DESTINATION_NOT_SET:
                    str += "Destination not set";
                    break;
                case ErrorCode.BAD_VAR_TYPE:
                    str += "Bad var type";
                    break;
                case ErrorCode.BROKEN_PROGRAM:
                    str += "Broken program";
                    break;
                case ErrorCode.BINARY_NOT_LOAD:
                    str += "Binary not load";
                    break;
                case ErrorCode.BINARY_NOT_PARSED:
                    str += "Binary not parsed";
                    break;
                case ErrorCode.VAR_NOT_SELECTED:
                    str += "Var not selected";
                    break;
                case ErrorCode.VAR_CAST_ERROR:
                    str += "Var cast error";
                    break;
                case ErrorCode.DUPLICATED_FUNCTION_IDENTIFIER:
                    str += "Duplicated Function identifier";
                    break;
                case ErrorCode.MISSING_FUNCTION_IDENTIFIER:
                    str += "Missing Function identifier";
                    break;
                default:
                    str += "Error type not mapped";
                    break;
            }
            return str;
        }
    }

    enum ErrorCode
    {
        MISSING_ARGS,
        FILE_NOT_FOUND,
        BAD_OPERATOR,
        DESTINATION_NOT_SET,
        BAD_VAR_TYPE,
        BROKEN_PROGRAM,
        BINARY_NOT_LOAD,
        BINARY_NOT_PARSED,
        VAR_NOT_SELECTED,
        VAR_CAST_ERROR,
        VAR_TYPE_ERROR,
        DUPLICATED_FUNCTION_IDENTIFIER,
        MISSING_FUNCTION_IDENTIFIER
    }

    enum ProgramOperator
    {
        SET,//  0   SELECT OR CREATE DESTINATION                        - INDEX
        ADD,//  1   SUM DESTINATION VALUE WITH PARAMETER                - TYPE - PAR
        REM,//  2   SUBTRACT DESTINATION VALUE WITH PARAMETER           - TYPE - PAR
        MUL,//  3   MULTIPLY DESTINATION VALUE WITH PARAMETER    		- TYPE - PAR
        DIV,//  4   DIVIDE DESTINATION VALUE WITH PARAMETER             - TYPE - PAR
        MOV,//  5   MOVE PARAMETER TO DESTINATION SELECTED              - TYPE - PAR
        PRT,//  6   PRINT DESTINATION VALUE                             - INDEX
        SSP,//  7   START SCOPE IDENTIFIER                              - ID
        ESP,//  8   END SCOPE IDENTIFIER                                - ID
        LCH,//  9   LAUNCH SCOPE IDENTIFIER                             - ID
        GET //  10  READ FROM STDIN AND PUT VAR IN DESTINATION          - ID
    }

    class Instruction
    {
        private ProgramOperator _op;
        private var _var;
        public ProgramOperator op
        {
            get { return _op; }
        }
        public var var
        {
            get { return _var; }
        }
        public Instruction(ProgramOperator op, var var)
        {
            _op = op;
            _var = var;
        }
    }

    class Function
    {
        private int _start; // INSTRUCTION START POS
        private int _end;   // INSTRUCTION END POS
        public int start
        {
            get { return _start; }
        }
        public int end
        {
            get { return _end; }
            set { _end = value; }
        }
        public Function(int start)
        {
            _start = start;
        }
    }

    class Runner
    {
        private int _cursorByte;
        private int _cursor;
        private string _pathBinary;
        private byte[] _binary;
        private bool _loaded;
        private bool _parsed;
        private Dictionary<int, var> _vars;
        private Dictionary<int, Function> _functions;
        private List<Instruction> _instructions;
        private Stack<int> _callStack;

        private byte _current;              // Byte corrente
        private var _lastVar;               // Current var
        private int _container;             // indice var contenitore
        private int _selected;              // indice variabile selezionata
        private ProgramOperator _op;        // Operatore corrente
        public bool loaded
        {
            get { return this._loaded; }
        }
        public Runner(string[] args)
        {
            if (args.Length > 0)
            {
                _pathBinary = args[0];
                _loaded = false;
                _parsed = false;
            }
            else
            {
                throw new RunnerError(ErrorCode.FILE_NOT_FOUND);
            }
        }
        public void load()
        {
            if (System.IO.File.Exists(_pathBinary))
            {
                _binary = File.ReadAllBytes(_pathBinary);
                _loaded = true;
            }
            else
            {
                throw new RunnerError(ErrorCode.FILE_NOT_FOUND);
            }
        }

        public void parse()
        {
            if (_loaded)
            {
                _vars = new Dictionary<int, var>();                 //VARIABLES CONTAINER
                _callStack = new Stack<int>();                      //FUNCTIONS CALL STACK CONTAINER
                _instructions = new List<Instruction>();            //INSTRUCTIONS CONTAINER
                _functions = new Dictionary<int, Function>();       //FUNCTIONS LIST
                _cursorByte = -1;
                _cursor = -1;

                int instructionCounter = 0;

                while (hasNext())
                {
                    if (Enum.IsDefined(typeof(ProgramOperator), getNext()))
                    {
                        _op = (ProgramOperator)getCurrent();
                        _instructions.Add(
                            new Instruction(_op, extractVar())
                        );

                        if (_op == ProgramOperator.SSP)
                        {
                            if (_functions.ContainsKey(instructionCounter))
                            {
                                throw new RunnerError(ErrorCode.DUPLICATED_FUNCTION_IDENTIFIER);
                            }
                            _functions[getIndex(_lastVar)] = new Function(instructionCounter);
                        }
                        if (_op == ProgramOperator.ESP)
                        {
                            if (!_functions.ContainsKey(getIndex(_lastVar)))
                            {
                                throw new RunnerError(ErrorCode.MISSING_FUNCTION_IDENTIFIER);
                            }
                            _functions[getIndex(_lastVar)].end = instructionCounter;
                        }
                    }
                    else
                    {
                        throw new RunnerError(ErrorCode.BAD_OPERATOR);
                    }
                    instructionCounter++;
                }

                _parsed = true;
            }
            else
            {
                throw new RunnerError(ErrorCode.BINARY_NOT_LOAD);
            }
        }

        public void run()
        {
            if (_parsed)
            {
                Instruction inst;


                for(int i = 0; i < _instructions.Count; i++)
                {
                    inst = _instructions[i];

                    switch (inst.op)
                    {
                        case ProgramOperator.SET:
                            _container = getIndex(inst.var);
                            break;
                        case ProgramOperator.ADD:
                            _vars[_container] = _vars[_container] + getValue(inst.var);
                            break;
                        case ProgramOperator.REM:
                            _vars[_container] = _vars[_container] - getValue(inst.var);
                            break;
                        case ProgramOperator.MUL:
                            _vars[_container] = _vars[_container] * getValue(inst.var);
                            break;
                        case ProgramOperator.DIV:
                            _vars[_container] = _vars[_container] / getValue(inst.var);
                            break;
                        case ProgramOperator.MOV:
                            _vars[_container] = getValue(inst.var);
                            break;
                        case ProgramOperator.PRT:
                            Console.Write(getValue(inst.var));
                            break;
                        case ProgramOperator.SSP:
                            i = _functions[getIndex(inst.var)].end;
                            break;
                        case ProgramOperator.ESP:
                            i = _callStack.Pop();
                            break;
                        case ProgramOperator.LCH:
                            _callStack.Push(i);
                            i = getIndex(inst.var) - 1;
                            break;
                    }
                }

               
            }
            else
            {
                throw new RunnerError(ErrorCode.BINARY_NOT_PARSED);
            }
        }

        private int getIndex(var v)
        {
            if (!v.isIndex())
            {
                throw new RunnerError(ErrorCode.VAR_TYPE_ERROR);
            }
            return v.getIndex();
        }
        private var getValue(var v)
        {
            if (v.isIndex())
            {
                return _vars[v.getIndex()];
            }
            return v;
        }

        private bool readNext()
        {
            if (hasNext())
                _current = _binary[++_cursorByte];
            else
                return false;
            return true;
        }
        private bool hasNext()
        {
            return (_cursorByte < _binary.Length - 1);
        }
        private int getNext()
        {
            if (!readNext())
                throw new RunnerError(ErrorCode.BROKEN_PROGRAM);
            return getCurrent();
        }
        private int getCurrent()
        {
            return _current;
        }

        private var extractVar()
        {
            var ris = new var();
            VarType t1 = (VarType)getNext();
            int bytesCounter = 0;
            int bytesLen = var.getSize(t1);
            Byte[] data = new Byte[bytesLen];
            while (bytesCounter < bytesLen)
            {
                data[bytesCounter] = (Byte)getNext();
                bytesCounter++;
            }
            ris.parse(t1, data);
            _lastVar = ris;
            return ris;
        }
    }
}
