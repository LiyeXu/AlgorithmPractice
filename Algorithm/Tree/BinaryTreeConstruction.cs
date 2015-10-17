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
        /// <summary>
        /// Link all tree nodes of the same level with NextSibling property.
        /// </summary>
        /// <typeparam name="T">Tree element type.</typeparam>
        /// <param name="tree">A tree object to be processed.</param>
        public static void LinkSiblings<T>(this IBinaryTree<T> tree)
        {
            if (tree == null)
                return;
            IBinaryTree<T> parent = tree;
            IBinaryTree<T> head = null;
            IBinaryTree<T> current = null;
            Action<IBinaryTree<T>> link = node => {
                if (node == null)
                    return;
                if (head == null)
                {
                    head = node;
                    current = head;
                }
                else
                {
                    current.NextSibling = node;
                    current = current.NextSibling;
                }
            };
            while (parent != null)
            {
                link(parent.LeftChild);
                link(parent.RightChild);
                parent = parent.NextSibling;
            }
            LinkSiblings(head);
        }


    }
}
