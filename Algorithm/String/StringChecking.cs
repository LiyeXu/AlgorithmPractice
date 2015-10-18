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
        
        public static int IndexOfRabinKarp(this System.String str, System.String s)
        {
            if (string.IsNullOrEmpty(s))
                return 0;
            int w = s.Length;
            if (str.Length < w)
                return -1;
            int patternHash = Hash(s, 0, s.Length);
            int n = str.Length - w + 1;
            int hash = -1;
            for (int i = 0; i < n; i++)
            {
                hash = Hash(str, i, i + w, hash);
                if (hash != patternHash)
                    continue;
                int j = 0;
                while (j < w)
                {
                    if (str[i+j] != s[j])
                        break;
                    j++;
                }
                if (j == w)
                    return i;
            }            
            return -1;
        }

        private const int DefaultHashAlpha = 10;

        public static int Hash(string s, int start, int end)
        {
            if (start < 0 || start >= s.Length || start > end)
                throw new ArgumentOutOfRangeException("start");
            if (end < 0 || end > s.Length)
                throw new ArgumentOutOfRangeException("end");
            int result = (int)s[start];
            int alpha = 1;
            for (int i = start + 1; i < end; i++)
            {
                alpha *= DefaultHashAlpha;
                result += alpha * s[i];
            }
            return result;
        }

        private static Dictionary<int, int> powerCache = new Dictionary<int, int>();

        public static int Hash(string s, int start, int end, int priorHash)
        {
            if (priorHash == -1)
                return Hash(s, start, end);
            if (start < 1 || start >= s.Length || start > end)
                throw new ArgumentOutOfRangeException("start");
            if (end < 1 || end > s.Length)
                throw new ArgumentOutOfRangeException("end");
            int result = priorHash;
            result -= (int)s[start - 1];
            result /= DefaultHashAlpha;
            int exp = end - start - 1;
            int p = 0;
            if (powerCache.ContainsKey(exp))
                p = powerCache[exp];
            else
            {
                p = (int)Math.Pow(DefaultHashAlpha, exp);
                powerCache.Add(exp, p);
            }
            result += p * s[end - 1];
            return result;
        }
    }
}