using System;
using Algorithm.Graph;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Diagnostics;
using Algorithm.Array;
using Algorithm.LinkedList;

namespace Algorithm.UnitTest
{
    [TestClass]
    public class ConceptualSinglyLinkedListCheckingTest
    {
        [TestMethod, TestCategory("LinkedList")]
        public void FindLoopingNodeTest()
        {
            int[] data = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            var list = new ConceptualSinglyLinkedList<int>(0);
            list.AddRange(data);
            var last = list as ISinglyLinkedList<int>;
            while (last.Next != null)
            {
                last = last.Next;
            }
            last.Next = list.Next;
            var loopingNode = list.FindLoopNode();
            Assert.AreEqual(list.Next, loopingNode);
        }

        [TestMethod, TestCategory("LinkedList")]
        public void FindLastNthNodeTest()
        {
            int[] data = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            var list = new ConceptualSinglyLinkedList<int>(0);
            list.AddRange(data);
            var loopingNode = list.FindLastNthNode(8);
            Assert.AreEqual(list.Next, loopingNode);
        }
    }
}
