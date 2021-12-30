using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace AlgaritmHaffmana
{
    class ReadText
    {
        string path { get; set; }
        string dpath { get; set; }
        public (string, string) Readtext(string filepath)
        {
            String line;
            String text="";
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
                    line= sr.ReadLine();
                    text = text+"\n" + line;

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

         public void  WriteText(string dictonary, string text )
        {
           
            try
            {
                // Create the file, or overwrite if the file exists.
                using (FileStream fs = File.Create(path))
                {
                    byte[] info = new UTF8Encoding(true).GetBytes(dictonary+text);
                    // Add some information to the file.
                    fs.Write(info, 0, info.Length);
                }

                
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
        public void WriteDict(string dictonary)
        {
            path = "D:\\Data\\TIC\\AlgaritmHaffmana\\AlgaritmHaffmana\\codfile_" + DateTime.Now.Hour + ".txt";

            dpath = "D:\\Data\\TIC\\AlgaritmHaffmana\\AlgaritmHaffmana\\dicfile_" + DateTime.Now.Hour + ".txt";
            try
            {
                // Create the file, or overwrite if the file exists.
                using (FileStream fs = File.Create(dpath))
                {
                    byte[] info = new UTF8Encoding(true).GetBytes(dictonary + "\n");
                    // Add some information to the file.
                    fs.Write(info, 0, info.Length);
                }
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

        }

        public void WriteText(byte[] text)
        {
            try
            {
                using (FileStream fs = new FileStream(path, FileMode.Create))
                {
                    fs.Write(text, 0, text.Length);
                    

                    fs.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}
