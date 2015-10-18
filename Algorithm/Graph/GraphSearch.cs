using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.Graph
{
    public static class GraphSearch
    {
        /// <summary>
        /// Search a Graph object in BFS order
        /// </summary>
        /// <typeparam name="T">Graph element type</typeparam>
        /// <param name="graph">A Graph object to be visited</param>
        /// <param name="vertexAction">Vertex visiting action</param>
        /// <param name="edgeAction">Edge visiting action</param>
        public static void Bfs<T>(this Graph<T> graph, Action<Graph<T>> vertexAction, Action<Graph<T>, Graph<T>> edgeAction)
        {
            var visitedSet = new HashSet<Graph<T>>();
            var queue = new Queue<Graph<T>>();
            Graph<T> v = graph;
            vertexAction(v);
            queue.Enqueue(v);
            while (queue.Count > 0)
            {
                var c = queue.Dequeue();
                foreach (var n in c.Neighbors)
                {
                    if (!visitedSet.Contains(n))
                    {
                        vertexAction(n);
                        visitedSet.Add(n);
                        queue.Enqueue(n);
                    }
                    edgeAction(c, n);
                }
            }
        }
    }
}
