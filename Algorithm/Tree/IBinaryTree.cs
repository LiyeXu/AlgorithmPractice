using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Algorithm.Graph;

namespace Algorithm.Tree
{
    public interface IBinaryTree<T>
    {
        T Payload
        {
            get;
            set;
        }

        IBinaryTree<T> LeftChild
        {
            get;
            set;
        }

        IBinaryTree<T> RightChild
        {
            get;
            set;
        }

        IBinaryTree<T> NextSibling
        {
            get;
            set;
        }
    }
}
