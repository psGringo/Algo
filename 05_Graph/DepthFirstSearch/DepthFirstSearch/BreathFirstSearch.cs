using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchInGraphExample
{
    class BreadthFirstSearch
    {
        private static int INFINITY = int.MaxValue;
        private bool[] marked;  // marked[v] = is there an s-v path
        private int[] edgeTo;      // edgeTo[v] = previous edge on shortest s-v path
        private int[] distTo;      // distTo[v] = number of edges shortest s-v path

        /**
   * Computes the shortest path between the source vertex {@code s}
   * and every other vertex in the graph {@code G}.
   * @param G the graph
   * @param s the source vertex
   * @throws IllegalArgumentException unless {@code 0 <= s < V}
   */
        public BreadthFirstSearch(Graph G, int s)
        {
            marked = new bool[G.V];
            distTo = new int[G.V];
            edgeTo = new int[G.V];
            G.validateVertex(s);
            bfs(G, s);
            //assert check(G, s);
        }
        public BreadthFirstSearch(Graph G)
        {
            marked = new bool[G.V];
            distTo = new int[G.V];
            edgeTo = new int[G.V];            
        }


        // breadth-first search from a single source
        public void bfs(Graph G, int s)
        {
            Queue<int> q = new Queue<int>();
            for (int v = 0; v < G.V; v++)
                distTo[v] = INFINITY;
            distTo[s] = 0;
            marked[s] = true;
            Console.Write(s + " ");
            q.Enqueue(s);

            while (q.Count!=0)
            {
                int v = q.Dequeue();
                foreach (int w in G.adjVerticles(v))
                {
                    if (!marked[w])
                    {
                        edgeTo[w] = v;
                        distTo[w] = distTo[v] + 1;
                        marked[w] = true;
                        Console.Write(w+" ");
                        q.Enqueue(w);
                    }
                }
            }
        }
        /**
 * Is there a path between the source vertex {@code s} (or sources) and vertex {@code v}?
 * @param v the vertex
 * @return {@code true} if there is a path, and {@code false} otherwise
 * @throws IllegalArgumentException unless {@code 0 <= v < V}
 */
        public bool hasPathTo(int v)
        {
            validateVertex(v);
            return marked[v];
        }
        // throw an IllegalArgumentException unless {@code 0 <= v < V}
        private void validateVertex(int v)
        {
            int V = marked.Length;
            if (v < 0 || v >= V)
                throw new ArgumentException("vertex " + v + " is not between 0 and " + (V - 1));
        }
        /**
 * Returns the number of edges in a shortest path between the source vertex {@code s}
 * (or sources) and vertex {@code v}?
 * @param v the vertex
 * @return the number of edges in a shortest path
 * @throws IllegalArgumentException unless {@code 0 <= v < V}
 */
        public int distanceTo(int v)
        {
            validateVertex(v);
            return distTo[v];
        }

        /**
         * Returns a shortest path between the source vertex {@code s} (or sources)
         * and {@code v}, or {@code null} if no such path.
         * @param  v the vertex
         * @return the sequence of vertices on a shortest path, as an Iterable
         * @throws IllegalArgumentException unless {@code 0 <= v < V}
         */
        public IEnumerable<int> pathTo(int v)
        {
            validateVertex(v);
            if (!hasPathTo(v)) return null;
            Stack<int> path = new Stack<int>();
            int x;
            for (x = v; distTo[x] != 0; x = edgeTo[x])
                path.Push(x);
                path.Push(x); // adding start verticle here
            return path;
        }

        public IEnumerable<int> pathTo2(int v,int startVertex)
        {
            validateVertex(v);
            validateVertex(startVertex);
            if (!hasPathTo(v)) return null;
            Stack<int> path = new Stack<int>();
            int x;
            for (x = v; x!=startVertex; x = edgeTo[x])
                path.Push(x);
            path.Push(startVertex);
            return path;
        }

    }
}

