using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Algorithm.Graph;

namespace Algorithm.LinkedList
{
    public static class SinglyLinkedListConstruction
    {
        public static void AddRange<T>(this SinglyLinkedList<T> list, IEnumerable<T> range)
        {
            if (range == null)
                throw new ArgumentNullException("range");
            list.Payload = range.First();
            var rest = range.Skip(1);
            ISinglyLinkedList<T> c = list;
            foreach (var item in rest)
            {
                c.Next = new SinglyLinkedList<T>(item);
                c = c.Next;
            }
            c.Next = null;
        }
    }
}
