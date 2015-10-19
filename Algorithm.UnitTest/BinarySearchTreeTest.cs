using System;
using Algorithm.Graph;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Diagnostics;
using Algorithm.Tree;

namespace Algorithm.UnitTest
{
    [TestClass]
    public class BinarySearchTreeTest
    {
        private BinarySearchTree<int> tree;

        [TestInitialize]
        public void Init()
        {
            tree = new BinarySearchTree<int>(5);
            tree.LeftChild = new BinarySearchTree<int>(3);
            tree.RightChild = new BinarySearchTree<int>(8);
            tree.LeftChild.LeftChild = new BinarySearchTree<int>(1);
            tree.RightChild.RightChild = new BinarySearchTree<int>(9);
            AssertIsValid(tree);
        }

        [TestMethod, TestCategory("Tree")]
        public void FindTest()
        {
            int x = 8;
            var actual = tree.Find(x);
            Assert.AreEqual(x, actual.Payload);
            int y = 999;
            actual = tree.Find(y);
            Assert.AreEqual(null, actual);
        }

        [TestMethod, TestCategory("Tree")]
        public void InsertTest()
        {
            tree.Insert(3);
            Assert.AreEqual(3, tree.LeftChild.LeftChild.RightChild.Payload);
            AssertIsValid(tree);
        }

        [TestMethod, TestCategory("Tree")]
        public void MaxTest()
        {
            var actual = tree.Max();
            Assert.AreEqual(9, actual);
        }

        [TestMethod, TestCategory("Tree")]
        public void MinTest()
        {
            var actual = tree.Min();
            Assert.AreEqual(1, actual);
        }

        public void AssertIsValid(BinarySearchTree<int> tree)
        {
            bool isValid = true;
            tree.TraverseInOrder(node =>
                {
                    isValid =
                        (node.LeftChild == null || node.LeftChild.Payload <= node.Payload) &&
                        (node.RightChild == null || node.RightChild.Payload > node.Payload);
                }
            );
            Assert.AreEqual(true, isValid);
        }
    }
}