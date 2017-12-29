using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Digraph
{
    class Digraph
    {
        public int V { get; }
        //private int V; // vertices
        public int E { get; set; }// edges
        private Bag<int>[] adj; // adj list
        private int[] indegree; //// indegree[v] = indegree of vertex v
        // constructor
        public Digraph(int V)
        {
            if (V < 0) throw new ArgumentException("Number of vertices in a Digraph must be nonnegative");
            this.V = V;
            this.E = 0;
            indegree = new int[V];
            Bag<int>[] adj = new Bag<int>[V];
            for (int v = 0; v < V; v++)
            {
                adj[v] = new Bag<int>();
            }
        }

        private void validateVertex(int v)
        {
            if (v < 0 || v > V) { throw new ArgumentException("wrong vertex"); }
        }

        public void addEdge(int v, int w)
        {
            validateVertex(v);
            validateVertex(w);
            adj[v].push(w);
            indegree[w]++;
            E++;
        }

        

    }
}

