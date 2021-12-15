using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgaritmHaffmana
{
    class Reader
    {
        Dictionary<char, int> _count;
        List<TreeNode> node;
        public List<TreeNode> Count(char[] chr)
        {
            _count = new Dictionary<char, int>();
            for (int i = 0; i < chr.Length; i++)
            {
                if (_count.Keys.Contains(Convert.ToChar(chr[i])))
                {
                    _count[Convert.ToChar(chr[i])]++ ;
                }
                else
                {
                    _count.Add(Convert.ToChar(chr[i]), 1);
                }
            }
            node = new List<TreeNode>();
            foreach(var item in _count)
            {
                node.Add(new TreeNode(item.Key, null, item.Value));
            }
            node = node.OrderBy(n=>n.Frequency).ToList();
            return node;
        }
    }
}
