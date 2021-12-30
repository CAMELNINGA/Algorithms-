using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Decdoder
{
    class ToBool
    {

        public List<bool> Bits = new List<bool>();


        public ToBool(byte[] values)
        {
            Bits = values.SelectMany(GetBitsStartingFromLSB).ToList();
        }



        static IEnumerable<bool> GetBitsStartingFromLSB(byte b)
        {
            for (int i = 0; i < 8; i++)
            {
                yield return (b % 2 == 0) ? false : true;
                b = (byte)(b >> 1);
            }
        }
        public byte[] ToByteArray(List<bool> bools)
        {
            BitArray bitArray = new BitArray(bools.ToArray());
            byte[] bytes = new byte[bitArray.Length / 8];
            bitArray.CopyTo(bytes, 0);
            return bytes;
        }
    }
}
