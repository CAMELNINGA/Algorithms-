using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Arithmetic
{
    class ReadText
    {
        public (string, string) Readtext(string filepath)
        {
            String line;
            String text = "";
            try
            {
                //Pass the file path and file name to the StreamReader constructor
                StreamReader sr = new StreamReader(filepath);
                //Read the first line of text
                line = sr.ReadLine();
                text = line;
                //Continue to read until you reach end of file
                while (line != null)
                {
                    //write the line to console window

                    //Read the next line
                    line = sr.ReadLine();
                    text = text + "\n" + line;

                }

                //close the file
                sr.Close();
                return (text, null);
            }
            catch (Exception e)
            {
                return (null, "Exception: " + e.Message);

            }
        }

        public void WriteText(string dictonary, string text)
        {
            string path = "D:\\Data\\TIC\\Arithmetic\\Arithmetic\\codfile_" + DateTime.Now.Hour + ".txt";
            try
            {
                // Create the file, or overwrite if the file exists.
                using (FileStream fs = File.Create(path))
                {
                    byte[] info = new UTF8Encoding(true).GetBytes(dictonary + text);
                    // Add some information to the file.
                    fs.Write(info, 0, info.Length);
                }


            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}
