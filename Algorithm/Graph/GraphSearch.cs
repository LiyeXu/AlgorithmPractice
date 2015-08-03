using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.Graph
{
    public static class GraphSearch
    {
        public static void Bfs<T>(this Graph<T> graph, Func<Graph<T>, bool> isVisited, Action<Graph<T>> vertexAction, Action<Graph<T>, Graph<T>> edgeAction)
        {
            var queue = new Queue<Graph<T>>();
            Graph<T> v = graph;
            vertexAction(v);
            queue.Enqueue(v);
            while (queue.Count > 0)
            {
                var c = queue.Dequeue();
                foreach (var n in c.Neighbors)
                {
                    if (!isVisited(n))
                    {
                        vertexAction(n);
                        queue.Enqueue(n);
                    }
                    edgeAction(c, n);
                }
            }
        }
    }
}
