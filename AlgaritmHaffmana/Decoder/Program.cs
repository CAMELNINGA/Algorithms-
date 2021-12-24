using System;
using System.Collections.Generic;

namespace Decoder
{
    class Program
    {
        static void Main(string[] args)
        {
            string code, text,e;
            List<string> line = new List<string>();
            Reader reader = new Reader();
            (line, e) = reader.Readtext("D:\\Data\\TIC\\AlgaritmHaffmana\\AlgaritmHaffmana\\codfile_0.txt");
            if (e == null)
            {
               
                Decod decod = new Decod();
                Dictionary<string, string> dictionary = new Dictionary<string, string>();
                dictionary = decod.WDictonary(line);
                
                string detext = decod.Decode(dictionary, line[line.Count - 1]);
                reader.WriteDecode(detext);
            }
            else
            {
                Console.WriteLine(e);
            }
            Console.ReadLine();

        }
    }
}
