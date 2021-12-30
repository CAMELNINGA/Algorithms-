using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace Arithmetic
{
    class Binarin
    {
        //Haffman
        public byte[] ToByte(string code)
        {

            while (code.Length % 8 != 0)
            {
                code =  code+"0";
            }
            List<bool> bools = new List<bool>();

            foreach(char c in code)
            {
                bools.Add(c == '1');
            }

            BitArray bitArray = new BitArray(bools.Count);
            byte[] bytes = new byte[bitArray.Length / 8];
            bitArray.CopyTo(bytes, 0);
            return bytes;

        }

        public (byte[], byte[]) ToByteInBig (string same,string pref )
        {

            while (same[0] == '0')
            {
                   
                   
                if (same == "")
                {
                    BigInteger bigZer = BigInteger.Parse('-' + pref);
                    return (null, bigZer.ToByteArray());
                }
            }
           
            BigInteger intsame = BigInteger.Parse(same);
            BigInteger bigZero = BigInteger.Parse('-'+pref); 
                return (intsame.ToByteArray(), bigZero.ToByteArray());
            
            
           
        }
    }
}
