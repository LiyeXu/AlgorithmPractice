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
        public void CountTest()
        {
            string text;
            int words;
            text = "     test.one  two   three     .";
            words = text.CountWords(' ', ',', '.');
            Assert.AreEqual(4, words);
        }

        [TestMethod, TestCategory("String")]
        public void IsAllCharUniqueTest()
        {
            bool actual = "abcdef12345&\t\b\0".HasDuplicateChar();
            Assert.IsFalse(actual);
            actual = "abcdef12345&\t\b\0a".HasDuplicateChar();
            Assert.IsTrue(actual);
        }


        [TestMethod, TestCategory("String")]
        public void HashTest()
        {
            string text = "1234567890";
            string patternMismatching = "abc";
            string patternMatching = "456";

            int hash = text.Hash(3, 6);
            int adjacencyHash = text.Hash(3, 6, StringChecking.Hash(text, 2, 5));
            int patternHash = patternMatching.Hash(0, patternMatching.Length);
            Debug.WriteLine("hash:", hash);
            Debug.WriteLine("adjacency hash:", adjacencyHash);
            Debug.WriteLine("pattern hash:", patternHash);
            Assert.AreEqual(hash, adjacencyHash);
            Assert.AreEqual(adjacencyHash, patternHash);
        }

        [TestMethod, TestCategory("String")]
        public void IndexOfTest()
        {
            string text = string.Join("", from i in Enumerable.Range(1, 65536) select i.ToString());
            string patternMismatching = "abc";
            string patternMatching = "7789";

            int actualMismatching = text.IndexOfRabinKarp(patternMismatching);
            int actualMatching = text.IndexOfRabinKarp(patternMatching);
            Debug.WriteLine(actualMismatching);
            Debug.WriteLine(actualMatching);
            Assert.AreEqual(-1, actualMismatching);
            Assert.AreEqual(patternMatching, text.Substring(actualMatching, patternMatching.Length));
        }
    }
}
