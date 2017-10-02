using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SymbolGraphExample
{
    public class Graph
    {
        // private static final String NEWLINE = System.getProperty("line.separator");

        public int V { get; set; }
        public int E { get; set; }
        public Bag<int>[] adj { get; set; }


        /**
         * Initializes an empty graph with {@code V} vertices and 0 edges.
         * param V the number of vertices
         *
         * @param  V number of vertices
         * @throws IllegalArgumentException if {@code V < 0}
         */
        public Graph(int V)
        {
            if (V < 0) throw new ArgumentException("Number of vertices must be nonnegative");
            this.V = V;
            this.E = 0;
            adj = new Bag<int>[V];
            for (int v = 0; v < V; v++)
            {
                adj[v] = new Bag<int>();
            }
        }


        /**  
   * Initializes a graph from the specified input stream.
   * The format is the number of vertices <em>V</em>,
   * followed by the number of edges <em>E</em>,
   * followed by <em>E</em> pairs of vertices, with each entry separated by whitespace.
   *
   * @param  in the input stream
   * @throws IllegalArgumentException if the endpoints of any edge are not in prescribed range
   * @throws IllegalArgumentException if the number of vertices or edges is negative
   * @throws IllegalArgumentException if the input stream is in the wrong format
   */

        public Graph(string filepath)
        {
            try
            {
                using (StreamReader sr = new StreamReader(filepath))
                {
                    int i = 0;

                    while (sr.Peek() >= 0)
                    {
                        // reading number of verticles
                        if (i == 0)
                        {
                            V = Convert.ToInt32(sr.ReadLine());
                            adj = new Bag<int>[V];
                            for (int v = 0; v < V; v++)
                            {
                                adj[v] = new Bag<int>();
                            }
                            i++;
                        }
                        // reading number of edges
                        else
                            if (i == 1)
                        {
                            E = Convert.ToInt32(sr.ReadLine());
                            if (E < 0) throw new ArgumentException("number of edges in a Graph must be nonnegative");
                            i++;
                        }
                        else
                        {
                            //  for (int j = 0; j < E; j++)
                            //   {
                            string s = sr.ReadLine();
                            Char delimiter = ' ';
                            String[] substrings = s.Split(delimiter);
                            int v = Convert.ToInt32(substrings[0]);
                            int w = Convert.ToInt32(substrings[1]);
                            validateVertex(v);
                            validateVertex(w);
                            addEdge(v, w);
                        }

                    }
                }
            }
            catch (Exception e) { Console.WriteLine("The process failed: {0}", e.ToString()); };



        }
        // throw an IllegalArgumentException unless {@code 0 <= v < V}
        public void validateVertex(int v)
        {
            if (v < 0 || v >= V)
                throw new ArgumentException("vertex " + v + " is not between 0 and " + (V - 1));
        }
        /**
 * Adds the undirected edge v-w to this graph.
 *
 * @param  v one vertex in the edge
 * @param  w the other vertex in the edge
 * @throws IllegalArgumentException unless both {@code 0 <= v < V} and {@code 0 <= w < V}
 */
        public void addEdge(int v, int w)
        {
            validateVertex(v);
            validateVertex(w);
            E++;
            adj[v].push(w);
            adj[w].push(v);
        }
        /**
   * Returns the vertices adjacent to vertex {@code v}.
   *
   * @param  v the vertex
   * @return the vertices adjacent to vertex {@code v}, as an iterable
   * @throws IllegalArgumentException unless {@code 0 <= v < V}
   */
        public IEnumerable<int> adjVerticles(int v)
        {
            validateVertex(v);
            return adj[v];
        }
        /**
   * Returns the degree of vertex {@code v}.
   *
   * @param  v the vertex
   * @return the degree of vertex {@code v}
   * @throws IllegalArgumentException unless {@code 0 <= v < V}
   */
        public int degree(int v)
        {
            validateVertex(v);
            return adj[v].size();
        }
        /**
 * Returns a string representation of this graph.
 *
 * @return the number of vertices <em>V</em>, followed by the number of edges <em>E</em>,
 *         followed by the <em>V</em> adjacency lists
 */
        public String toString()
        {
            StringBuilder s = new StringBuilder();
            s.Append(V + " vertices, " + E + " edges " + "\n");
            for (int v = 0; v < V; v++)
            {
                s.Append(v + ": ");
                foreach (int w in adj[v])
                {
                    s.Append(w + " ");
                }
                s.Append("\n");
            }
            return s.ToString();
        }

    }
}
