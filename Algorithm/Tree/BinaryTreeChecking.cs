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
        public static IBinaryTree<T> FindLowestCommonAncestor<T>(this IBinaryTree<T> tree, IBinaryTree<T> left, IBinaryTree<T> right)
        {
            if (tree == null)
                return null;
            if (tree == left || tree == right)
                return tree;
            var L = tree.LeftChild.FindLowestCommonAncestor(left, right);
            var R = tree.RightChild.FindLowestCommonAncestor(left, right);
            if (L != null && R != null)
                return tree;
            return L != null ? L : R;
        }
    }
}
