using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.Array
{
    public static class ArrayExtensions
    {
        /// <summary>
        /// Get the intersection part of of two arrays, the orginal arrays will be sorted first.
        /// </summary>
        /// <typeparam name="T">Array element typ.e</typeparam>
        /// <param name="lhs">The input array.</param>
        /// <param name="rhs">The input array.</param>
        /// <returns>A IEnumerable<T> of the intersection</returns>
        public static IEnumerable<T> GetIntersection<T>(this T[] lhs, T[] rhs) where T : IComparable
        {
            if (lhs == null || lhs.Length == 0 || rhs == null || rhs.Length == 0)
                yield break;
            System.Array.Sort(lhs);
            System.Array.Sort(rhs);
            int p = 0, q = 0;
            while(p < lhs.Length || q < rhs.Length)
            {
                var l = lhs[Math.Min(p, lhs.Length-1)];
                var r = rhs[Math.Min(q, rhs.Length-1)];
                int compare = l.CompareTo(r);
                if (compare < 0)
                {
                    p++;
                }
                else if (compare > 0)
                {
                    q++;
                }
                else
                {
                    p++;
                    q++;
                    yield return l;
                }
            }            
        }

        /// <summary>
        /// Get the intersection part of of two arrays in O((n+m)lg(m)) time.
        /// </summary>
        /// <typeparam name="T">Array element typ.e</typeparam>
        /// <param name="lhs">The input array.</param>
        /// <param name="rhs">The input array.</param>
        /// <returns>A IEnumerable<T> of the intersection</returns>
        public static IEnumerable<T> GetIntersection2<T>(this T[] lhs, T[] rhs) where T : IComparable
        {
            if (lhs == null || lhs.Length == 0 || rhs == null || rhs.Length == 0)
                yield break;
            T[] shorter = null;
            T[] longer = null;
            if (lhs.Length <= rhs.Length)
            {
                shorter = lhs;
                longer = rhs;
            }
            else
            {
                shorter = rhs;
                longer = lhs;
            }
            System.Array.Sort(shorter);
            foreach (T i in longer)
            {
                if(shorter.BinarySearch(i, isSorted: true) != -1)
                    yield return i;
            }
        }

        /// <summary>
        /// Search specified element in an array
        /// </summary>
        /// <typeparam name="T">The element type of the array.</typeparam>
        /// <param name="a">The array to be searched.</param>
        /// <param name="x">The target element.</param>
        /// <param name="isSorted">Indicating if the array object is sorted already.</param>
        /// <returns>Returns a zero-based index of the target element, or otherwise if not found returns -1.</returns>
        public static int BinarySearch<T>(this T[] a, T x, bool isSorted = false) where T : IComparable
        {
            if(!isSorted)
                System.Array.Sort(a);
            int left = 0;
            int right = a.Length - 1;
            while (left <= right)
            {
                int mid = left + (right - left) / 2;
                int diff = a[mid].CompareTo(x);
                if (diff == 0)
                {
                    return mid;
                }
                else if (diff < 0)
                {
                    left = mid + 1;
                }
                else
                {
                    right = mid - 1;
                }
            }
            return -1;
        }
    }
}
