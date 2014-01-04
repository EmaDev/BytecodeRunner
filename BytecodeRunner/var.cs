using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BytecodeRunner
{
    enum VarType
    {               //INDEX BYTES
        UNDEFINED,  // 0     0
        BYTE,       // 1     1
        UBYTE,      // 2     1
        SHORT,      // 3     2
        USHORT,     // 4     2
        INT,        // 5     4
        UINT,       // 6     4
        LONG,       // 7     8
        FLOAT,      // 8     4
        DOUBLE,     // 9     8
        INDEX = 255 // 255      
    }


    class var
    {
        private VarType _type;
        private Object _obj;
        public var()
        {
            _type = VarType.UNDEFINED;
            _obj = null;
        }
        public var(Byte o)
        {
            _type = VarType.BYTE;
            _obj = o;
        }
        public var(SByte o)
        {
            _type = VarType.UBYTE;
            _obj = o;
        }
        public var(short o)
        {
            _type = VarType.SHORT;
            _obj = o;
        }
        public var(ushort o)
        {
            _type = VarType.USHORT;
            _obj = o;
        }
        public var(int o)
        {
            _type = VarType.INT;
            _obj = o;
        }
        public var(uint o)
        {
            _type = VarType.UINT;
            _obj = o;
        }
        public var(long o)
        {
            _type = VarType.LONG;
            _obj = o;
        }
        public var(float o)
        {
            _type = VarType.FLOAT;
            _obj = o;
        }
        public var(double o)
        {
            _type = VarType.DOUBLE;
            _obj = o;
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }
            var p = obj as var;
            if ((object)p == null)
            {
                return false;
            }
            return (_type == p._type) && (_obj == p._obj);

        }

        public override int GetHashCode()
        {
            return (int)_obj;
        }

        public static implicit operator string(var v)
        {
            string ris = "";
            switch (v._type)
            {
                case VarType.BYTE:
                    ris = ((byte)v._obj).ToString();
                    break;
                case VarType.UBYTE:
                    ris = ((sbyte)v._obj).ToString();
                    break;
                case VarType.SHORT:
                    ris = ((short)v._obj).ToString();
                    break;
                case VarType.USHORT:
                    ris = ((ushort)v._obj).ToString();
                    break;
                case VarType.INT:
                    ris = ((int)v._obj).ToString();
                    break;
                case VarType.UINT:
                    ris = ((uint)v._obj).ToString();
                    break;
                case VarType.LONG:
                    ris = ((long)v._obj).ToString();
                    break;
                case VarType.FLOAT:
                    ris = ((float)v._obj).ToString();
                    break;
                case VarType.DOUBLE:
                    ris = ((double)v._obj).ToString();
                    break;
            }
            return ris;
        }

        public static implicit operator var(Byte n)
        {
            return new var(n);
        }
        public static implicit operator var(SByte n)
        {
            return new var(n);
        }
        public static implicit operator var(short n)
        {
            return new var(n);
        }
        public static implicit operator var(ushort n)
        {
            return new var(n);
        }
        public static implicit operator var(int n)
        {
            return new var(n);
        }
        public static implicit operator var(uint n)
        {
            return new var(n);
        }
        public static implicit operator var(long n)
        {
            return new var(n);
        }
        public static implicit operator var(float n)
        {
            return new var(n);
        }
        public static implicit operator var(double n)
        {
            return new var(n);
        }

        public bool isByte()
        {
            return _type == VarType.BYTE;
        }

        public byte getByte()
        {
            if (!isByte())
                throw new RunnerError(ErrorCode.VAR_CAST_ERROR);
            return (byte)_obj;
        }
        

        public static bool operator ==(var a, var b)
        {
            if (System.Object.ReferenceEquals(a, b))
            {
                return true;
            }
            if (((object)a == null) || ((object)b == null))
            {
                return false;
            }
            return a._type == b._type && a._obj == b._obj;
        }

        public static bool operator !=(var a, var b)
        {
            return !(a == b);
        }

        public static var operator +(var v1, var v2)
        {
            switch (v1._type)
            {
                case VarType.BYTE:
                    switch (v2._type)
                    {
                        case VarType.BYTE:
                            return new var((byte)v1._obj + (byte)v2._obj);
                        case VarType.UBYTE:
                            return new var((byte)v1._obj + (sbyte)v2._obj);
                        case VarType.SHORT:
                            return new var((byte)v1._obj + (short)v2._obj);
                        case VarType.USHORT:
                            return new var((byte)v1._obj + (ushort)v2._obj);
                        case VarType.INT:
                            return new var((byte)v1._obj + (int)v2._obj);
                        case VarType.UINT:
                            return new var((byte)v1._obj + (uint)v2._obj);
                        case VarType.LONG:
                            return new var((byte)v1._obj + (long)v2._obj);
                        case VarType.FLOAT:
                            return new var((byte)v1._obj + (float)v2._obj);
                        case VarType.DOUBLE:
                            return new var((byte)v1._obj + (double)v2._obj);
                    }
                    break;
                case VarType.UBYTE:
                    switch (v2._type)
                    {
                        case VarType.BYTE:
                            return new var((sbyte)v1._obj + (byte)v2._obj);
                        case VarType.UBYTE:
                            return new var((sbyte)v1._obj + (sbyte)v2._obj);
                        case VarType.SHORT:
                            return new var((sbyte)v1._obj + (short)v2._obj);
                        case VarType.USHORT:
                            return new var((sbyte)v1._obj + (ushort)v2._obj);
                        case VarType.INT:
                            return new var((sbyte)v1._obj + (int)v2._obj);
                        case VarType.UINT:
                            return new var((sbyte)v1._obj + (uint)v2._obj);
                        case VarType.LONG:
                            return new var((sbyte)v1._obj + (long)v2._obj);
                        case VarType.FLOAT:
                            return new var((sbyte)v1._obj + (float)v2._obj);
                        case VarType.DOUBLE:
                            return new var((sbyte)v1._obj + (double)v2._obj);
                    }
                    break;
                case VarType.SHORT:
                    switch (v2._type)
                    {
                        case VarType.BYTE:
                            return new var((short)v1._obj + (byte)v2._obj);
                        case VarType.UBYTE:
                            return new var((short)v1._obj + (sbyte)v2._obj);
                        case VarType.SHORT:
                            return new var((short)v1._obj + (short)v2._obj);
                        case VarType.USHORT:
                            return new var((short)v1._obj + (ushort)v2._obj);
                        case VarType.INT:
                            return new var((short)v1._obj + (int)v2._obj);
                        case VarType.UINT:
                            return new var((short)v1._obj + (uint)v2._obj);
                        case VarType.LONG:
                            return new var((short)v1._obj + (long)v2._obj);
                        case VarType.FLOAT:
                            return new var((short)v1._obj + (float)v2._obj);
                        case VarType.DOUBLE:
                            return new var((short)v1._obj + (double)v2._obj);
                    }
                    break;
                case VarType.USHORT:
                    switch (v2._type)
                    {
                        case VarType.BYTE:
                            return new var((ushort)v1._obj + (byte)v2._obj);
                        case VarType.UBYTE:
                            return new var((ushort)v1._obj + (sbyte)v2._obj);
                        case VarType.SHORT:
                            return new var((ushort)v1._obj + (short)v2._obj);
                        case VarType.USHORT:
                            return new var((ushort)v1._obj + (ushort)v2._obj);
                        case VarType.INT:
                            return new var((ushort)v1._obj + (int)v2._obj);
                        case VarType.UINT:
                            return new var((ushort)v1._obj + (uint)v2._obj);
                        case VarType.LONG:
                            return new var((ushort)v1._obj + (long)v2._obj);
                        case VarType.FLOAT:
                            return new var((ushort)v1._obj + (float)v2._obj);
                        case VarType.DOUBLE:
                            return new var((ushort)v1._obj + (double)v2._obj);
                    }
                    break;
                case VarType.INT:
                    switch (v2._type)
                    {
                        case VarType.BYTE:
                            return new var((int)v1._obj + (byte)v2._obj);
                        case VarType.UBYTE:
                            return new var((int)v1._obj + (sbyte)v2._obj);
                        case VarType.SHORT:
                            return new var((int)v1._obj + (short)v2._obj);
                        case VarType.USHORT:
                            return new var((int)v1._obj + (ushort)v2._obj);
                        case VarType.INT:
                            return new var((int)v1._obj + (int)v2._obj);
                        case VarType.UINT:
                            return new var((int)v1._obj + (uint)v2._obj);
                        case VarType.LONG:
                            return new var((int)v1._obj + (long)v2._obj);
                        case VarType.FLOAT:
                            return new var((int)v1._obj + (float)v2._obj);
                        case VarType.DOUBLE:
                            return new var((int)v1._obj + (double)v2._obj);
                    }
                    break;
                case VarType.UINT:
                    switch (v2._type)
                    {
                        case VarType.BYTE:
                            return new var((uint)v1._obj + (byte)v2._obj);
                        case VarType.UBYTE:
                            return new var((uint)v1._obj + (sbyte)v2._obj);
                        case VarType.SHORT:
                            return new var((uint)v1._obj + (short)v2._obj);
                        case VarType.USHORT:
                            return new var((uint)v1._obj + (ushort)v2._obj);
                        case VarType.INT:
                            return new var((uint)v1._obj + (int)v2._obj);
                        case VarType.UINT:
                            return new var((uint)v1._obj + (uint)v2._obj);
                        case VarType.LONG:
                            return new var((uint)v1._obj + (long)v2._obj);
                        case VarType.FLOAT:
                            return new var((uint)v1._obj + (float)v2._obj);
                        case VarType.DOUBLE:
                            return new var((uint)v1._obj + (double)v2._obj);
                    }
                    break;
                case VarType.LONG:
                    switch (v2._type)
                    {
                        case VarType.BYTE:
                            return new var((long)v1._obj + (byte)v2._obj);
                        case VarType.UBYTE:
                            return new var((long)v1._obj + (sbyte)v2._obj);
                        case VarType.SHORT:
                            return new var((long)v1._obj + (short)v2._obj);
                        case VarType.USHORT:
                            return new var((long)v1._obj + (ushort)v2._obj);
                        case VarType.INT:
                            return new var((long)v1._obj + (int)v2._obj);
                        case VarType.UINT:
                            return new var((long)v1._obj + (uint)v2._obj);
                        case VarType.LONG:
                            return new var((long)v1._obj + (long)v2._obj);
                        case VarType.FLOAT:
                            return new var((long)v1._obj + (float)v2._obj);
                        case VarType.DOUBLE:
                            return new var((long)v1._obj + (double)v2._obj);
                    }
                    break;
                case VarType.FLOAT:
                    switch (v2._type)
                    {
                        case VarType.BYTE:
                            return new var((float)v1._obj + (byte)v2._obj);
                        case VarType.UBYTE:
                            return new var((float)v1._obj + (sbyte)v2._obj);
                        case VarType.SHORT:
                            return new var((float)v1._obj + (short)v2._obj);
                        case VarType.USHORT:
                            return new var((float)v1._obj + (ushort)v2._obj);
                        case VarType.INT:
                            return new var((float)v1._obj + (int)v2._obj);
                        case VarType.UINT:
                            return new var((float)v1._obj + (uint)v2._obj);
                        case VarType.LONG:
                            return new var((float)v1._obj + (long)v2._obj);
                        case VarType.FLOAT:
                            return new var((float)v1._obj + (float)v2._obj);
                        case VarType.DOUBLE:
                            return new var((float)v1._obj + (double)v2._obj);
                    }
                    break;
                case VarType.DOUBLE:
                    switch (v2._type)
                    {
                        case VarType.BYTE:
                            return new var((double)v1._obj + (byte)v2._obj);
                        case VarType.UBYTE:
                            return new var((double)v1._obj + (sbyte)v2._obj);
                        case VarType.SHORT:
                            return new var((double)v1._obj + (short)v2._obj);
                        case VarType.USHORT:
                            return new var((double)v1._obj + (ushort)v2._obj);
                        case VarType.INT:
                            return new var((double)v1._obj + (int)v2._obj);
                        case VarType.UINT:
                            return new var((double)v1._obj + (uint)v2._obj);
                        case VarType.LONG:
                            return new var((double)v1._obj + (long)v2._obj);
                        case VarType.FLOAT:
                            return new var((double)v1._obj + (float)v2._obj);
                        case VarType.DOUBLE:
                            return new var((double)v1._obj + (double)v2._obj);
                    }
                    break;
            }
            return new var();
        }

        public static var operator -(var v1, var v2)
        {
            switch (v1._type)
            {
                case VarType.BYTE:
                    switch (v2._type)
                    {
                        case VarType.BYTE:
                            return new var((byte)v1._obj - (byte)v2._obj);
                        case VarType.UBYTE:
                            return new var((byte)v1._obj - (sbyte)v2._obj);
                        case VarType.SHORT:
                            return new var((byte)v1._obj - (short)v2._obj);
                        case VarType.USHORT:
                            return new var((byte)v1._obj - (ushort)v2._obj);
                        case VarType.INT:
                            return new var((byte)v1._obj - (int)v2._obj);
                        case VarType.UINT:
                            return new var((byte)v1._obj - (uint)v2._obj);
                        case VarType.LONG:
                            return new var((byte)v1._obj - (long)v2._obj);
                        case VarType.FLOAT:
                            return new var((byte)v1._obj - (float)v2._obj);
                        case VarType.DOUBLE:
                            return new var((byte)v1._obj - (double)v2._obj);
                    }
                    break;
                case VarType.UBYTE:
                    switch (v2._type)
                    {
                        case VarType.BYTE:
                            return new var((sbyte)v1._obj - (byte)v2._obj);
                        case VarType.UBYTE:
                            return new var((sbyte)v1._obj - (sbyte)v2._obj);
                        case VarType.SHORT:
                            return new var((sbyte)v1._obj - (short)v2._obj);
                        case VarType.USHORT:
                            return new var((sbyte)v1._obj - (ushort)v2._obj);
                        case VarType.INT:
                            return new var((sbyte)v1._obj - (int)v2._obj);
                        case VarType.UINT:
                            return new var((sbyte)v1._obj - (uint)v2._obj);
                        case VarType.LONG:
                            return new var((sbyte)v1._obj - (long)v2._obj);
                        case VarType.FLOAT:
                            return new var((sbyte)v1._obj - (float)v2._obj);
                        case VarType.DOUBLE:
                            return new var((sbyte)v1._obj - (double)v2._obj);
                    }
                    break;
                case VarType.SHORT:
                    switch (v2._type)
                    {
                        case VarType.BYTE:
                            return new var((short)v1._obj - (byte)v2._obj);
                        case VarType.UBYTE:
                            return new var((short)v1._obj - (sbyte)v2._obj);
                        case VarType.SHORT:
                            return new var((short)v1._obj - (short)v2._obj);
                        case VarType.USHORT:
                            return new var((short)v1._obj - (ushort)v2._obj);
                        case VarType.INT:
                            return new var((short)v1._obj - (int)v2._obj);
                        case VarType.UINT:
                            return new var((short)v1._obj - (uint)v2._obj);
                        case VarType.LONG:
                            return new var((short)v1._obj - (long)v2._obj);
                        case VarType.FLOAT:
                            return new var((short)v1._obj - (float)v2._obj);
                        case VarType.DOUBLE:
                            return new var((short)v1._obj - (double)v2._obj);
                    }
                    break;
                case VarType.USHORT:
                    switch (v2._type)
                    {
                        case VarType.BYTE:
                            return new var((ushort)v1._obj - (byte)v2._obj);
                        case VarType.UBYTE:
                            return new var((ushort)v1._obj - (sbyte)v2._obj);
                        case VarType.SHORT:
                            return new var((ushort)v1._obj - (short)v2._obj);
                        case VarType.USHORT:
                            return new var((ushort)v1._obj - (ushort)v2._obj);
                        case VarType.INT:
                            return new var((ushort)v1._obj - (int)v2._obj);
                        case VarType.UINT:
                            return new var((ushort)v1._obj - (uint)v2._obj);
                        case VarType.LONG:
                            return new var((ushort)v1._obj - (long)v2._obj);
                        case VarType.FLOAT:
                            return new var((ushort)v1._obj - (float)v2._obj);
                        case VarType.DOUBLE:
                            return new var((ushort)v1._obj - (double)v2._obj);
                    }
                    break;
                case VarType.INT:
                    switch (v2._type)
                    {
                        case VarType.BYTE:
                            return new var((int)v1._obj - (byte)v2._obj);
                        case VarType.UBYTE:
                            return new var((int)v1._obj - (sbyte)v2._obj);
                        case VarType.SHORT:
                            return new var((int)v1._obj - (short)v2._obj);
                        case VarType.USHORT:
                            return new var((int)v1._obj - (ushort)v2._obj);
                        case VarType.INT:
                            return new var((int)v1._obj - (int)v2._obj);
                        case VarType.UINT:
                            return new var((int)v1._obj - (uint)v2._obj);
                        case VarType.LONG:
                            return new var((int)v1._obj - (long)v2._obj);
                        case VarType.FLOAT:
                            return new var((int)v1._obj - (float)v2._obj);
                        case VarType.DOUBLE:
                            return new var((int)v1._obj - (double)v2._obj);
                    }
                    break;
                case VarType.UINT:
                    switch (v2._type)
                    {
                        case VarType.BYTE:
                            return new var((uint)v1._obj - (byte)v2._obj);
                        case VarType.UBYTE:
                            return new var((uint)v1._obj - (sbyte)v2._obj);
                        case VarType.SHORT:
                            return new var((uint)v1._obj - (short)v2._obj);
                        case VarType.USHORT:
                            return new var((uint)v1._obj - (ushort)v2._obj);
                        case VarType.INT:
                            return new var((uint)v1._obj - (int)v2._obj);
                        case VarType.UINT:
                            return new var((uint)v1._obj - (uint)v2._obj);
                        case VarType.LONG:
                            return new var((uint)v1._obj - (long)v2._obj);
                        case VarType.FLOAT:
                            return new var((uint)v1._obj - (float)v2._obj);
                        case VarType.DOUBLE:
                            return new var((uint)v1._obj - (double)v2._obj);
                    }
                    break;
                case VarType.LONG:
                    switch (v2._type)
                    {
                        case VarType.BYTE:
                            return new var((long)v1._obj - (byte)v2._obj);
                        case VarType.UBYTE:
                            return new var((long)v1._obj - (sbyte)v2._obj);
                        case VarType.SHORT:
                            return new var((long)v1._obj - (short)v2._obj);
                        case VarType.USHORT:
                            return new var((long)v1._obj - (ushort)v2._obj);
                        case VarType.INT:
                            return new var((long)v1._obj - (int)v2._obj);
                        case VarType.UINT:
                            return new var((long)v1._obj - (uint)v2._obj);
                        case VarType.LONG:
                            return new var((long)v1._obj - (long)v2._obj);
                        case VarType.FLOAT:
                            return new var((long)v1._obj - (float)v2._obj);
                        case VarType.DOUBLE:
                            return new var((long)v1._obj - (double)v2._obj);
                    }
                    break;
                case VarType.FLOAT:
                    switch (v2._type)
                    {
                        case VarType.BYTE:
                            return new var((float)v1._obj - (byte)v2._obj);
                        case VarType.UBYTE:
                            return new var((float)v1._obj - (sbyte)v2._obj);
                        case VarType.SHORT:
                            return new var((float)v1._obj - (short)v2._obj);
                        case VarType.USHORT:
                            return new var((float)v1._obj - (ushort)v2._obj);
                        case VarType.INT:
                            return new var((float)v1._obj - (int)v2._obj);
                        case VarType.UINT:
                            return new var((float)v1._obj - (uint)v2._obj);
                        case VarType.LONG:
                            return new var((float)v1._obj - (long)v2._obj);
                        case VarType.FLOAT:
                            return new var((float)v1._obj - (float)v2._obj);
                        case VarType.DOUBLE:
                            return new var((float)v1._obj - (double)v2._obj);
                    }
                    break;
                case VarType.DOUBLE:
                    switch (v2._type)
                    {
                        case VarType.BYTE:
                            return new var((double)v1._obj - (byte)v2._obj);
                        case VarType.UBYTE:
                            return new var((double)v1._obj - (sbyte)v2._obj);
                        case VarType.SHORT:
                            return new var((double)v1._obj - (short)v2._obj);
                        case VarType.USHORT:
                            return new var((double)v1._obj - (ushort)v2._obj);
                        case VarType.INT:
                            return new var((double)v1._obj - (int)v2._obj);
                        case VarType.UINT:
                            return new var((double)v1._obj - (uint)v2._obj);
                        case VarType.LONG:
                            return new var((double)v1._obj - (long)v2._obj);
                        case VarType.FLOAT:
                            return new var((double)v1._obj - (float)v2._obj);
                        case VarType.DOUBLE:
                            return new var((double)v1._obj - (double)v2._obj);
                    }
                    break;
            }
            return new var();
        }

        public static var operator *(var v1, var v2)
        {
            switch (v1._type)
            {
                case VarType.BYTE:
                    switch (v2._type)
                    {
                        case VarType.BYTE:
                            return new var((byte)v1._obj * (byte)v2._obj);
                        case VarType.UBYTE:
                            return new var((byte)v1._obj * (sbyte)v2._obj);
                        case VarType.SHORT:
                            return new var((byte)v1._obj * (short)v2._obj);
                        case VarType.USHORT:
                            return new var((byte)v1._obj * (ushort)v2._obj);
                        case VarType.INT:
                            return new var((byte)v1._obj * (int)v2._obj);
                        case VarType.UINT:
                            return new var((byte)v1._obj * (uint)v2._obj);
                        case VarType.LONG:
                            return new var((byte)v1._obj * (long)v2._obj);
                        case VarType.FLOAT:
                            return new var((byte)v1._obj * (float)v2._obj);
                        case VarType.DOUBLE:
                            return new var((byte)v1._obj * (double)v2._obj);
                    }
                    break;
                case VarType.UBYTE:
                    switch (v2._type)
                    {
                        case VarType.BYTE:
                            return new var((sbyte)v1._obj * (byte)v2._obj);
                        case VarType.UBYTE:
                            return new var((sbyte)v1._obj * (sbyte)v2._obj);
                        case VarType.SHORT:
                            return new var((sbyte)v1._obj * (short)v2._obj);
                        case VarType.USHORT:
                            return new var((sbyte)v1._obj * (ushort)v2._obj);
                        case VarType.INT:
                            return new var((sbyte)v1._obj * (int)v2._obj);
                        case VarType.UINT:
                            return new var((sbyte)v1._obj * (uint)v2._obj);
                        case VarType.LONG:
                            return new var((sbyte)v1._obj * (long)v2._obj);
                        case VarType.FLOAT:
                            return new var((sbyte)v1._obj * (float)v2._obj);
                        case VarType.DOUBLE:
                            return new var((sbyte)v1._obj * (double)v2._obj);
                    }
                    break;
                case VarType.SHORT:
                    switch (v2._type)
                    {
                        case VarType.BYTE:
                            return new var((short)v1._obj * (byte)v2._obj);
                        case VarType.UBYTE:
                            return new var((short)v1._obj * (sbyte)v2._obj);
                        case VarType.SHORT:
                            return new var((short)v1._obj * (short)v2._obj);
                        case VarType.USHORT:
                            return new var((short)v1._obj * (ushort)v2._obj);
                        case VarType.INT:
                            return new var((short)v1._obj * (int)v2._obj);
                        case VarType.UINT:
                            return new var((short)v1._obj * (uint)v2._obj);
                        case VarType.LONG:
                            return new var((short)v1._obj * (long)v2._obj);
                        case VarType.FLOAT:
                            return new var((short)v1._obj * (float)v2._obj);
                        case VarType.DOUBLE:
                            return new var((short)v1._obj * (double)v2._obj);
                    }
                    break;
                case VarType.USHORT:
                    switch (v2._type)
                    {
                        case VarType.BYTE:
                            return new var((ushort)v1._obj * (byte)v2._obj);
                        case VarType.UBYTE:
                            return new var((ushort)v1._obj * (sbyte)v2._obj);
                        case VarType.SHORT:
                            return new var((ushort)v1._obj * (short)v2._obj);
                        case VarType.USHORT:
                            return new var((ushort)v1._obj * (ushort)v2._obj);
                        case VarType.INT:
                            return new var((ushort)v1._obj * (int)v2._obj);
                        case VarType.UINT:
                            return new var((ushort)v1._obj * (uint)v2._obj);
                        case VarType.LONG:
                            return new var((ushort)v1._obj * (long)v2._obj);
                        case VarType.FLOAT:
                            return new var((ushort)v1._obj * (float)v2._obj);
                        case VarType.DOUBLE:
                            return new var((ushort)v1._obj * (double)v2._obj);
                    }
                    break;
                case VarType.INT:
                    switch (v2._type)
                    {
                        case VarType.BYTE:
                            return new var((int)v1._obj * (byte)v2._obj);
                        case VarType.UBYTE:
                            return new var((int)v1._obj * (sbyte)v2._obj);
                        case VarType.SHORT:
                            return new var((int)v1._obj * (short)v2._obj);
                        case VarType.USHORT:
                            return new var((int)v1._obj * (ushort)v2._obj);
                        case VarType.INT:
                            return new var((int)v1._obj * (int)v2._obj);
                        case VarType.UINT:
                            return new var((int)v1._obj * (uint)v2._obj);
                        case VarType.LONG:
                            return new var((int)v1._obj * (long)v2._obj);
                        case VarType.FLOAT:
                            return new var((int)v1._obj * (float)v2._obj);
                        case VarType.DOUBLE:
                            return new var((int)v1._obj * (double)v2._obj);
                    }
                    break;
                case VarType.UINT:
                    switch (v2._type)
                    {
                        case VarType.BYTE:
                            return new var((uint)v1._obj * (byte)v2._obj);
                        case VarType.UBYTE:
                            return new var((uint)v1._obj * (sbyte)v2._obj);
                        case VarType.SHORT:
                            return new var((uint)v1._obj * (short)v2._obj);
                        case VarType.USHORT:
                            return new var((uint)v1._obj * (ushort)v2._obj);
                        case VarType.INT:
                            return new var((uint)v1._obj * (int)v2._obj);
                        case VarType.UINT:
                            return new var((uint)v1._obj * (uint)v2._obj);
                        case VarType.LONG:
                            return new var((uint)v1._obj * (long)v2._obj);
                        case VarType.FLOAT:
                            return new var((uint)v1._obj * (float)v2._obj);
                        case VarType.DOUBLE:
                            return new var((uint)v1._obj * (double)v2._obj);
                    }
                    break;
                case VarType.LONG:
                    switch (v2._type)
                    {
                        case VarType.BYTE:
                            return new var((long)v1._obj * (byte)v2._obj);
                        case VarType.UBYTE:
                            return new var((long)v1._obj * (sbyte)v2._obj);
                        case VarType.SHORT:
                            return new var((long)v1._obj * (short)v2._obj);
                        case VarType.USHORT:
                            return new var((long)v1._obj * (ushort)v2._obj);
                        case VarType.INT:
                            return new var((long)v1._obj * (int)v2._obj);
                        case VarType.UINT:
                            return new var((long)v1._obj * (uint)v2._obj);
                        case VarType.LONG:
                            return new var((long)v1._obj * (long)v2._obj);
                        case VarType.FLOAT:
                            return new var((long)v1._obj * (float)v2._obj);
                        case VarType.DOUBLE:
                            return new var((long)v1._obj * (double)v2._obj);
                    }
                    break;
                case VarType.FLOAT:
                    switch (v2._type)
                    {
                        case VarType.BYTE:
                            return new var((float)v1._obj * (byte)v2._obj);
                        case VarType.UBYTE:
                            return new var((float)v1._obj * (sbyte)v2._obj);
                        case VarType.SHORT:
                            return new var((float)v1._obj * (short)v2._obj);
                        case VarType.USHORT:
                            return new var((float)v1._obj * (ushort)v2._obj);
                        case VarType.INT:
                            return new var((float)v1._obj * (int)v2._obj);
                        case VarType.UINT:
                            return new var((float)v1._obj * (uint)v2._obj);
                        case VarType.LONG:
                            return new var((float)v1._obj * (long)v2._obj);
                        case VarType.FLOAT:
                            return new var((float)v1._obj * (float)v2._obj);
                        case VarType.DOUBLE:
                            return new var((float)v1._obj * (double)v2._obj);
                    }
                    break;
                case VarType.DOUBLE:
                    switch (v2._type)
                    {
                        case VarType.BYTE:
                            return new var((double)v1._obj * (byte)v2._obj);
                        case VarType.UBYTE:
                            return new var((double)v1._obj * (sbyte)v2._obj);
                        case VarType.SHORT:
                            return new var((double)v1._obj * (short)v2._obj);
                        case VarType.USHORT:
                            return new var((double)v1._obj * (ushort)v2._obj);
                        case VarType.INT:
                            return new var((double)v1._obj * (int)v2._obj);
                        case VarType.UINT:
                            return new var((double)v1._obj * (uint)v2._obj);
                        case VarType.LONG:
                            return new var((double)v1._obj * (long)v2._obj);
                        case VarType.FLOAT:
                            return new var((double)v1._obj * (float)v2._obj);
                        case VarType.DOUBLE:
                            return new var((double)v1._obj * (double)v2._obj);
                    }
                    break;
            }
            return new var();
        }

        public static var operator /(var v1, var v2)
        {
            switch (v1._type)
            {
                case VarType.BYTE:
                    switch (v2._type)
                    {
                        case VarType.BYTE:
                            return new var((byte)v1._obj / (byte)v2._obj);
                        case VarType.UBYTE:
                            return new var((byte)v1._obj / (sbyte)v2._obj);
                        case VarType.SHORT:
                            return new var((byte)v1._obj / (short)v2._obj);
                        case VarType.USHORT:
                            return new var((byte)v1._obj / (ushort)v2._obj);
                        case VarType.INT:
                            return new var((byte)v1._obj / (int)v2._obj);
                        case VarType.UINT:
                            return new var((byte)v1._obj / (uint)v2._obj);
                        case VarType.LONG:
                            return new var((byte)v1._obj / (long)v2._obj);
                        case VarType.FLOAT:
                            return new var((byte)v1._obj / (float)v2._obj);
                        case VarType.DOUBLE:
                            return new var((byte)v1._obj / (double)v2._obj);
                    }
                    break;
                case VarType.UBYTE:
                    switch (v2._type)
                    {
                        case VarType.BYTE:
                            return new var((sbyte)v1._obj / (byte)v2._obj);
                        case VarType.UBYTE:
                            return new var((sbyte)v1._obj / (sbyte)v2._obj);
                        case VarType.SHORT:
                            return new var((sbyte)v1._obj / (short)v2._obj);
                        case VarType.USHORT:
                            return new var((sbyte)v1._obj / (ushort)v2._obj);
                        case VarType.INT:
                            return new var((sbyte)v1._obj / (int)v2._obj);
                        case VarType.UINT:
                            return new var((sbyte)v1._obj / (uint)v2._obj);
                        case VarType.LONG:
                            return new var((sbyte)v1._obj / (long)v2._obj);
                        case VarType.FLOAT:
                            return new var((sbyte)v1._obj / (float)v2._obj);
                        case VarType.DOUBLE:
                            return new var((sbyte)v1._obj / (double)v2._obj);
                    }
                    break;
                case VarType.SHORT:
                    switch (v2._type)
                    {
                        case VarType.BYTE:
                            return new var((short)v1._obj / (byte)v2._obj);
                        case VarType.UBYTE:
                            return new var((short)v1._obj / (sbyte)v2._obj);
                        case VarType.SHORT:
                            return new var((short)v1._obj / (short)v2._obj);
                        case VarType.USHORT:
                            return new var((short)v1._obj / (ushort)v2._obj);
                        case VarType.INT:
                            return new var((short)v1._obj / (int)v2._obj);
                        case VarType.UINT:
                            return new var((short)v1._obj / (uint)v2._obj);
                        case VarType.LONG:
                            return new var((short)v1._obj / (long)v2._obj);
                        case VarType.FLOAT:
                            return new var((short)v1._obj / (float)v2._obj);
                        case VarType.DOUBLE:
                            return new var((short)v1._obj / (double)v2._obj);
                    }
                    break;
                case VarType.USHORT:
                    switch (v2._type)
                    {
                        case VarType.BYTE:
                            return new var((ushort)v1._obj / (byte)v2._obj);
                        case VarType.UBYTE:
                            return new var((ushort)v1._obj / (sbyte)v2._obj);
                        case VarType.SHORT:
                            return new var((ushort)v1._obj / (short)v2._obj);
                        case VarType.USHORT:
                            return new var((ushort)v1._obj / (ushort)v2._obj);
                        case VarType.INT:
                            return new var((ushort)v1._obj / (int)v2._obj);
                        case VarType.UINT:
                            return new var((ushort)v1._obj / (uint)v2._obj);
                        case VarType.LONG:
                            return new var((ushort)v1._obj / (long)v2._obj);
                        case VarType.FLOAT:
                            return new var((ushort)v1._obj / (float)v2._obj);
                        case VarType.DOUBLE:
                            return new var((ushort)v1._obj / (double)v2._obj);
                    }
                    break;
                case VarType.INT:
                    switch (v2._type)
                    {
                        case VarType.BYTE:
                            return new var((int)v1._obj / (byte)v2._obj);
                        case VarType.UBYTE:
                            return new var((int)v1._obj / (sbyte)v2._obj);
                        case VarType.SHORT:
                            return new var((int)v1._obj / (short)v2._obj);
                        case VarType.USHORT:
                            return new var((int)v1._obj / (ushort)v2._obj);
                        case VarType.INT:
                            return new var((int)v1._obj / (int)v2._obj);
                        case VarType.UINT:
                            return new var((int)v1._obj / (uint)v2._obj);
                        case VarType.LONG:
                            return new var((int)v1._obj / (long)v2._obj);
                        case VarType.FLOAT:
                            return new var((int)v1._obj / (float)v2._obj);
                        case VarType.DOUBLE:
                            return new var((int)v1._obj / (double)v2._obj);
                    }
                    break;
                case VarType.UINT:
                    switch (v2._type)
                    {
                        case VarType.BYTE:
                            return new var((uint)v1._obj / (byte)v2._obj);
                        case VarType.UBYTE:
                            return new var((uint)v1._obj / (sbyte)v2._obj);
                        case VarType.SHORT:
                            return new var((uint)v1._obj / (short)v2._obj);
                        case VarType.USHORT:
                            return new var((uint)v1._obj / (ushort)v2._obj);
                        case VarType.INT:
                            return new var((uint)v1._obj / (int)v2._obj);
                        case VarType.UINT:
                            return new var((uint)v1._obj / (uint)v2._obj);
                        case VarType.LONG:
                            return new var((uint)v1._obj / (long)v2._obj);
                        case VarType.FLOAT:
                            return new var((uint)v1._obj / (float)v2._obj);
                        case VarType.DOUBLE:
                            return new var((uint)v1._obj / (double)v2._obj);
                    }
                    break;
                case VarType.LONG:
                    switch (v2._type)
                    {
                        case VarType.BYTE:
                            return new var((long)v1._obj / (byte)v2._obj);
                        case VarType.UBYTE:
                            return new var((long)v1._obj / (sbyte)v2._obj);
                        case VarType.SHORT:
                            return new var((long)v1._obj / (short)v2._obj);
                        case VarType.USHORT:
                            return new var((long)v1._obj / (ushort)v2._obj);
                        case VarType.INT:
                            return new var((long)v1._obj / (int)v2._obj);
                        case VarType.UINT:
                            return new var((long)v1._obj / (uint)v2._obj);
                        case VarType.LONG:
                            return new var((long)v1._obj / (long)v2._obj);
                        case VarType.FLOAT:
                            return new var((long)v1._obj / (float)v2._obj);
                        case VarType.DOUBLE:
                            return new var((long)v1._obj / (double)v2._obj);
                    }
                    break;
                case VarType.FLOAT:
                    switch (v2._type)
                    {
                        case VarType.BYTE:
                            return new var((float)v1._obj / (byte)v2._obj);
                        case VarType.UBYTE:
                            return new var((float)v1._obj / (sbyte)v2._obj);
                        case VarType.SHORT:
                            return new var((float)v1._obj / (short)v2._obj);
                        case VarType.USHORT:
                            return new var((float)v1._obj / (ushort)v2._obj);
                        case VarType.INT:
                            return new var((float)v1._obj / (int)v2._obj);
                        case VarType.UINT:
                            return new var((float)v1._obj / (uint)v2._obj);
                        case VarType.LONG:
                            return new var((float)v1._obj / (long)v2._obj);
                        case VarType.FLOAT:
                            return new var((float)v1._obj / (float)v2._obj);
                        case VarType.DOUBLE:
                            return new var((float)v1._obj / (double)v2._obj);
                    }
                    break;
                case VarType.DOUBLE:
                    switch (v2._type)
                    {
                        case VarType.BYTE:
                            return new var((double)v1._obj / (byte)v2._obj);
                        case VarType.UBYTE:
                            return new var((double)v1._obj / (sbyte)v2._obj);
                        case VarType.SHORT:
                            return new var((double)v1._obj / (short)v2._obj);
                        case VarType.USHORT:
                            return new var((double)v1._obj / (ushort)v2._obj);
                        case VarType.INT:
                            return new var((double)v1._obj / (int)v2._obj);
                        case VarType.UINT:
                            return new var((double)v1._obj / (uint)v2._obj);
                        case VarType.LONG:
                            return new var((double)v1._obj / (long)v2._obj);
                        case VarType.FLOAT:
                            return new var((double)v1._obj / (float)v2._obj);
                        case VarType.DOUBLE:
                            return new var((double)v1._obj / (double)v2._obj);
                    }
                    break;
            }
            return new var();
        }

        public static int getSize(VarType type)
        {
            switch (type)
            {
                case VarType.UNDEFINED:
                    return 0;
                case VarType.BYTE:
                case VarType.INDEX:
                    return 1;
                case VarType.UBYTE:
                    return 1;
                case VarType.SHORT:
                    return 2;
                case VarType.USHORT:
                    return 2;
                case VarType.INT:
                    return 4;
                case VarType.UINT:
                    return 4;
                case VarType.LONG:
                    return 8;
                case VarType.FLOAT:
                    return 4;
                case VarType.DOUBLE:
                    return 8;
                default:
                    throw new RunnerError(ErrorCode.BAD_VAR_TYPE);
            }
        }

        public void parse(VarType type, Byte[] data)
        {
            switch (type)
            {
                case VarType.UNDEFINED:
                    _obj = null;
                    break;
                case VarType.BYTE:
                    _obj = (byte)data[0];
                    break;
                case VarType.UBYTE:
                    _obj = (sbyte)data[0];
                    break;
                case VarType.SHORT:
                    _obj = BitConverter.ToInt16(data, 0);
                    break;
                case VarType.USHORT:
                    _obj = BitConverter.ToUInt16(data, 0);
                    break;
                case VarType.INT:
                    _obj = BitConverter.ToInt32(data, 0);
                    break;
                case VarType.UINT:
                    _obj = BitConverter.ToUInt32(data, 0);
                    break;
                case VarType.LONG:
                    _obj = BitConverter.ToUInt64(data, 0);
                    break;
                case VarType.FLOAT:
                    _obj = BitConverter.ToSingle(data, 0);
                    break;
                case VarType.DOUBLE:
                    _obj = BitConverter.ToDouble(data, 0);
                    break;
                default:
                    throw new RunnerError(ErrorCode.BAD_VAR_TYPE);
            }
            _type = type;
        }
    }

}
