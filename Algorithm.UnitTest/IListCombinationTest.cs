using System;
using Algorithm.Graph;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Diagnostics;
using Algorithm.Combinatorics;
using System.Collections;

namespace Algorithm.UnitTest
{
    [TestClass]
    public class IListCombinationTest
    {
        [TestMethod, TestCategory("Combinatorics")]
        public void PermutationTest()
        {
            var data = Enumerable.Range(1, 7).ToList();
            foreach (var entry in data.Permute(7))
            {
                foreach (var element in entry)
                {
                    Debug.Write(element + " ");
                }
                Debug.WriteLine("");
            }
        }

        [TestMethod, TestCategory("Combinatorics")]
        public void CombinationTest()
        {
            var data = Enumerable.Range(1, 7).ToList();
            foreach (var entry in data.Combine(3))
            {
                foreach (var element in entry)
                {
                    Debug.Write(element + " ");
                }
                Debug.WriteLine("");
            }
        }
    }
}
