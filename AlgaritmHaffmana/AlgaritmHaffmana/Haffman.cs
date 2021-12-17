using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgaritmHaffmana
{
    class Haffman
    {
        
        public   Haffman(List<TreeNode> treeNodes)
        {
            List<Tree<TreeNode>> tree = new List<Tree<TreeNode>>();
            for(int i = 0; i < treeNodes.Count; i++)
            {
                tree.Add(new Tree<TreeNode>(treeNodes[i]));
            }
            Tree<TreeNode>haffman =Start(tree);
            Dictionary<TreeNode, string> code = new Dictionary<TreeNode, string>();
            string node_code= "";
            (haffman, code, node_code) = haffman.ReadTree(haffman, code, node_code);
            Console.WriteLine("Count ={0}",code.Count);
            foreach (KeyValuePair < TreeNode ,string > coding in code){
                Console.WriteLine("Key = {0}, Value = {1}", coding.Key.Chars, coding.Value);
            }
            Console.ReadLine();

        }
        public Tree<TreeNode> Start(List<Tree<TreeNode>> node)
        {
            Console.WriteLine("Start" );
            while (node.Count != 1)
            {
                Tree<TreeNode> tree = new Tree<TreeNode>(new TreeNode());
                tree.AddChild(node[0]);
                tree.AddChild(node[1]);

                tree.Data.UpFreeq(node[0].Data.Frequency + node[1].Data.Frequency);
               
                node.RemoveAt(1);
               
                node.RemoveAt(0);
                node.Add(tree);
            }
            
            return node[0];

        }
    }
}
