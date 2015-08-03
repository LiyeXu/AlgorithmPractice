using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.String
{
    public static class StringCount
    {
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