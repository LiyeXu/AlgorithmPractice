using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Algorithm.Graph;

namespace Algorithm.Tree
{
    public class BinarySearchTree<T> : ConceptualBinaryTree<T>, IBinaryTree<T>
    {
        public BinarySearchTree(T payload)
            : base(payload)
        { 
        }

        /// <summary>
        /// Find specified element from the current binary search tree object.
        /// </summary>
        /// <typeparam name="T">The element type of the tree.</typeparam>
        /// <param name="x">The value of the element to be searched</param>
        /// <returns>Returns the first tree node with the same element value if any, otherwise returns null</returns>
        public IBinaryTree<T> Find<T>(T x) where T : IComparable
        {
            var cur = this as IBinaryTree<T>;
            while (cur != null)
            {
                int diff = x.CompareTo(cur.Payload);
                if (diff == 0)
                    return cur;
                cur = diff < 0 ? cur.LeftChild : cur.RightChild; 
            }
            return null;
        }

        /// <summary>
        /// Insert a new node into the current binary search tree with specified value.
        /// </summary>
        /// <typeparam name="T">The element type of the tree.</typeparam>
        /// <param name="x">The value of the new node.</param>
        public void Insert<T>(T x) where T : IComparable
        {
            IBinaryTree<T> node = new BinarySearchTree<T>(x);
            var cur = this as IBinaryTree<T>;
            IBinaryTree<T> parent = null;
            while (cur != null)
            {
                parent = cur;
                if (node.Payload.CompareTo(cur.Payload) <= 0)
                    cur = cur.LeftChild;
                else
                    cur = cur.RightChild;                
            }
            if (node.Payload.CompareTo(parent.Payload) <= 0)
                parent.LeftChild = node;
            else
                parent.RightChild = node;
        }

        /// <summary>
        /// Get the minimal value of the current binary search tree.
        /// </summary>
        /// <returns>The minimal value.</returns>
        public T Min()
        {
            var cur = this as IBinaryTree<T>;
            while (cur.LeftChild != null)
            {
                cur = cur.LeftChild;
            }
            return cur.Payload;
        }

        /// <summary>
        /// Get the maximum value of the current binary search tree.
        /// </summary>
        /// <returns>The maximum value.</returns>
        public T Max()
        {
            var cur = this as IBinaryTree<T>;
            while (cur.RightChild != null)
            {
                cur = cur.RightChild;
            }
            return cur.Payload;
        }
    }
}
