using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.List
{
    public static class ListExtensions
    {
        public static void QuickSort<T>(this IList<T> list, int left = 0, int right = -1) where T : IComparable
        {
            if (right == -1)
                right = list.Count - 1;
            if (left < 0 || left >= list.Count)
                throw new ArgumentOutOfRangeException("start");
            if (right < left || right >= list.Count)
                throw new ArgumentOutOfRangeException("end");
            list.QuickSortImpl(left, right);
        }

        private static void QuickSortImpl<T>(this IList<T> list, int left, int right) where T : IComparable
        {
            while (right > left)
            {
                int p = list.HoarePartition(left, right);
                list.QuickSortImpl(p + 1, right);                
                right = p;                
            }
        }

        private static int HoarePartition<T>(this IList<T> list, int left, int right) where T : IComparable
        {
            int m = left + ((right - left) >> 1);
            T pivot = list[m];
            int l = left - 1;
            int r = right + 1;
            while (true)
            {
                while (list[--r].CompareTo(pivot) > 0);
                while (list[++l].CompareTo(pivot) < 0);
                if (l < r)
                {
                    T tmp = list[l];
                    list[l] = list[r];
                    list[r] = tmp;
                }
                else
                {
                    break;
                }   
            }
            return r;
        }

        /// <summary>
        /// Find a zero-based index of the lower or upper boundary of a range of repeated elements in the list.
        /// </summary>
        /// <typeparam name="T">List element type.</typeparam>
        /// <param name="list">The list object to be searched.</param>
        /// <param name="x">The element to be searched with.</param>
        /// <param name="isSorted">Whether the list object is sorted already.</param>
        /// <param name="isFindLowerBoundary">To search the lower or upper boundary.</param>
        /// <returns>Returns the lower or upper boundary of the repeated range if there is one, otherwise returns -1.</returns>
        public static int BinarySearchBoundary<T>(this IList<T> list, T x, bool isSorted = false, bool isFindLowerBoundary = true) where T : IComparable
        {
            if (!isSorted)
                list.QuickSort();
            int left = 0;
            int right = list.Count - 1;
            while (left <= right)
            {
                int mid = left + ((right - left) >> 1);
                int diff = list[mid].CompareTo(x);
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

        public static void HeapInsert<T>(this IList<T> list, T x) where T : IComparable
        {
            list.Add(x);
            list.BubbleUp();
        }

        private static void BubbleUp<T>(this IList<T> list) where T : IComparable
        {
            int index = list.Count - 1;
            while (index > 0)
            {
                int parent = (index - 1) >> 1;
                if (list[parent].CompareTo(list[index]) < 0)
                {
                    T tmp = list[parent];
                    list[parent] = list[index];
                    list[index] = tmp;
                    index = parent;
                }
                else
                {
                    break;
                }
            }
        }

        private static void SiftDown<T>(this IList<T> list, int start) where T : IComparable
        {
            if (start < 0 || start >= list.Count)
                throw new ArgumentOutOfRangeException("start");
            int last = list.Count - 1;
            int parent = start;
            int lastParent = (last-1) >> 1;
            while (parent <= lastParent)
            {
                int max = parent;
                int left = 2 * parent + 1;
                if (list[max].CompareTo(list[left]) < 0)
                {
                    max = left;
                }
                int right = 2 * parent + 2;
                if (right <= last && list[max].CompareTo(list[right]) < 0)
                {
                    max = right;
                }
                if (max != parent)
                {
                    T tmp = list[parent];
                    list[parent] = list[max];
                    list[max] = tmp;
                    parent = max;
                }
                else
                {
                    break; 
                }
            }
        }

        /// <summary>
        /// Build a heap out of an list.
        /// </summary>
        /// <typeparam name="T">The element type of the list.</typeparam>
        /// <param name="list">The list object</param>
        public static void Heapify<T>(this IList<T> list) where T : IComparable
        {
            int last = list.Count - 1;
            int start = (last - 1) >> 1;
            while (start >= 0)
            {
                list.SiftDown(start);
                start--;
            }
        }

        /// <summary>
        /// Get the top n element of an list.
        /// </summary>
        /// <typeparam name="T">Element type.</typeparam>
        /// <param name="list">The list contains comparable data.</param>
        /// <param name="n">The number of top elements to retrieve.</param>
        /// <returns>The top n elements enumerable</returns>
        public static IEnumerable<T> Top<T>(this IList<T> list, int n) where T : IComparable
        {            
            if (n <= 0 || n > list.Count)
                throw new ArgumentOutOfRangeException("n");
            list.Heapify();
            while (n-- > 0)
            {
                yield return list[0];
                int last = list.Count - 1;
                list[0] = list[last];
                list.RemoveAt(last);
                list.SiftDown(0);
            }
        }
    }
}
