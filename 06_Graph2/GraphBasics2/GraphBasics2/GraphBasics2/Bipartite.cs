using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphBasics
{
    class Bipartite
    {
        public bool IsBipartite { get; set; } // is the graph bipartite?
        private bool[] color; // color[v] gives vertices on one side of bipartition
        private bool[] marked; // marked[v] = true if v has been visited in DFS
        private int[] edgeTo; // edgeTo[v] = last edge on path to v
        private Stack<int> cycle; // odd-length cycle
                                  /**
                               * Determines whether an undirected graph is bipartite and finds either a
                               * bipartition or an odd-length cycle.
                               *
                               * @param  G the graph
                               */
        public Bipartite(Graph G)
        {
            IsBipartite = true;
            color = new bool[G.V];
            marked = new bool[G.V];
            edgeTo = new int[G.V];
            for (int v = 0; v < G.V; v++)
            {
                if (!marked[v]) { }
            }
        }
        private void Dfs(Graph G, int v)
        {
            foreach (int w in G.adj[v])
            {
                if (cycle != null) return;
                if (!marked[w])
                {
                    edgeTo[w] = v;
                    color[w] = !color[v];
                    Dfs(G, v);
                }
                else if (color[w] == color[v])
                {
                    IsBipartite = false;
                    cycle = new Stack<int>();
                    cycle.Push(w); // don't need this unless you want to include start vertex twice
                    for (int x = v; x != w; x = edgeTo[x])
                    {
                        cycle.Push(x);
                    }
                    cycle.Push(w);
                }
            }
        }
        public bool GetColor(int v)
        {
            ValidateVertex(v);
            if (!IsBipartite) throw new Exception("not Bipartite");
            return color[v];
        }
        public IEnumerable<int> OddCycle()
        {
            return cycle;
        }
        public bool IsBipartiteCheck(Graph G)
        {
            for (int v = 0; v < G.V; v++)
            {
                foreach (var w in G.adj[v])
                {
                    if (color[w] == color[v]) return false;
                }
            }
            return true;
        }
        private void ValidateVertex(int v)
        {
            int V = marked.Length;
            if (v < 0 || v >= V) throw new ArgumentException("wrong vertex");
        }
    }
}
