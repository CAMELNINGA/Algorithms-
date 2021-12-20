using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Decoder
{
    class Reader
    {
        public (string,string, string) Readtext(string filepath)
        {
            String line;
            String text = "";
            String codtext = "";
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
                    
                   
                    //Read the next line
                    line = sr.ReadLine();
                    if (line == "")
                    {
                        line = null;
                        line = sr.ReadLine();
                        codtext = line;
                        while((line != null))
                        {
                            line = sr.ReadLine();
                            codtext = codtext+line;
                        }

                    }
                    else
                    {
                        text = text +"\n"+ line;
                    }
                    

                }

                //close the file
                sr.Close();
                return (text, codtext,null);
            }
            catch (Exception e)
            {
                return (null, null,"Exception: " + e.Message);

            }
        }
    }
}
