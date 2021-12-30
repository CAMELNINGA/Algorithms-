using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Heming
{
    class ReaderText
    {
        public string path { get; set; }
       
        public ReaderText()
        {
            path = "D:\\Data\\TIC\\Heming\\Heming\\codfile_" + DateTime.Now.Hour + ".txt";

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
