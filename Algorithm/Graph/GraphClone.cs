using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.Graph
{
    public static class GraphClone
    {
        /// <summary>
        /// Clone a Graph object in BFS order.
        /// </summary>
        /// <typeparam name="T">Graph element type.</typeparam>
        /// <param name="graph">An Graph object to be cloned.</param>
        /// <returns>A clone of the Graph object.</returns>
        public static Graph<T> BfsClone<T>(this Graph<T> graph)
        {
            // a dict of <vertex, vertex clone>
            var clones = new Dictionary<Graph<T>, Graph<T>>();
            // BFS
            graph.Bfs(
                vertexAction: v =>
                {
                    var c = new Graph<T>(v.Payload);
                    clones[v] = c;
                },
                edgeAction: (v1, v2) =>
                {
                    clones[v1].LinkTo(clones[v2]);
                });
            // return graph clone 
            return clones[graph];
        }
    }
}
