﻿using System;
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
            LinkSiblings(h);
        }
    }
}