using System;
using System.Collections.Generic;

namespace Decdoder
{
    class Program
    {
        static void Main(string[] args)
        {
            ReadText readText = new ReadText();
            byte[] bytes;
            string e;
            (bytes, e) = readText.Readtext("D:\\Data\\TIC\\Heming\\Heming\\codfile_7.txt");
             if (e == null)
            {
                ToBool toBool = new ToBool(bytes);


            }
            else
            {
                Console.WriteLine(e);
            }
        }
    }
}
