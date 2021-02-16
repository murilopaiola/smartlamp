using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SmartLamp.Extensions
{
    public static class BytesExtensionMethods
    {
        public static byte[] GetBytesFromString(this string param)
        {
            var intValue = Convert.ToUInt16(param);
            byte[] valueByte = BitConverter.GetBytes(intValue);
            if (BitConverter.IsLittleEndian)
                Array.Reverse(valueByte);
            return valueByte;
        }

        public static byte GetByteFromString(this string param)
        {
            var intValue = Convert.ToUInt16(param);
            byte[] valueByte = BitConverter.GetBytes(intValue);
            if (BitConverter.IsLittleEndian)
            {
                Array.Reverse(valueByte);
                return valueByte[1];
            }
            return valueByte[0];
        }
    }
}
