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
    public class ConceptualSinglyLinkedListConstructionTest
    {
        [TestMethod, TestCategory("LinkedList")]
        public void AddRangeTest()
        {
            int[] data = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            var list = new ConceptualSinglyLinkedList<int>(0);
            list.AddRange(data);
            Assert.AreEqual(data[2], list.Next.Next.Payload);
        }
    }
}
