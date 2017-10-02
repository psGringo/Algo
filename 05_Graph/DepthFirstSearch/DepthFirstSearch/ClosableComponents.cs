using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchInGraphExample
{
    public class CC // ClosableComponents
    {
        public bool[] marked;   // marked[v] = has vertex v been marked?
        public int[] id;           // id[v] = id of connected component containing v
        public int[] size;         // size[id] = number of vertices in given component
        public int count;          // number of connected components

        /**
         * Computes the connected components of the undirected graph {@code G}.
         *
         * @param G the undirected graph
         */
        public CC(Graph G)
        {
            marked = new bool[G.V];
            id = new int[G.V];
            size = new int[G.V];
            for (int v = 0; v < G.V; v++)
            {
                if (!marked[v])
                {
                    dfs(G, v);
                    count++;
                }
            }
        }
        
        // depth-first search for a Graph
        private void dfs(Graph G, int v)
        {
            marked[v] = true;
            id[v] = count;
            size[count]++;
            foreach (int w in G.adjVerticles(v))
            {
                if (!marked[w])
                {
                    dfs(G, w);
                }
            }
        }

        /**
 * Returns the component id of the connected component containing vertex {@code v}.
 *
 * @param  v the vertex
 * @return the component id of the connected component containing vertex {@code v}
 * @throws IllegalArgumentException unless {@code 0 <= v < V}
 */
        public int idGroup(int v)
        {
            validateVertex(v);
            return id[v];
        }
        /**
   * Returns the number of vertices in the connected component containing vertex {@code v}.
   *
   * @param  v the vertex
   * @return the number of vertices in the connected component containing vertex {@code v}
   * @throws IllegalArgumentException unless {@code 0 <= v < V}
   */
        public int sizeGroup(int v)
        {
            validateVertex(v);
            return size[id[v]];
        }
        /**
 * Returns the number of connected components in the graph {@code G}.
 *
 * @return the number of connected components in the graph {@code G}
 */
        public int countGroup()
        {
            return count;
        }
        /**
    * Returns true if vertices {@code v} and {@code w} are in the same
    * connected component.
    *
    * @param  v one vertex
    * @param  w the other vertex
    * @return {@code true} if vertices {@code v} and {@code w} are in the same
    *         connected component; {@code false} otherwise
    * @throws IllegalArgumentException unless {@code 0 <= v < V}
    * @throws IllegalArgumentException unless {@code 0 <= w < V}
    */
        public bool connected(int v, int w)
        {
            validateVertex(v);
            validateVertex(w);
            return idGroup(v) == idGroup(w);
        }
        // throw an IllegalArgumentException unless {@code 0 <= v < V}
        private void validateVertex(int v)
        {
            int V = marked.Length;
            if (v < 0 || v >= V)
                throw new ArgumentException("vertex " + v + " is not between 0 and " + (V - 1));
        }
    }
}
