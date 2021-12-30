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
            (line, e) = reader.ReadDecode("D:\\Data\\TIC\\AlgaritmHaffmana\\AlgaritmHaffmana\\dicfile_13.txt");
            (text, e) = reader.Readtext("D:\\Data\\TIC\\AlgaritmHaffmana\\AlgaritmHaffmana\\codfile_13.txt");
            if (e == null)
            {
               
                Decod decod = new Decod();
                Dictionary<string, string> dictionary = new Dictionary<string, string>();
                dictionary = decod.WDictonary(line);
                
                string detext = decod.Decode(dictionary, text);
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
