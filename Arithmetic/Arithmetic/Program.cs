using System;
using System.Collections.Generic;
using Deveel.Math;

namespace Arithmetic
{
    class Program
    {
        static void Main(string[] args)
        {
            string s;
            string exept;
            ReadText text = new ReadText();

            (s, exept) = text.Readtext("D:\\Data\\TIC\\Arithmetic\\Arithmetic\\test.txt");
            if (exept == null)
            {

                char[] c = s.ToCharArray();
                Reader read = new Reader();
                List<Node> node = read.Count(c);
                foreach (Node i in node)
                {
                    Console.WriteLine("Char={0} Frequency={1} Range={2:R}", i.Chars, i.Frequency ,i.Range);
                }
                Arithmetic arithmetic = new Arithmetic(node);
                arithmetic.Start(c);
                BigDecimal low;
                BigDecimal high;
                (low, high) = arithmetic.Count();
                Console.WriteLine("low={0}", low);
                Console.WriteLine("high={0}", high);
            }
            else
            {
                Console.WriteLine(exept);
                Console.ReadLine();
            }
            Console.ReadLine();
        }
    }
}
