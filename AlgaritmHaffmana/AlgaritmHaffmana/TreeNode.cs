using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgaritmHaffmana
{
    public struct TreeNode
    {
        public char Chars { get; set; }

        public string Code { get; set; }

        public int Frequency { get; set; }

        public TreeNode(char chars,string code, int frequency)
        {
            Chars = chars;
            Code = code;
            Frequency = frequency;
            
        }

        public void TypeCode( string str)
        {
            Code = str + Code;
        } 

        public TreeNode UpFreeq(int k)
        {
            
            Frequency = k;
            return this;
        }
    }
}
