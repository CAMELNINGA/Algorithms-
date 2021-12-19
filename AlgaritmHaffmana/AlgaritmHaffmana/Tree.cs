using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgaritmHaffmana
{
    class Tree<T> : IEnumerable<Tree<T>>
    {
        public T Data { get; set; }
        public Tree<T> Parent { get; set; }
        public Tree<T> Children1 { get; set; }
        public Tree<T> Children2 { get; set; }

        public Tree(T data)
        {
            this.Data = data;
            this.Children1 = null;
            this.Children2 = null;
        }

        private void AddParent(Tree<T> parent)
        {
            if (this.Parent == null)
            {
                this.Parent = parent;
            }
            
        }

        public Tree<T> AddChild(Tree<T> child)
        {

            
            if (this.Children1 == null)
            {
                child.AddParent(this);
                this.Children1 = child;        
            }
            else 
            {
                child.AddParent(this);
                this.Children2 = child;
            }
            return this;

        }

        

        public IEnumerator<Tree<T>> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
        
        public (Tree<T>,Dictionary<T, string>, string) ReadTree(Tree<T> node, Dictionary<T , string> keyValues, string code)
       {
            
            if (node.Children1 !=  null)
            {
                code =code+ "0";
                Console.WriteLine("Code_0={0}", code);
                (node, keyValues, code)= ReadTree(node.Children1,keyValues,code);
                code=code.Remove(code.Length-1);
            }
            if (node.Children2 != null)
            {
                code =code+ "1";
                Console.WriteLine("Code_1={0}", code);
                (node, keyValues, code) = ReadTree(node.Children2, keyValues, code);
                code=code.Remove(code.Length-1);
            }

            if ((node.Children1 == null) && (node.Children2 == null))
            {
                Console.WriteLine("Code={0}", code);
                keyValues.Add(node.Data, code);
            }
            return (node.Parent, keyValues, code);

        }
        
       
    }
}
