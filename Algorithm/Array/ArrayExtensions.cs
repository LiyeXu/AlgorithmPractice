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
        public static IEnumerable<T> GetIntersection0<T>(this T[] lhs, T[] rhs) where T : IComparable
        {
            return lhs.Intersect(rhs);
        }

        /// <summary>
        /// Get the intersection part of of two arrays, the orginal arrays will be sorted first.
        /// </summary>
        /// <typeparam name="T">Array element typ.e</typeparam>
        /// <param name="lhs">The input array.</param>
        /// <param name="rhs">The input array.</param>
        /// <returns>A IEnumerable<T> of the intersection</returns>
        public static IEnumerable<T> GetIntersection1<T>(this T[] lhs, T[] rhs) where T : IComparable
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
        /// <param name="array">The array to be searched.</param>
        /// <param name="x">The target element.</param>
        /// <param name="isSorted">Indicating if the array object is sorted already.</param>
        /// <returns>Returns a zero-based index of the target element, or otherwise if not found returns -1.</returns>
        public static int BinarySearch<T>(this T[] array, T x, bool isSorted = false) where T : IComparable
        {
            if(!isSorted)
                System.Array.Sort(array);
            int left = 0;
            int right = array.Length - 1;
            while (left <= right)
            {
                int mid = left + ((right - left) >> 1);
                int diff = array[mid].CompareTo(x);
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

        /// <summary>
        /// Find a zero-based index of the lower or upper boundary of a range of repeated elements in the array.
        /// </summary>
        /// <typeparam name="T">Array element type.</typeparam>
        /// <param name="array">The array object to be searched.</param>
        /// <param name="x">The element to be searched with.</param>
        /// <param name="isSorted">Whether the array object is sorted already.</param>
        /// <param name="isFindLowerBoundary">To search the lower or upper boundary.</param>
        /// <returns>Returns the lower or upper boundary of the repeated range if there is one, otherwise returns -1.</returns>
        public static int BinarySearchBoundary<T>(this T[] array, T x, bool isSorted = false, bool isFindLowerBoundary = true) where T : IComparable
        {
            if (!isSorted)
                System.Array.Sort(array);
            int left = 0;
            int right = array.Length - 1;
            while (left <= right)
            {
                int mid = left + ((right - left) >> 1);
                int diff = array[mid].CompareTo(x);
                if (isFindLowerBoundary ? (diff < 0) : (diff <= 0))
                {
                    left = mid + 1;
                }
                else
                {
                    right = mid - 1;
                }
            }
            return left;
        }

        /// <summary>
        /// Count how many occurrences of an specified element x exist in the array object.
        /// </summary>
        /// <typeparam name="T">Array element type.</typeparam>
        /// <param name="array">The array object to be searched.</param>
        /// <param name="x">The element to be searched with.</param>
        /// <returns>The count of the occurrences.</returns>
        public static int CountOrdered<T>(this T[] array, T x) where T : IComparable
        {
            int l = array.BinarySearchBoundary(x, isSorted: true, isFindLowerBoundary: true);
            int r = array.BinarySearchBoundary(x, isSorted: true, isFindLowerBoundary: false);
            return r - l;
        }

        private static void SiftDown<T>(this T[] array, int start, int last) where T : IComparable
        {
            if (start < 0 || start >= array.Length)
                throw new ArgumentOutOfRangeException("start");
            if (last < start || last >= array.Length)
                throw new ArgumentOutOfRangeException("last");
            int parent = start;
            int lastParent = (last-1) >> 1;
            while (parent <= lastParent)
            {
                int max = parent;
                int left = 2 * parent + 1;
                if (array[max].CompareTo(array[left]) < 0)
                {
                    max = left;
                }
                int right = 2 * parent + 2;
                if (right <= last && array[max].CompareTo(array[right]) < 0)
                {
                    max = right;
                }
                if (max != parent)
                {
                    T tmp = array[parent];
                    array[parent] = array[max];
                    array[max] = tmp;
                    parent = max;
                }
                else
                {
                    break; 
                }
            }
        }

        /// <summary>
        /// Build a heap out of an array.
        /// </summary>
        /// <typeparam name="T">The element type of the array.</typeparam>
        /// <param name="array">The array object</param>
        public static void Heapify<T>(this T[] array) where T : IComparable
        {
            int last = array.Length-1;
            int start = (last - 1) >> 1;
            while (start >= 0)
            {
                array.SiftDown(start, last);
                start--;
            }
        }

        /// <summary>
        /// Get the top n element of an array.
        /// </summary>
        /// <typeparam name="T">Element type.</typeparam>
        /// <param name="array">The array contains comparable data.</param>
        /// <param name="n">The number of top elements to retrieve.</param>
        /// <returns>The top n elements enumerable</returns>
        public static IEnumerable<T> Top<T>(this T[] array, int n) where T : IComparable
        {            
            if (n <= 0 || n > array.Length)
                throw new ArgumentOutOfRangeException("n");
            array.Heapify();
            int last = array.Length - 1;
            while (n-- > 0)
            {
                yield return array[0];
                T tmp = array[0];
                array[0] = array[last];
                array[last] = tmp;
                last--;
                array.SiftDown(0, last);
            }
        }
    }
}
