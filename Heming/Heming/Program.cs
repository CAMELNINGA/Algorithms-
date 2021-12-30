using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace Heming
{
    class Program
    {
        static void Main(string[] args)
        {
            BigInteger bigint = new BigInteger(Encoding.ASCII.GetBytes("Hello World"));

           
            List<bool> bytes= new List<bool>();
            ToBool toBool = new ToBool(bigint.ToByteArray());
            for (int i = 0; i < toBool.Bits.Count / 8; i++)
            {
                List<bool> list = new List<bool>();
                for(int j =0+i*8; j < 8+(i) * 8; j++)
                {
                    list.Add(toBool.Bits[j]);
                }
                ControlBits bits = new ControlBits();
                bits.CreateNewBits(list);
                bits.UpdateBits();
                foreach(bool booling in bits.Bits) 
                {
                    bytes.Add(booling);
                }

            }
            byte[] end =toBool.ToByteArray(bytes) ;

            ReaderText reader = new ReaderText();
            reader.WriteText(end);
        }
    }
}
