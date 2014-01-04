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
                case ErrorCode.VAR_NOT_SELECTED:
                    str += "Var not selected";
                    break;
                case ErrorCode.VAR_CAST_ERROR:
                    str += "Var cast error";
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
        VAR_NOT_SELECTED,
        VAR_CAST_ERROR
    }

    enum ProgramOperator
    {
        SET,//  0   SELEZIONA O CREA DESTINAZIONE                               - INDICE
        ADD,//  1   ESEGUE SOMMA E LA INSERISCE NELLA DESTINAZIONE              - TYPE - PAR1
        REM,//  2   ESEGUE SOTTRAZIONE E LA INSERISCE NELLA DESTINAZIONE        - TYPE - PAR1
        MUL,//  3   ESEGUE MOLTIPLICAZIONE E LA INSERISCE NELLA DESTINAZIONE    - TYPE - PAR1
        DIV,//  4   ESEGUE DIVISIONE E LA INSERISCE NELLA DESTINAZIONE          - TYPE - PAR1
        MOV,//  5   INSERISCE UNA VARIABILE NELLA DESTINAZIONE                  - TYPE - PAR1
        PRT,//  6   STAMPA DESTINAZIONE                                         - INDICE
        SFC,//  7   START FUNCTION IDENTIFIER                                   - ID
        EFC //  7   END FUNCTION IDENTIFIER                                     - ID
    }

    class Instruction
    {
        private ProgramOperator _op;
        public Instruction(ProgramOperator op)
        {
            _op = op;
        }
    }

    class Runner
    {
        private long _cursor;
        private string _pathBinary;
        private byte[] _binary;
        private bool _loaded;
        private Dictionary<int, var> _vars;

        //private Dictionary<int, 

        private byte _current;              // Byte corrente
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
        private bool readNext()
        {
            if (hasNext())
                _current = _binary[++_cursor];
            else
                return false;
            return true;
        }
        private bool hasNext()
        {
            return (_cursor < _binary.Length - 1);
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
            if (t1 == VarType.INDEX)
            {
                return _vars[data[0]];
            }

            ris.parse(t1, data);
            return ris;
        }


        public void run()
        {
            if (_loaded)
            {
                _vars = new Dictionary<int, var>();
                _cursor = -1;
                _container = -1;

                while (hasNext())
                {
                    _op = (ProgramOperator)getNext();

                    switch (_op)
                    {
                        case ProgramOperator.SET:
                            _container = getNext();
                            if (!_vars.ContainsKey(_container))
                            {
                                _vars.Add(_container, 0);
                            }
                            break;
                        case ProgramOperator.ADD:
                        {
                            _vars[_container] = _vars[_container] + extractVar();
                            break;
                        }
                        case ProgramOperator.REM:
                        _vars[_container] = _vars[_container] - extractVar();
                            break;
                        case ProgramOperator.MUL:
                            _vars[_container] = _vars[_container] * extractVar();
                            break;
                        case ProgramOperator.DIV:
                            _vars[_container] = _vars[_container] / extractVar();
                            break;
                        case ProgramOperator.MOV:
                            _vars[_container] = extractVar();
                            break;
                        case ProgramOperator.PRT:
                            _selected = getNext();
                            if (_vars.ContainsKey(_selected))
                            {
                                Console.WriteLine(_vars[_selected]);
                            }
                            else
                            {
                                throw new RunnerError(ErrorCode.VAR_NOT_SELECTED);
                            }
                            break;
                        default:
                            throw new RunnerError(ErrorCode.BAD_OPERATOR);
                    }
                }
            }
            else
            {
                throw new RunnerError(ErrorCode.BINARY_NOT_LOAD);
            }
        }
    }
}
