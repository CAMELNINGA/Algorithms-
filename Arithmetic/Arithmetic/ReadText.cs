using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Arithmetic
{
    class ReadText
    {
        public string path { get; set; }
        public string dpath { get; set; }
        private StreamReader _sr {get;set;}
        public ReadText()
        {
            path = "D:\\Data\\TIC\\Arithmetic\\Arithmetic\\codfile_" + DateTime.Now.Hour + ".txt";

            dpath = "D:\\Data\\TIC\\Arithmetic\\Arithmetic\\dicfile_" + DateTime.Now.Hour + ".txt";
        }
        public void CrStreamReader (string filepath)
        {
            StreamReader sr = new StreamReader(filepath);
            _sr = sr;
        }
        public void ClouseSR()
        {
            _sr.Close();
        }
        public (string, string) Readline()
        {
            String line;
            
            try
            {
                
                line = _sr.ReadLine();
               
                
                if (line != null)
                {
                    return (line, null);
                }
                {
                    return (null, "end");
                }
            }
            catch (Exception e)
            {
                return (null, "Exception: " + e.Message);

            }
        }
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
                    text = text + line;

                }

                //close the file
                sr.Close();
                CrStreamReader(filepath);
                return (text, null);
            }
            catch (Exception e)
            {
                return (null, "Exception: " + e.Message);

            }
        }

        public void WriteDict(string dictonary)
        {
            
            try
            {
                // Create the file, or overwrite if the file exists.
                using (FileStream fs = File.Create(dpath))
                {
                    byte[] info = new UTF8Encoding(true).GetBytes(dictonary+"\n");
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
                using (FileStream fs=new FileStream(path, FileMode.Create))
                {
                    fs.Write(text,0,text.Length);
                 //   sw.BaseStream.Write(zero, 0, zero.Length);
                    fs.Close();
                }
            } 
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
        public void WriteText(string text)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(dpath, true, System.Text.Encoding.Default))
                {
                    sw.WriteLine(text+'\n' + '\n');
                    sw.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

    }
}

