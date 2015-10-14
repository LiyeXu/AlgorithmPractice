using System;
using Algorithm.Graph;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Diagnostics;
using Algorithm.Tree;

namespace Algorithm.UnitTest
{
    [TestClass]
    public class ConceptualBinaryTreeTest
    {
        [TestMethod, TestCategory("Tree")]
        public void FindLCATest()
        {
            var tree = new ConceptualBinaryTree<string>("L0_root");
            tree.LeftChild = new ConceptualBinaryTree<string>("L1_0");
            tree.RightChild = new ConceptualBinaryTree<string>("L1_1");
            tree.LeftChild.RightChild = new ConceptualBinaryTree<string>("L2_0");
            tree.RightChild.RightChild = new ConceptualBinaryTree<string>("L2_1");
            var root = tree.FindLowestCommonAncestor(tree.LeftChild.RightChild, tree.RightChild.RightChild);
            Assert.AreEqual(tree, root);
        }

        [TestMethod, TestCategory("Tree")]
        public void LinkSiblingsTest()
        {
            var tree = new ConceptualBinaryTree<string>("L0_root");
            tree.LeftChild = new ConceptualBinaryTree<string>("L1_0");
            tree.RightChild = new ConceptualBinaryTree<string>("L1_1");
            tree.LeftChild.RightChild = new ConceptualBinaryTree<string>("L2_0");
            tree.RightChild.RightChild = new ConceptualBinaryTree<string>("L2_1");
            tree.LinkSiblings();
            Assert.AreEqual(tree.RightChild.RightChild, tree.LeftChild.RightChild.NextSibling);
        }
    }
}
