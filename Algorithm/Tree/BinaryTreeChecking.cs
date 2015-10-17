using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Algorithm.Graph;

namespace Algorithm.Tree
{
    public static class BinaryTreeChecking
    {
        /// <summary>
        /// Find the lowest common ancestor node of two given nodes of a tree.
        /// </summary>
        /// <typeparam name="T">Tree element type.</typeparam>
        /// <param name="tree">The tree to be searched.</param>
        /// <param name="x">The first node.</param>
        /// <param name="y">The second node.</param>
        /// <returns></returns>
        public static IBinaryTree<T> FindLowestCommonAncestor<T>(this IBinaryTree<T> tree, IBinaryTree<T> x, IBinaryTree<T> y)
        {
            if (tree == null)
                return null;
            if (tree == x || tree == y)
                return tree;
            var L = tree.LeftChild.FindLowestCommonAncestor(x, y);
            var R = tree.RightChild.FindLowestCommonAncestor(x, y);
            if (L != null && R != null)
                return tree;
            return L ?? R;
        }
    }
}
