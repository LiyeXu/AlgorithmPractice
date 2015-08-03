using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.Graph
{
    public class Graph<T>
    {
        public T Payload
        {
            get;
            set;
        }
        
        private List<Graph<T>> _neighbors;

        public IList<Graph<T>> Neighbors
        {
            get
            {
                return _neighbors;                
            }
        }
        
        public long CreatedTicks
        {
            get;
            private set;
        }

        public Graph(T payload)
        {
            _neighbors = new List<Graph<T>>();
            Payload = payload;
            CreatedTicks = Stopwatch.GetTimestamp();
        }

        public override string ToString()
        {
            return string.Format(Resource.Graph_Vertex_String, Payload, CreatedTicks % 1000000);
        }
    }
}
