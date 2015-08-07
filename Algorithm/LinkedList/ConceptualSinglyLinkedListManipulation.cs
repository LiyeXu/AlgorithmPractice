using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Algorithm.Graph;

namespace Algorithm.LinkedList
{
    public static class ConceptualSinglyLinkedListManipulation
    {
        /// <summary>
        /// Reverse a linked list.
        /// </summary>
        /// <typeparam name="T">Linked list element type.</typeparam>
        /// <param name="list">A linked list to be reversed.</param>
        public static void Reverse<T>(this ConceptualSinglyLinkedList<T> list)
        {
            if (list == null)
                return;
            ISinglyLinkedList<T> prior = null;
            ISinglyLinkedList<T> current = list;
            ISinglyLinkedList<T> second = list.Next;
            ISinglyLinkedList<T> next = list.Next;
            while (next != null)
            {                               
                current.Next = prior;
                prior = current;
                current = next;
                next = current.Next;
            }
            // swap the references of the first and the last node.
            list.Next = prior;
            second.Next = current;
            current.Next = null;
            // swap the payloads back
            T tmp = list.Payload;
            list.Payload = current.Payload;
            current.Payload = tmp;
        }
    }
}
