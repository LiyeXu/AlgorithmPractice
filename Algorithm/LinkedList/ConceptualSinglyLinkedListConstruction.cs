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
        /// <summary>
        /// Add a range of elements in to a linked list.
        /// </summary>
        /// <typeparam name="T">Linked list element type.</typeparam>
        /// <param name="list">A linked list object.</param>
        /// <param name="range">An IEnumerable<T> of elements to be added.</param>
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
