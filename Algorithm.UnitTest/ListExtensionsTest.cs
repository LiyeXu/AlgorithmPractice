using System;
using Algorithm.Graph;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Diagnostics;
using Algorithm.List;
using System.Collections.Generic;

namespace Algorithm.UnitTest
{
    [TestClass]
    public class ListExtensionsTest
    {       
        [TestMethod, TestCategory("List")]
        public void SortTest()
        {
            var timer = new Stopwatch();
            int size = 10;
            size *= 1024 * 1024;
            var list = new List<int>(Enumerable.Range(0, size).Reverse());
            timer.Start();
            list.Sort();
            timer.Stop();
            Debug.WriteLine(timer.Elapsed.TotalSeconds);            
            var list2 = new List<int>(Enumerable.Range(0, size).Reverse());

            timer.Start();
            list2.QuickSort();
            timer.Stop();
            Debug.WriteLine(timer.Elapsed.TotalSeconds);
            for(int i = 0; i < list.Count; i++)
            {
                //Debug.WriteLine(list2[i]);
                Assert.AreEqual(list[i], list2[i], string.Format("Checking element {0}", i));
            }
        }
    }
}
