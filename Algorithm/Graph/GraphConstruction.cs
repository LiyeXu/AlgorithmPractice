using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.Graph
{
    public static class GraphConstruction
    {
        public static bool LinkTo<T>(this Graph<T> from, Graph<T> to)
        {
            if (from.Neighbors.Contains(to))
            {
                Trace.TraceWarning(Resource.Graph_Edge_Existed, from, to);
                return false;
            }
            from.Neighbors.Add(to);
            Trace.TraceInformation(Resource.Graph_Edge_Created, from, to);
            return true;
        }
    }
}
