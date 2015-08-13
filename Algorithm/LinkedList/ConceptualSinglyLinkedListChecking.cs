using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Algorithm.Graph;

namespace Algorithm.LinkedList
{
    public static class ConceptualSinglyLinkedListChecking
    {
        /// <summary>
        /// Find the loop node of a linked list if any.
        /// </summary>
        /// <typeparam name="T">The linked list element type.</typeparam>
        /// <param name="list">A linked list to be checked.</param>
        /// <returns>Returns the looping node if any, otherwise returns null.</returns>
        public static ISinglyLinkedList<T> FindLoopNode<T>(this ConceptualSinglyLinkedList<T> list)
        {
            var head = list as ISinglyLinkedList<T>;
            // detect loop existence
            var p = head.Next;
            if (p == null)
                return null;
            var q = p.Next;
            while (q != null && q.Next != null)
            {
                p = p.Next;
                q = q.Next.Next;
                if (p == q)
                    break;
            }
            // no loop
            if (p != q)
                return null;
            // find the looping node
            q = head;            
            while (p != q)
            {
                p = p.Next;
                q = q.Next;
            }
            return p;
        }

        public static ISinglyLinkedList<T> FindLastNthNode<T>(this ConceptualSinglyLinkedList<T> list, int n)
        {
            var head = list as ISinglyLinkedList<T>;
            var p = head;
            var q = head;
            int count = 1;
            while (p.Next != null)
            {
                p = p.Next;
                count++;
                if (count > n)
                    q = q.Next;
            }
            if (count < n)
                return null;
            return q;
        }
    }
}
