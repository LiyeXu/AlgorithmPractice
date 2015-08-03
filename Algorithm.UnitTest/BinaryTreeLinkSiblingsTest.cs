using System;
using Algorithm.Graph;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Diagnostics;
using Algorithm.Tree;

namespace Algorithm.UnitTest
{
    [TestClass]
    public class BinaryTreeLinkSiblingsTest
    {
        [TestMethod, TestCategory("Tree")]
        public void LinkSiblingsTest()
        {
            var tree = new BinaryTree<string>("L0_root");
            tree.LeftChild = new BinaryTree<string>("L1_0");
            tree.RightChild = new BinaryTree<string>("L1_1");
            tree.LeftChild.RightChild = new BinaryTree<string>("L2_0");
            tree.RightChild.RightChild = new BinaryTree<string>("L2_1");
            tree.LinkSiblings();
            Assert.AreEqual(tree.RightChild.RightChild, tree.LeftChild.RightChild.NextSibling);
        }
    }
}
