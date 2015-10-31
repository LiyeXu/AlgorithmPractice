using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Algorithm.Graph;

namespace Algorithm.LinkedList
{
    /// <summary>
    /// Represent a singly linked list, or in trivial case, a list node with Next equals to null.
    /// </summary>
    /// <typeparam name="T"></typeparam>
   public interface ISinglyLinkedList<T>
   {
        T Payload
        {
            get;
            set;
        }
        
        ISinglyLinkedList<T> Next
        {
            get;
            set;
        }
    }
}
