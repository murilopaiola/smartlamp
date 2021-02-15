using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartLamp.Extensions
{
    public static class BytesExtensionMethods
    {
        public static byte GetBytesFromString(this string param)
        {
            int intValue = Convert.ToInt32(param);
            if (intValue > 255) return default;
            var valueByte = BitConverter.GetBytes(intValue);

            if (BitConverter.IsLittleEndian)
            {
                Array.Reverse(valueByte);
                return valueByte[3];
            }
            return valueByte[0];
        }
    }
}
