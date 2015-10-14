using System;
using Algorithm.Graph;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Diagnostics;
using Algorithm.Array;
using System.Numerics;
using Algorithm.Numerics;

namespace Algorithm.UnitTest
{
    [TestClass]
    public class NumericsTest
    {
        [TestMethod, TestCategory("Numerics")]
        public void FibbonacciTest()
        {
            var f = Calculate.Fibbonacci(65536);
            Assert.AreEqual(Calculate.Fibbonacci2(65536), f);
            Debug.WriteLine(f);
        }

        [TestMethod, TestCategory("Numerics")]
        public void PhiTest()
        {
            double phi = 0;
            for (int i = 1; i < 10; i++)
            {
                phi = Calculate.Phi((int)Math.Pow(2,i));                
            }
            Assert.AreEqual(0, phi - (1 + Math.Sqrt(5)) / 2);
        }
    }
}
