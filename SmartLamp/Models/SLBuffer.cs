using SmartLamp.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartLamp.Models
{
    public class SLBuffer : ObservableObject
    {
        public byte[] bytes;
        public SLBuffer()
        {
            bytes = new byte[11];
        }

        public byte Net 
        { 
            get
            {
                return bytes[0];
            }
            set
            {
                bytes[0] = value;
            }
        }

        public byte Group
        {
            get
            {
                return bytes[1];
            }
            set
            {
                bytes[1] = value;
                
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

        public byte Funcao
        {
            get
            {
                return bytes[4];
            }
            set
            {
                bytes[4] = value;
                
            }
        }

        public byte Endih
        {
            get
            {
                return bytes[5];
            }
            set
            {
                bytes[5] = value;
                
            }
        }

        public byte Endil
        {
            get
            {
                return bytes[6];
            }
            set
            {
                bytes[6] = value;
                
            }
        }

        public byte Endfh
        {
            get
            {
                return bytes[7];
            }
            set
            {
                bytes[7] = value;
            }
        }

        public byte Endfl
        {
            get
            {
                return bytes[8];
            }
            set
            {
                bytes[8] = value;
                
            }
        }

        public byte Param
        {
            get
            {
                return bytes[9];
            }
            set
            {
                bytes[9] = value;
            }
        }

        public byte Crc
        {
            get
            {
                return bytes[10];
            }
        }

        public void UpdateBufferCrc()
        {
            var slice = bytes[0..^1];
            var result = slice.Aggregate((a, b) => a ^= b);
            bytes[10] = result;
        }
    }
}
