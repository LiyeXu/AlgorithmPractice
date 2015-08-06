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
    public class ConceptualSinglyLinkedListManipulationTest
    {
        [TestMethod, TestCategory("LinkedList")]
        public void ReverseTest()
        {
            int[] data = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            var list = new ConceptualSinglyLinkedList<int>(int.MinValue);
            list.AddRange(data);
            list.Reverse();
            var p = list as ISinglyLinkedList<int>;
            int i = 0;
            while(p.Next != null)
            {
                Assert.AreEqual(data[data.Length - i - 1], p.Payload);
                p = p.Next;
                i++;
            }                
        }
    }
}
