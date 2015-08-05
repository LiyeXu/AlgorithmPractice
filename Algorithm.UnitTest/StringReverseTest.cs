using System;
using Algorithm.Graph;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Diagnostics;
using Algorithm.String;

namespace Algorithm.UnitTest
{
    [TestClass]
    public class StringReverseTest
    {
        [TestMethod, TestCategory("String"), TestCategory("Recursion")]
        public void ReverseTest()
        {
            string text;
            string actual;
            text = "123456789";
            actual = text.Reverse();
            //actual = new string(text.Reverse<char>().ToArray());
            Debug.WriteLine(actual);
            Assert.AreEqual("987654321", actual);
        }
    }
}
