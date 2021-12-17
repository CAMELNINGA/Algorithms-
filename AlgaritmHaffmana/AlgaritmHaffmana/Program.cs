using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgaritmHaffmana
{
    class Program
    {
        static void Main(string[] args)
        {
            string s = "beep boop beer!";
            char[] c = s.ToCharArray();
            Reader read = new Reader();
            List<TreeNode> node = read.Count(c);
            Haffman haffman = new Haffman(node);
            
            
            
        }
    }
}
