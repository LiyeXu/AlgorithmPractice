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
        public static System.String Reverse(this System.String str)
        {
            if (str == null || str.Length <= 1)
                return str;
            var buffer = new StringBuilder(str.Length);
            ReverseImpl(str, 0, buffer);
            return buffer.ToString();
        }

        private static void ReverseImpl(System.String str, int idx, StringBuilder buffer)
        {
            if (idx == str.Length)
                return;
            ReverseImpl(str, idx+1, buffer);
            buffer.Append(str[idx]);
        }
    }
}