using System;
using Algorithm.Graph;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Diagnostics;
using Algorithm.String;

namespace Algorithm.UnitTest
{
    [TestClass]
    public class StringManipulationTest
    {
        [TestMethod, TestCategory("String")]
        public void ReverseTest()
        {
            string text = "123456789";
            string actual1 = text.Reverse();
            string actual2 = text.RecursivelyReverse();
            //actual1 = new string(text.Reverse<char>().ToArray());
            Debug.WriteLine(actual1);
            Debug.WriteLine(actual2);
            Assert.AreEqual("987654321", actual1);
            Assert.AreEqual("987654321", actual2);
        }

        [TestMethod, TestCategory("String")]
        public void RotateTest()
        {
            string text = "123456789";
            string actual = text.Rotate(4);
            Debug.WriteLine(actual);
            Assert.AreEqual("678912345", actual);
        }
    }
}
