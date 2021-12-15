using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgaritmHaffmana
{
    class Haffman
    {
        
        public  Haffman(List<TreeNode> treeNodes)
        {
            List<Tree<TreeNode>> tree = new List<Tree<TreeNode>>();
            for(int i = 0; i < treeNodes.Count; i++)
            {
                tree.Add(new Tree<TreeNode>(treeNodes[i]));
            }
            Start(tree);
        }
        public void Start(List<Tree<TreeNode>> node)
        {
            Console.WriteLine("Start" );
            while (node.Count != 1)
            {
                Tree<TreeNode> tree = new Tree<TreeNode>(new TreeNode());
                tree.AddChild(node[0].Data);
                tree.AddChild(node[1].Data);

                tree.Data.UpFreeq(node[0].Data.Frequency + node[1].Data.Frequency);
                Console.WriteLine("Children 1" + node[0].Data.Frequency);
                node.RemoveAt(0);
                Console.WriteLine("Children 2" + node[0].Data.Frequency);
                node.RemoveAt(0);
                node.Add(tree);
            }
            Console.WriteLine(node.Count);
            Console.WriteLine(node[0].Data.Frequency);
            Console.WriteLine("End");
            Console.ReadLine();


        }
    }
}
