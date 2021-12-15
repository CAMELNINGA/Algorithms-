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
        }

        public Tree<T> AddChild(T child)
        {

            
            if (this.Children1 == null)
            {
                Tree<T> childNode = new Tree<T>(child) { Parent = this };
                this.Children1 = childNode;        
            }
            else if (this.Children2 == null)
            {
                Tree<T> childNode = new Tree<T>(child) { Parent = this };
                this.Children1 = childNode;
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
      
        
       
    }
}
