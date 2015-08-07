using System;
using Algorithm.Graph;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Diagnostics;
using Algorithm.String;

namespace Algorithm.UnitTest
{
    [TestClass]
    public class StringCheckingTest
    {
        [TestMethod, TestCategory("String")]
        public void RemoveTest()
        {
            string text;
            int words;
            text = "     test.one  two   three     .";
            words = text.CountWords(' ', ',', '.');
            Assert.AreEqual(4L, words);
        }

        [TestMethod, TestCategory("String")]
        public void IsAllCharUniqueTest()
        {
            bool actual = "abcdef12345&\t\b\0".HasDuplicateChar();
            Assert.IsFalse(actual);
            actual = "abcdef12345&\t\b\0a".HasDuplicateChar();
            Assert.IsTrue(actual);
        }
    }
}
