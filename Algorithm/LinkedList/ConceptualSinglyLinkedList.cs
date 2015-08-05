using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Algorithm.Graph;

namespace Algorithm.LinkedList
{
    public class ConceptualSinglyLinkedList<T> : Graph<T>, ISinglyLinkedList<T>
    {
        public ConceptualSinglyLinkedList(T payload)
            : base(payload)
        { 
        }

        public ISinglyLinkedList<T> Next
        {
            get
            {
                if (base.Neighbors.Count == 0)
                {
                    return null;
                }
                else
                {
                    return base.Neighbors[0] as ConceptualSinglyLinkedList<T>;
                }                
            }
            set
            {
                if (base.Neighbors.Count == 0)
                {
                    base.Neighbors.Add(value as Graph<T>);
                }
                else
                {
                    base.Neighbors[0] = value as Graph<T>;
                }
            }
        }
    }
}
