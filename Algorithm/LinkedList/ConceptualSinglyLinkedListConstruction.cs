using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Algorithm.Graph;

namespace Algorithm.LinkedList
{
    public static class ConceptualSinglyLinkedListConstruction
    {
        public static void AddRange<T>(this ConceptualSinglyLinkedList<T> list, IEnumerable<T> range)
        {
            if (range == null)
                throw new ArgumentNullException("range");
            list.Payload = range.First();
            var rest = range.Skip(1);
            ISinglyLinkedList<T> c = list;
            foreach (var item in rest)
            {
                c.Next = new ConceptualSinglyLinkedList<T>(item);
                c = c.Next;
            }
            c.Next = null;
        }
    }
}
