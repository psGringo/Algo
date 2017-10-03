using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BipartiteGraphExample
{
    public class Bipartite
    {
        public bool isBipartite { get; set; }   // is the graph bipartite?
        private bool[] color;       // color[v] gives vertices on one side of bipartition
        private bool[] marked;      // marked[v] = true if v has been visited in DFS
        private int[] edgeTo;          // edgeTo[v] = last edge on path to v
        public Stack<int> cycle;  // odd-length cycle

        /**
   * Determines whether an undirected graph is bipartite and finds either a
   * bipartition or an odd-length cycle.
   *
   * @param  G the graph
   */
        public Bipartite(Graph G)
        {
            isBipartite = true;
            color = new bool [G.V];
            marked = new bool [G.V];
            edgeTo = new int[G.V];

            for (int v = 0; v < G.V; v++)
            {
                if (!marked[v])
                {
                    dfs(G, v);
                }
            }
            Trace.Assert(check(G));
        }

        private void dfs(Graph G, int v)
        {
            marked[v] = true;
            foreach (int w in G.adjVerticles(v))
            {

                // short circuit if odd-length cycle found
                if (cycle != null) return;

                // found uncolored vertex, so recur
                if (!marked[w])
                {
                    edgeTo[w] = v;
                    color[w] = !color[v];
                    dfs(G, w);
                }

                // if v-w create an odd-length cycle, find it
                else if (color[w] == color[v])
                {
                    isBipartite = false;
                    cycle = new Stack<int>();
                    cycle.Push(w);  // don't need this unless you want to include start vertex twice
                    for (int x = v; x != w; x = edgeTo[x])
                    {
                        cycle.Push(x);
                    }
                    cycle.Push(w);
                }
            }
        }
        public bool getColor(int v)
        {
            validateVertex(v);
            if (!isBipartite)
                throw new ArgumentException("graph is not bipartite");
            return color[v];
        }
        /**
   * Returns an odd-length cycle if the graph is not bipartite, and
   * {@code null} otherwise.
   *
   * @return an odd-length cycle if the graph is not bipartite
   *         (and hence has an odd-length cycle), and {@code null}
   *         otherwise
   */
        public IEnumerable<int> oddCycle()
        {
            return cycle;
        }

        private bool check(Graph G)
        {
            // graph is bipartite
            if (isBipartite)
            {
                for (int v = 0; v < G.V; v++)
                {
                    foreach (int w in G.adjVerticles(v))
                    {
                        if (color[v] == color[w])
                        {
                            Console.WriteLine("edge %d-%d with %d and %d in same side of bipartition\n", v, w, v, w);
                            return false;
                        }
                    }
                }
            }
            // graph has an odd-length cycle
            else
            {
                // verify cycle
                int first = -1, last = -1;
                foreach (int v in oddCycle())
                {
                    if (first == -1) first = v;
                    last = v;
                }
                if (first != last)
                {
                    Console.WriteLine("cycle begins with %d and ends with %d\n", first, last);
                    return false;
                }
            }

            return true;
        }
        // throw an IllegalArgumentException unless {@code 0 <= v < V}
        private void validateVertex(int v)
        {
            int V = marked.Length;
            if (v < 0 || v >= V)
                throw new ArgumentException("vertex " + v + " is not between 0 and " + (V - 1));
        }
        public void showCycle()
        {
            foreach (var c in cycle) Console.WriteLine(c);
        }

    }
}
