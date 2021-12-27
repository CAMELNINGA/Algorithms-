using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Text;

namespace Decoder
{
    class ReadText
    {
        public string path { get; set; }
        private StreamReader _sr { get; set; }
        private string filepath { get; set; }
        public ReadText()
        {
            path = "D:\\Data\\TIC\\Arithmetic\\Arithmetic\\decodfile_" + DateTime.Now.Hour + ".txt";
        }
        public void CrStreamReader(string filepath)
        {
            this.filepath = filepath;
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
        public (string, string, string) ReadDict(string dictpath,string filepath)
        {
            String line;
            String text = "";
            
            try
            {
                string tex = "";
                //Pass the file path and file name to the StreamReader constructor
                CrStreamReader(dictpath);

                //Read the first line of text
                line = _sr.ReadLine();
                //Continue to read until you reach end of file
                while (line != null)
                {
                    string line1 = line;
                    //write the line to console window
                    text = text + "\n" + line;
                    //Read the next line
                    line = _sr.ReadLine();
                    
                    if (line1=="" && line == "")
                    {
                        
                        
                        _sr.Close();
                       tex= Readtext(filepath);
                        line = null;
                       
                        
                    }

                }

                
                
                return (text, tex, null);
            }
            catch (Exception e)
            {
                return (null, null,"Exception: " + e.Message);

            }
        }

        string Readtext(string path)
        {
            byte[] buffer = File.ReadAllBytes(path);
            BigInteger text = new BigInteger(buffer);
            string te = text.ToString();
            return te;
        }
        public (string, string) Readtext()
        {
           
            String text = "";
            try
            {
                //Pass the file path and file name to the StreamReader constructor
               
                //Read the first line of text
                
                byte[] bytes =File.ReadAllBytes(filepath);
                
                text = Encoding.UTF8.GetString(bytes);



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
                using (FileStream fs = File.Create(path))
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

        public void WriteText(string text)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(path, true, System.Text.Encoding.Default))
                {
                    sw.Write(text + ";");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
        
    }
}
