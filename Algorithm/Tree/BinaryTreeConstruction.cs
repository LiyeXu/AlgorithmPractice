using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Algorithm.Graph;

namespace Algorithm.Tree
{
    public static class BinaryTreeConstruction
    {
        public static void LinkSiblings<T>(this BinaryTree<T> tree)
        {
            if (tree == null)
                return;
            IBinaryTree<T> p = tree;
            IBinaryTree<T> h = null;
            IBinaryTree<T> c = null;
            while (p != null)
            {
                if (p.LeftChild != null)
                {
                    if (h == null)
                    {
                        h = p.LeftChild;
                        c = h;
                    }
                    else
                    {
                        c.NextSibling = p.LeftChild;
                        c = c.NextSibling;
                    }
                }
                if (p.RightChild != null)
                {
                    if (h == null)
                    {
                        h = p.RightChild;
                        c = h;
                    }
                    else
                    {
                        c.NextSibling = p.RightChild;
                        c = c.NextSibling;
                    }
                }
                p = p.NextSibling;
            }
            LinkSiblings(h as BinaryTree<T>);
        }
    }
}
