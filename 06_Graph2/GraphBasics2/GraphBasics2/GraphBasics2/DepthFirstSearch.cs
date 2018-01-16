using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphBasics
{
    public class DepthFirstSearch
    {
        private Boolean[] isMarked;
        private int count;
        public DepthFirstSearch(Graph G, int s) // s - source vertex
        {
            isMarked = new Boolean[G.V];
            // validate vertex
            validateVertex(s);
            dfs(G, s);
        }

        // depth first search
        private void dfs(Graph G, int v)
        {
            // do smth with vertex
            isMarked[v] = true;
            count++;
            // go deep
            foreach (var w in G.adj[v])
            {
                if (!isMarked[w])
                    dfs(G, v);
            }
        }

        // validation
        private void validateVertex(int v)
        {
            int V = isMarked.Length;
            if (v < 0 || v >= V)
            {
                throw new ArgumentException();
            }
        }
        // is path beetwen s and v
        public Boolean Marked(int v)
        {
            validateVertex(v);
            return isMarked[v];
        }
        /**
    * Returns the number of vertices connected to the source vertex {@code s}.
    * @return the number of vertices connected to the source vertex {@code s}
    */
        public int Count()
        {
            return count;
        }


    }
}
