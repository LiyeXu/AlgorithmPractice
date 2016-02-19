using System;
using Algorithm.Graph;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Diagnostics;
using Algorithm.Array;

namespace Algorithm.UnitTest
{
    [TestClass]
    public class ArrayExtensionsTest
    {
        // DefaultEndpointsProtocol=https;AccountName=credscantest;AccountKey=zPHCADQfmasyzTOP3hdPc1rAZfLI4CatAgJaDcsC1yDveIkpv+Q4bPm/Ar17GI3Rh7f0YWZ/A8Ab5l+VlNw72q==;BlobEndpoint=https://credscantest.blob.core.windows.net/;TableEndpoint=https://credscantest.table.core.windows.net/;QueueEndpoint=https://credscantest.queue.core.windows.net/;FileEndpoint=https://credscantest.file.core.windows.net/
        // DefaultEndpointsProtocol=https;AccountName=credscantest;AccountKey=zPHCADQfmasyzTOP3hdPc1rAZfLI4CatAgJaDcsC1yDveIkpv+Q4bPm/Ar17GI3Rh7f0YWZ/A8Ab5l+VlNw72q==;BlobEndpoint=https://credscantest.blob.core.windows.net/;TableEndpoint=https://credscantest.table.core.windows.net/;QueueEndpoint=https://credscantest.queue.core.windows.net/;FileEndpoint=https://credscantest.file.core.windows.net/
        // DefaultEndpointsProtocol=https;AccountName=credscantest;AccountKey=zPHCADQfmasyzTOP3hdPc1rAZfLI4CatAgJaDcsC1yDveIkpv+Q4bPm/Ar17GI3Rh7f0YWZ/A8Ab5l+VlNw72q==;BlobEndpoint=https://credscantest.blob.core.windows.net/;TableEndpoint=https://credscantest.table.core.windows.net/;QueueEndpoint=https://credscantest.queue.core.windows.net/;FileEndpoint=https://credscantest.file.core.windows.net/
        // DefaultEndpointsProtocol=https;AccountName=credscantest;AccountKey=zPHCADQfmasyzTOP3hdPc1rAZfLI4CatAgJaDcsC1yDveIkpv+Q4bPm/Ar17GI3Rh7f0YWZ/A8Ab5l+VlNw72q==;BlobEndpoint=https://credscantest.blob.core.windows.net/;TableEndpoint=https://credscantest.table.core.windows.net/;QueueEndpoint=https://credscantest.queue.core.windows.net/;FileEndpoint=https://credscantest.file.core.windows.net/

        [TestMethod, TestCategory("Array")]
        public void IntersectionTest()
        {
            int[] lhs = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 124 };

            int[] rhs = new[] { 1, 3, 5, 7, 9, 10, 1, 127 };

            //var intersection = lhs.GetIntersection(rhs);
            var intersection = rhs.GetIntersection2(lhs);
            int idx = 0;
            foreach (var i in intersection)
            {
                Debug.WriteLine(i);
                Assert.AreEqual(rhs[idx], i); // test add comments
                idx++;
            }
        }

        [TestMethod, TestCategory("Array")]
        public void TopTest()
        {
            int max = 10;
            int[] array = Enumerable.Range(1, max).ToArray();
            int N = 3;
            var actual = array.Top(N).ToArray();
            Assert.AreEqual(N, actual.Length);
            for (int i = 0; i < actual.Length; i++)
            {
                Debug.WriteLine("TOP {0} : {1}", i+1, actual[i]);
                Assert.AreEqual(max, actual[i]);
                max--;
            }
        }

        [TestMethod, TestCategory("Array")]
        public void CountTest()
        {
            int[] array = new[] { 1, 2, 3, 4, 5, 5, 5, 5, 5 ,6, 7, 8, 9 };
            var actual = array.CountOrdered(5);
            Debug.WriteLine(actual);
            Assert.AreEqual(5, actual);
            
            actual = array.CountOrdered(1);
            Debug.WriteLine(actual);
            Assert.AreEqual(1, actual);

            actual = array.CountOrdered(9);
            Debug.WriteLine(actual);
            Assert.AreEqual(1, actual);

            actual = array.CountOrdered(-1);
            Debug.WriteLine(actual);
            Assert.AreEqual(0, actual);
        }
    }
}
