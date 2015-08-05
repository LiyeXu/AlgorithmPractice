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
        
        public static void Reverse<T>(this ConceptualSinglyLinkedList<T> list)
        {
            // a -> b -> null
            // null <- a b -> null
            // null <- a <- b null
            

            // tmp = b;
            // prior = null;
            // a.Next = prior;
            // cur = tmp;
            // tmp = null;
            // cur.Next = a;
            // prior = a;
            // 

        }
    }
}
