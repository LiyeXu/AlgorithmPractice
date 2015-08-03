using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.Array
{
    public static class ArrayIntersection
    {
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
    }
}
