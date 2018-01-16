using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphBasics
{
    //https://algs4.cs.princeton.edu/code/edu/princeton/cs/algs4/BreadthFirstPaths.java.html
    class BreadthFirstPaths
    {
        private bool[] marked; //marked[v] = is there an s-v path
        private int[] edgeTo; // edgeTo[v] = previous edge on shortest s-v path
        private int[] distTo;  // distTo[v] = number of edges shortest s-v path
        private int infinity = int.MaxValue; // some infinity integer
        public BreadthFirstPaths(Graph G, IEnumerable<int> sources)
        {
            marked = new bool[G.V];
            distTo = new int[G.V];
            edgeTo = new int[G.V];
            for (int v = 0; v < G.V; v++) distTo[v] = infinity;
            ValidateVertices(sources);
        }
        // breadth-first search from a single source
        private void Bfs(Graph G, int s)
        {
            Queue<int> q = new Queue<int>();
            for (int v = 0; v < G.V; v++) distTo[v] = infinity;
            distTo[s] = 0;
            marked[s] = true;
            q.Enqueue(s);
            while (q.Count!=0)
            {
                int v = q.Dequeue();
                foreach (int w in G.adj[v])
                {
                    if (!marked[w])
                    {
                        edgeTo[w] = v;
                        distTo[w] = distTo[v] + 1;
                        marked[w] = true;
                        q.Enqueue(w);
                    }
                }
            }
        }
        // breadth-first search from multiple sources
        private void bfs(Graph G, IEnumerable<int> sources)
        {
            Queue<int> q = new Queue<int>();
            foreach (int s in sources)
            {
                marked[s] = true;
                distTo[s] = 0;
                q.Enqueue(s);
            }
            while (q.Count != 0)
            {
                int v = q.Dequeue();
                foreach (int w in G.adj[v])
                {
                    if (!marked[w])
                    {
                        edgeTo[w] = v;
                        distTo[w] = distTo[v] + 1;
                        marked[w] = true;
                        q.Enqueue(w);
                    }
                }
            }
        }
        //Is there a path between the source vertex {@code s} (or sources) and vertex {@code v}?
        public Boolean HasPathTo(int v)
        {
            ValidateVertex(v);
            return marked[v];
        }
        // throw an IllegalArgumentException unless {@code 0 <= v < V}
        private void ValidateVertex(int v)
        {
            int V = marked.Length;
            if (v < 0 || v >= V)
                throw new ArgumentException("vertex " + v + " is not between 0 and " + (V - 1));
        }

        //Returns the number of edges in a shortest path between the source vertex {@code s}
        public int DistanceTo(int v)
        {
            ValidateVertex(v);
            return distTo[v];
        }
        /** Returns a shortest path between the source vertex {@code s} (or sources)
     * and {@code v}, or {@code null} if no such path.*/
        public IEnumerable<int> ShortestPathTo(int v)
        {
            ValidateVertex(v);
            if (!HasPathTo(v)) return null;
            Stack<int> path = new Stack<int>();
            int x;
            for (x = v; DistanceTo(x) != 0; x = edgeTo[x])
            {
                path.Push(x);
            }
            path.Push(x);
            return path;
        }

        // throw an IllegalArgumentException unless {@code 0 <= v < V}
        private void ValidateVertices(IEnumerable<int> vertices)
        {
            if (vertices == null)
            {
                throw new ArgumentException("argument is null");
            }
            int V = marked.Length;
            foreach (int v in vertices)
            {
                if (v < 0 || v >= V)
                {
                    throw new ArgumentException("vertex " + v + " is not between 0 and " + (V - 1));
                }
            }
        }
    }
}
