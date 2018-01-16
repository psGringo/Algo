using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphBasics
{
    //https://algs4.cs.princeton.edu/code/edu/princeton/cs/algs4/DepthFirstPaths.java.html
    class DepthFirstPaths
    {
        private Boolean[] isMarked; // marked[v] = is there an s-v path?
        private int[] edgeTo; // // edgeTo[v] = last edge on s-v path
        private int s; // source vertex
        DepthFirstPaths(Graph G, int s)
        {
            this.s = s;
            edgeTo = new int[G.V];
            isMarked = new Boolean[G.V];
            ValidateVertex(s);
        }
        // depth first search from v
        private void dfs(Graph G, int v)
        {
            isMarked[v] = true;
            foreach (var w in G.adj[v])
            {
                if (!isMarked[w])
                {
                    edgeTo[w] = v; // last edge 
                    dfs(G, w);
                }
            }
        }
        //  Is there a path between the source vertex {@code s} and vertex {@code v}?
        public Boolean hasPathTo(int v)
        {
            ValidateVertex(v);
            return isMarked[v];
        }
        // Returns a path between the source vertex {@code s} and vertex {@code v}, or
        // * {@code null} if no such path.
        public IEnumerable<int> pathTo(int v)
        {
            ValidateVertex(v);
            if (!hasPathTo(v)) return null;
            Stack<int> path = new Stack<int>();
            for (int x = v; x != s; x = edgeTo[x])            
                path.Push(x);            
            path.Push(s); 
            return path;
        }
        //

        // validation
        private void ValidateVertex(int v)
        {
            int V = isMarked.Length;
            if (v < 0 || v >= V)
            {
                throw new ArgumentException();
            }
        }
    }
}
