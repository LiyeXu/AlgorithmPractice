using System;
using Algorithm.Graph;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Diagnostics;
using Algorithm.Combinatorics;
using System.Collections;
using Algorithm.Numerics;
using System.Numerics;

namespace Algorithm.UnitTest
{
    [TestClass]
    public class IListCombinationTest
    {
        [TestMethod, TestCategory("Combinatorics")]
        public void PermutationTest()
        {
            var data = Enumerable.Range(1, 3).ToList();
            var actual = data.Permute(3);
            foreach (var entry in actual)
            {
                foreach (var element in entry)
                {
                    Debug.Write(element + " ");
                }
                Debug.WriteLine("");
            }
            Assert.AreEqual(Series.Fact(data.Count), new BigInteger(actual.Count()));
        }

        [TestMethod, TestCategory("Combinatorics")]
        public void SubsetsTest()
        {
            var data = Enumerable.Range(1, 3).ToList();
            var actual = data.Subsets();
            foreach (var entry in actual)
            {
                Debug.Write("{");
                foreach (var element in entry)
                {
                    Debug.Write(element + " ");
                }
                Debug.WriteLine("}");
            }
            Assert.AreEqual((int)Math.Pow(2, data.Count), actual.Count());
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
