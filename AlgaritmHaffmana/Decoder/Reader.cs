using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Numerics;
using System.Linq;

namespace Decoder
{
    class Reader
    {
        public (List<string>, string) ReadDecode(string filepath)
        {
            String line;
            List<string> line1 = new List<string>();

            try
            {
                //Pass the file path and file name to the StreamReader constructor
                StreamReader sr = new StreamReader(filepath);
                //Read the first line of text
                line = sr.ReadLine();

                //Continue to read until you reach end of file
                while (line != null)
                {

                    line1.Add(line);
                    //Read the next line
                    line = sr.ReadLine();



                }

                //close the file
                sr.Close();
                return (line1, null);
            }
            catch (Exception e)
            {
                return (null, "Exception: " + e.Message);

            }
        }
        public void WriteDecode(string text)
        {
            string path = "D:\\Data\\TIC\\AlgaritmHaffmana\\AlgaritmHaffmana\\decode_" + DateTime.Now.Hour + ".txt";
            try
            {
                // Create the file, or overwrite if the file exists.
                using (FileStream fs = File.Create(path))
                {
                    byte[] info = new UTF8Encoding(true).GetBytes(text);
                    // Add some information to the file.
                    fs.Write(info, 0, info.Length);
                }


            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
        public (string, string) Readtext(string filepath)
        {

            String text = "";
            try
            {
                //Pass the file path and file name to the StreamReader constructor

                //Read the first line of text

                byte[] bytes = File.ReadAllBytes(filepath);
                BigInteger bigint = new BigInteger(bytes);
                text = Encoding.UTF8.GetString(bytes);



                return (text, null);
            }
            catch (Exception e)
            {
                return (null, "Exception: " + e.Message);

            }

        }
        public List<bool> ToBool(byte[] values)
        {
            List <bool> Bits = values.SelectMany(GetBitsStartingFromLSB).ToList();
            return Bits;
        }



        static IEnumerable<bool> GetBitsStartingFromLSB(byte b)
        {
            for (int i = 0; i < 8; i++)
            {
                yield return (b % 2 == 0) ? false : true;
                b = (byte)(b >> 1);
            }
        }
    }
}
