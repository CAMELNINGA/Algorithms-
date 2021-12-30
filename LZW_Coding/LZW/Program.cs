using System;
using System.Collections.Generic;

namespace LZW
{
    class Program
    {
        static void Main(string[] args)
        {
            string test = "assaddasdaadsfasfafs";
            Lzw lzw = new Lzw(test);
            Dictionary<string, int> keys = new Dictionary<string, int>();
            foreach(KeyValuePair<string, int> k in lzw.keys)
            {
                keys.Add(k.Key, k.Value);
            }
            
            lzw.Start();
            foreach(KeyValuePair<string,int> keyValuePair in lzw.keys)
            {
                Console.WriteLine("Kye={0} Code={1}", keyValuePair.Key, keyValuePair.Value);
            }
            Console.WriteLine(lzw.Code);
            Console.WriteLine("Hello World!");

            DeLzw deLzw = new DeLzw(keys, lzw.Code);
            deLzw.Start();
            foreach (KeyValuePair<int, string> keyValuePair in deLzw.Keys)
            {
                Console.WriteLine("Kye={0} Code={1}", keyValuePair.Key, keyValuePair.Value);
            }
            Console.WriteLine(test);
            Console.WriteLine(deLzw.Text);
        }
    }
}
