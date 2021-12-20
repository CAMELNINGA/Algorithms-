using System;

namespace Decoder
{
    class Program
    {
        static void Main(string[] args)
        {
            string code, text,e;

            Reader reader = new Reader();
            (code, text, e) = reader.Readtext("D:\\Data\\TIC\\AlgaritmHaffmana\\AlgaritmHaffmana\\codfile_21.txt");
            if (e == null)
            {
                Console.WriteLine(code);
                Console.WriteLine(text);
            }
            else
            {
                Console.WriteLine(e);
            }
            Console.ReadLine();

        }
    }
}
