using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphBasics
{
    // https://algs4.cs.princeton.edu/code/edu/princeton/cs/algs4/Cycle.java.html
    class Cycle
    {
        private bool[] marked;
        private int[] edgeTo;
        private Stack<int> cycle;
        /**
    * Determines whether the undirected graph {@code G} has a cycle and,
    * if so, finds such a cycle.
    *
    * @param G the undirected graph
    */
        public Cycle(Graph G)
        {
            if (HasSelfLoop(G)) return;
            if (HasParallelEdges(G)) return;
            marked = new bool[G.V];
            edgeTo = new int[G.V];
            for (int v = 0; v < G.V; v++)
            {
                if (!marked[v]) Dfs(G, -1, v);
            }
        }
        // u-v like path here
        private void Dfs(Graph G, int u, int v)
        {
            marked[v] = true;
            foreach (int w in G.adj[v])
            {
                if (cycle != null) return;
                if (!marked[v])
                {
                    edgeTo[w] = v;
                    Dfs(G, v, w);
                }
                // already marked[v] and again - means cycle
                else if (w != u)
                {
                    // writing cycle to stack
                    cycle = new Stack<int>();
                    for (int x = 0; x != w; x = edgeTo[x])
                        cycle.Push(x);
                    cycle.Push(w);
                    cycle.Push(v);
                }
            }
        }
        // does this graph have two parallel edges?
        // side effect: initialize cycle to be two parallel edges
        private bool HasParallelEdges(Graph G)
        {
            marked = new bool[G.V];
            for (int v = 0; v < G.V; v++)
            {
                foreach (int w in G.adj[v])
                {
                    if (marked[w])
                    {
                        cycle = new Stack<int>();
                        cycle.Push(v);
                        cycle.Push(w);
                        cycle.Push(v);
                        return true;
                    }
                    marked[w] = true;
                }
                //reset all marked to false
                foreach (int w in G.adj[v])
                {
                    marked[w] = false;
                }
            }
            return false;
        }
        // does this graph have a self loop?
        // side effect: initialize cycle to be self loop
        private bool HasSelfLoop(Graph G)
        {
            for (int v = 0; v < G.V; v++)
            {
                foreach (var w in G.adj[v])
                {
                    if (v == w)
                    {
                        cycle = new Stack<int>();
                        cycle.Push(v);
                        cycle.Push(v);
                        return true;
                    }
                }
            }
            return false;
        }

        public bool HasCycle()
        {
            return cycle != null;
        }
    }
}
