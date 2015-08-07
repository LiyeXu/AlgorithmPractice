using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.String
{
    public static class StringChecking
    {
        /// <summary>
        /// Count the words in a string.
        /// </summary>
        /// <param name="str">A string to be counted.</param>
        /// <param name="separators">Word separators array.</param>
        /// <returns>The number of words in the string.</returns>
        public static int CountWords(this System.String str, params char[] separators)
        {
            int count = 0;
            bool inWord = false;
            foreach (char c in str)
            {
                if (!inWord && !separators.Contains(c))
                {
                    count++;
                    inWord = true;
                }
                if (inWord && separators.Contains(c))
                {
                    inWord = false; 
                }
            }
            return count;
        }

        /// <summary>
        /// Check if a string contains duplicate characters.
        /// </summary>
        /// <param name="str">A string to be checked.</param>
        /// <returns>Returns false if all characters in the string is unique, otherwise true.</returns>
        public static bool HasDuplicateChar(this System.String str)
        {
            if (System.String.IsNullOrEmpty(str))
            {
                throw new ArgumentOutOfRangeException("str");
            }
            bool[] occur = Enumerable.Repeat(element: false, count: 256).ToArray();
            foreach (char c in str)
            {
                if (occur[c])
                    return true;
                occur[c] = true;
            }
            return false;
        }
    }
}