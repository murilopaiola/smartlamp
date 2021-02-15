using SmartLamp.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartLamp.Models
{
    public class SLBuffer
    {
        public byte[] bytes;
        public SLBuffer(int size)
        {
            bytes = new byte[size];
        }

        public string Net 
        { 
            get
            {
                return Convert.ToString(bytes[0]);
            }
            set
            {
                byte val = value.GetBytesFromString();
                bytes[0] = val;
            }
        }

        public string Group
        {
            get
            {
                return Convert.ToString(bytes[1]);
            }
            set
            {
                byte val = value.GetBytesFromString();
                bytes[1] = val;
            }
        }

        public byte Idh
        {
            get
            {
                return bytes[2];
            }
            set
            {
                bytes[2] = value;
            }
        }

        public byte Idl
        {
            get
            {
                return bytes[3];
            }
            set
            {
                bytes[3] = value;
            }
        }

        public string Funcao
        {
            get
            {
                return Convert.ToString(bytes[4]);
            }
            set
            {
                byte val = value.GetBytesFromString();
                bytes[4] = val;
            }
        }

        public string Endih
        {
            get
            {
                return Convert.ToString(bytes[5]);
            }
            set
            {
                byte val = value.GetBytesFromString();
                bytes[5] = val;
            }
        }

        public string Endil
        {
            get
            {
                return Convert.ToString(bytes[6]);
            }
            set
            {
                byte val = value.GetBytesFromString();
                bytes[6] = val;
            }
        }

        public string Endfh
        {
            get
            {
                return Convert.ToString(bytes[7]);
            }
            set
            {
                byte val = value.GetBytesFromString();
                bytes[7] = val;
            }
        }

        public string Endfl
        {
            get
            {
                return Convert.ToString(bytes[8]);
            }
            set
            {
                byte val = value.GetBytesFromString();
                bytes[8] = val;
            }
        }

        public string Param
        {
            get
            {
                return Convert.ToString(bytes[9]);
            }
            set
            {
                byte val = value.GetBytesFromString();
                bytes[9] = val;
            }
        }

        //XOR todos outros parametros
        public byte Crc
        {
            get
            {
                if (bytes[10] == 0)
                {
                    byte result = 0;
                    foreach (var by in bytes[0..^1])
                        result ^= by;
                    return result;
                }

                return bytes[10];
            }
            set
            {
                bytes[10] = value;
            }
        }
    }
}
