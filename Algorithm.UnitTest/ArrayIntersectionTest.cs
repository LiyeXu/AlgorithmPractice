using System;
using Algorithm.Graph;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Diagnostics;
using Algorithm.Array;

namespace Algorithm.UnitTest
{
    [TestClass]
    public class ArrayIntersectionTest
    {
        [TestMethod, TestCategory("Array")]
        public void IntersectionTest()
        {
            int[] lhs = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            int[] rhs = new[] { 1, 3, 5, 7, 9 };
            //var intersection = lhs.GetIntersection(rhs);
            var intersection = rhs.GetIntersection(lhs);
            int idx = 0;
            foreach (var i in intersection)
            {
                Debug.WriteLine(i);
                Assert.AreEqual(rhs[idx], i);
                idx++;
            }
        }
    }
}
