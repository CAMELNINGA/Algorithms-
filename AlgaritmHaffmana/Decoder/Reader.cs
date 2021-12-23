using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Decoder
{
    class Reader
    {
        public (List<string>, string) Readtext(string filepath)
        {
            String line;
            List<string>line1 = new List<string>();
          
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
                return (line1,null);
            }
            catch (Exception e)
            {
                return (null,"Exception: " + e.Message);

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
                    byte[] info = new UTF8Encoding(true).GetBytes( text);
                    // Add some information to the file.
                    fs.Write(info, 0, info.Length);
                }
                Console.WriteLine(path);

            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}
