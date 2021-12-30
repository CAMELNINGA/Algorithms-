using System;
using System.Collections.Generic;
using System.Text;

namespace Decoder
{
    class Binarin
    {
        public string ToByte(List<bool> code)
        {

            while (code.Length % 8 != 0)
            {
                code = code + "0";
            }
            List<bool> bools = new List<bool>();

            foreach (char c in code)
            {
                bools.Add(c == '1');
            }

            BitArray bitArray = new BitArray(bools.Count);
            byte[] bytes = new byte[bitArray.Length / 8];
            bitArray.CopyTo(bytes, 0);
            return bytes;

        }
    }
}
