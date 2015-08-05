using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Algorithm.Graph;

namespace Algorithm.Tree
{
    public static class ConceptualBinaryTreeConstruction
    {
        public static void LinkSiblings<T>(this ConceptualBinaryTree<T> tree)
        {
            if (tree == null)
                return;
            IBinaryTree<T> p = tree;
            IBinaryTree<T> h = null;
            IBinaryTree<T> c = null;
            Action<IBinaryTree<T>> link = node => {
                if (node == null)
                    return;
                if (h == null)
                {
                    h = node;
                    c = h;
                }
                else
                {
                    c.NextSibling = node;
                    c = c.NextSibling;
                }
            };
            while (p != null)
            {
                link(p.LeftChild);
                link(p.RightChild);
                p = p.NextSibling;
            }
            LinkSiblings(h as ConceptualBinaryTree<T>);
        }
    }
}
