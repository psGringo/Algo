using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphBasics
{
    public class CC // connected components Graph
    {
        private bool[] marked;  // marked[v] = has vertex v been marked?
        private int[] idGroup; // id[v] = id of connected component containing v
        private int[] size; // size[id] = number of vertices in given component
        private int count; // number of connected components
        public CC(Graph G)
        {
            marked = new bool[G.V];
            idGroup = new int[G.V];
            size = new int[G.V];
        }
        // depth-first search for a Graph
        private void Dfs(Graph G, int v)
        {
            marked[v] = true;
            idGroup[v] = count;
            size[count]++;
            foreach (int w in G.adj[v])
            {
                if (!marked[w]) Dfs(G, w);
                count++;
            }
        }
        public int GetId(int v)
        {
            ValidateVertex(v);
            return idGroup[v];
        }
        // throw an IllegalArgumentException unless {@code 0 <= v < V}
        private void ValidateVertex(int v)
        {
            int V = marked.Length;
            if (v < 0 || v >= V)
                throw new ArgumentException("vertex " + v + " is not between 0 and " + (V - 1));
        }
        public int getCount()
        {
            return count;
        }
        public bool IsConnected(int v, int w)
        {
            ValidateVertex(v);
            ValidateVertex(w);
            return GetId(v) == GetId(w);
        }
        public int GetSize(int v)
        {
            ValidateVertex(v);
            return size[idGroup[v]];
        }
    }
}
