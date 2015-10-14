using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.Combinatorics
{
    public static class IListCombination
    {
        /// <summary>
        /// Get combinations C(n, m) of a list of elements.
        /// </summary>
        /// <typeparam name="T">List element type.</typeparam>
        /// <param name="list">A list of elements to be combined.</param>
        /// <param name="n">Number of element to be included in each combination.</param>
        /// <returns>An IEnumerable of combinations</returns>
        public static IEnumerable<IList<T>> Combine<T>(this IList<T> list, int n)
        {
            IList<IList<T>> result = new List<IList<T>>();
            result.Add(new List<T>());
            for (int i = 0; i < list.Count; i++)
            {
                int resultCount = result.Count;
                for (int j = 0; j < resultCount; j++)
                {
                    if (result[j].Count == n)
                        continue;
                    var entry = new List<T>(result[j]);
                    entry.Add(list[i]);
                    result.Add(entry);
                }
            }
            return result.Where(i => i.Count == n);
        }

        /// <summary>
        /// Get permutations P(n, m) of a list of elements.
        /// </summary>
        /// <typeparam name="T">List element type.</typeparam>
        /// <param name="list">A list of elements to be permuted.</param>
        /// <param name="n">Number of element to be included in each permutation.</param>
        /// <returns>An IEnumerable of permutations</returns>
        public static IEnumerable<IList<T>> Permute<T>(this IList<T> list, int n)
        {
            if (n == 0)
                yield return new List<T>();
            for (int i = 0; i < list.Count; i++)
            {
                var cur = list[i];
                list.RemoveAt(i);
                var subCombinations = list.Permute(n - 1);
                foreach (var item in subCombinations)
                {
                    item.Insert(0, cur);
                    yield return item;
                }
                list.Insert(i, cur);
            }
        }

        /// <summary>
        /// Get all sub sets of a list of elements.
        /// </summary>
        /// <typeparam name="T">List element type.</typeparam>
        /// <param name="list">A list of elements to be subseted.</param>
        /// <returns>An IEnumerable of all subsets</returns>
        public static IEnumerable<IList<T>> Subsets<T>(this IList<T> list)
        {
            IList<T> empty = new List<T>();
            IList<IList<T>> result = new List<IList<T>>();
            result.Add(empty);
            foreach (var item in list)
            {
                IList<IList<T>> buffer = new List<IList<T>>();
                foreach (IList<T> subset in result.Reverse())
                {
                    var tmp = new List<T>(subset);
                    tmp.Add(item);
                    buffer.Add(tmp);
                }
                result = result.Concat(buffer).ToList();
            }
            return result;
        }
    }
}