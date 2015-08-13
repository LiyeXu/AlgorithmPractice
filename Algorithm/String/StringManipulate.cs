using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.String
{
    public static class StringManipulate
    {
        /// <summary>
        /// Reverse each chars in a string recursively.
        /// </summary>
        /// <param name="str">A string to be reverted.</param>
        /// <returns>The reverted string.</returns>
        public static System.String RecursivelyReverse(this System.String str)
        {
            if (str == null || str.Length <= 1)
                return str;
            var buffer = new StringBuilder(str.Length);
            RecursivelyReverseImpl(str, 0, buffer);
            return buffer.ToString();
        }

        private static void RecursivelyReverseImpl(System.String str, int idx, StringBuilder buffer)
        {
            if (idx == str.Length)
                return;
            RecursivelyReverseImpl(str, idx + 1, buffer);
            buffer.Append(str[idx]);
        }

        /// <summary>
        /// Reverse each chars in a string.
        /// </summary>
        /// <param name="str">A string to be reverted.</param>
        /// <returns>The reverted string.</returns>
        public static System.String Reverse(this System.String str)
        {
            if (System.String.IsNullOrWhiteSpace(str))
            {
                return str;
            }
            var buffer = new StringBuilder(str);
            int left = 0, right = str.Length - 1;
            char swapTmp;
            while (left < right)
            {
                swapTmp = buffer[left];
                buffer[left] = buffer[right];
                buffer[right] = swapTmp;
                left++;
                right--;
            }
            System.String reversed = buffer.ToString();
            return reversed;
        }
    }
}