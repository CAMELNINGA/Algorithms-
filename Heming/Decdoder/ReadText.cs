using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Decdoder
{
    class ReadText
    {
        public (byte[], string) Readtext(string filepath)
        {

         
            try
            {
                //Pass the file path and file name to the StreamReader constructor

                //Read the first line of text

                byte[] bytes = File.ReadAllBytes(filepath);

                



                return (bytes, null);
            }
            catch (Exception e)
            {
                return (null, "Exception: " + e.Message);

            }
        }
    }
}
