using System;
using System.Collections.Generic;

namespace Decoder
{
    class Program
    {
        static void Main(string[] args)
        {
            ReadText read = new ReadText();
            string dictonary, text, e;
        
            (dictonary,text, e) = read.ReadDict("D:\\Data\\TIC\\Arithmetic\\Arithmetic\\dicfile_20.txt", "D:\\Data\\TIC\\Arithmetic\\Arithmetic\\codfile_20.txt");
            if (e == null)
            {
                int count;
                List<Node> dict = new List<Node>();
                Rerder rerder = new Rerder();
                (dict,count) = rerder.SplitString(dictonary);
                foreach (Node i in dict)
                {
                    Console.WriteLine("Char={0} Range={1}", i.Chars, i.Range);
                }
                DeArithmetic de = new DeArithmetic(dict, read, text, count);
                var tex = de.Start();
                Console.WriteLine(tex);
               
            }
            else
            {
                Console.WriteLine(e);
            }
        }
    }
}
