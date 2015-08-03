using System;
using Algorithm.Graph;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Diagnostics;
using Algorithm.String;

namespace Algorithm.UnitTest
{
    [TestClass]
    public class StringCountTest
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
    }
}
