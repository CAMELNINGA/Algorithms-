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
                var length = c.Length;
                Reader read = new Reader();
                List<Node> node = read.Count(c);
                string dict = "";
                foreach (Node i in node)
                {
                    dict = dict + i.Chars + i.Range.ToString() + "\n";
                    Console.WriteLine("Char={0} Frequency={1} Range={2:R}", i.Chars, i.Frequency ,i.Range);
                }
                text.WriteDict(dict);
                Arithmetic arithmetic = new Arithmetic(node,text);
                arithmetic.Start();
                text.WriteText(length.ToString());
                decimal low;
                decimal high;
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
