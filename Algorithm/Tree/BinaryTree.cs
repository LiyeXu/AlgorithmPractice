using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Algorithm.Graph;

namespace Algorithm.Tree
{
    public class BinaryTree<T> : Graph<T>, IBinaryTree<T>
    {
        public BinaryTree(T payload) : base(payload)
        { 
        }

        public IBinaryTree<T> LeftChild
        {
            get
            {
                if (base.Neighbors.Count == 0)
                    return null;
                return base.Neighbors[0] as IBinaryTree<T>;
            }
            set
            {
                if (base.Neighbors.Count == 0)
                    base.Neighbors.Add(value as Graph<T>);
                else
                    base.Neighbors[0] = value as Graph<T>;
            }
        }

        public IBinaryTree<T> RightChild
        {
            get
            {
                if (base.Neighbors.Count <= 1)
                    return null;
                return base.Neighbors[1] as IBinaryTree<T>;
            }
            set
            {
                if (base.Neighbors.Count == 0)
                {
                    base.Neighbors.Add(null);
                    base.Neighbors.Add(value as Graph<T>);
                }
                else if (base.Neighbors.Count == 1)
                    base.Neighbors.Add(value as Graph<T>);
                else
                    base.Neighbors[1] = value as Graph<T>;
            }
        }

        public IBinaryTree<T> NextSibling
        {
            get;
            set;
        }
    }
}
