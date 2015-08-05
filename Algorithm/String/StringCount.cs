using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.String
{
    public static class StringCount
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
    }
}