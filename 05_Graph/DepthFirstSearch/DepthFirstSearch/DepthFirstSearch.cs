using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepthFirstSearch
{

    public class DepthFirstSearch
    {
        private bool[] marked;    // marked[v] = is there an s-v path?
        private int count;           // number of vertices connected to s

        /**
         * Computes the vertices in graph {@code G} that are
         * connected to the source vertex {@code s}.
         * @param G the graph
         * @param s the source vertex
         * @throws IllegalArgumentException unless {@code 0 <= s < V}
         */
        public DepthFirstSearch(Graph G, int s)
        {
            marked = new bool[G.V];
            G.validateVertex(s);
            dfs(G, s);
        }
        public DepthFirstSearch(Graph G)
        {
            marked = new bool[G.V];
        }


        // depth first search from v
        public void dfs(Graph G, int v)
        {
            count++;
            marked[v] = true;
            Console.Write(v + " ");
            foreach (int w in G.adjVerticles(v))
            {
                if (!marked[w])
                {
                    dfs(G, w);
                }
            }
        }

        public void unmarkAll()
        {            
            for(int i=0; i<marked.Length;i++)
            {
                marked[i] = false;
            }
        }

        // is some Verticle is?
        public bool isVertex(Graph G, int v,int searchedVertex)
        {
            bool r = false;
            count++;
            marked[v] = true;
            if (searchedVertex == v)
            {
                r = true;
                return r;
            }
            else
            {
                foreach (int w in G.adjVerticles(v))
                {
                    if (!marked[w])
                    {
                       r=isVertex(G, w, searchedVertex);
                        return r;                        
                    }                    
                }
                return r;
            }
          
        }

    }
}