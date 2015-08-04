using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Algorithm.Graph;

namespace Algorithm.LinkedList
{
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
