using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SymbolGraphExample
{


    public class SymbolGraph
    {
        private SequentialSearchST<String, int> st;  // string -> index
        //private Dictionary<String, int> d;
        private string[] keys;           // index  -> string
        private Graph graph;             // the underlying graph

        public SymbolGraph(string filepath, char delimiter)
        {
            st = new SequentialSearchST<String, int>();
          //  d = new Dictionary<String, int>();

            try
            {
                using (StreamReader sr = new StreamReader(filepath))
                {
                    while (sr.Peek() >= 0)
                    {
                        string s = sr.ReadLine();
                        string[] substrings = s.Split(delimiter);
                        foreach (var substring in substrings)
                        {
                            if (st.get(substring)==0)
                                st.put(substring, st.size());
                            //if (!d.ContainsKey(substring))
                            //    st.put(substring, st.size());                            
                        }
                        
                    }
                }
            }

            catch (Exception e) { Console.WriteLine("The process failed: {0}", e.ToString()); };
            
            // inverted index to get string keys in an aray
            keys = new string[st.size()];
            foreach (string name in st.keys())
            {
                keys[st.get(name)] = name;
            }
            
            // building graph in second reading file
            graph = new Graph(st.size());
            try
            {
                using (StreamReader sr = new StreamReader(filepath))
                {
                    while (sr.Peek() >= 0)
                    {
                        string s = sr.ReadLine();
                        string[] substrings = s.Split(delimiter);
                        int v = st.get(substrings[0]);
                        for (var i = 0; i < substrings.Length; i++)
                        {
                            int w = st.get(substrings[i]);
                            graph.addEdge(v,w);
                        }                        
                    }
                }
            }

            catch (Exception e) { Console.WriteLine("The process failed: {0}", e.ToString()); };

        }
        /**
 * Does the graph contain the vertex named {@code s}?
 * @param s the name of a vertex
 * @return {@code true} if {@code s} is the name of a vertex, and {@code false} otherwise
 */
        public bool contains(String s)
        {
            return st.contains(s);
        }
        /**
   * Returns the integer associated with the vertex named {@code s}.
   * @param s the name of a vertex
   * @return the integer (between 0 and <em>V</em> - 1) associated with the vertex named {@code s}
   */
        public int indexOf(String s)
        {
            return st.get(s);
        }
        /**
 * Returns the name of the vertex associated with the integer {@code v}.
 * @param  v the integer corresponding to a vertex (between 0 and <em>V</em> - 1) 
 * @throws IllegalArgumentException unless {@code 0 <= v < V}
 * @return the name of the vertex associated with the integer {@code v}
 */
        public String nameOf(int v)
        {
            validateVertex(v);
            return keys[v];
        }
        /**
 * Returns the graph assoicated with the symbol graph. It is the client's responsibility
 * not to mutate the graph.
 * @return the graph associated with the symbol graph
 */
        public Graph getGraph()
        {
            return graph;
        }
        // throw an IllegalArgumentException unless {@code 0 <= v < V}
        private void validateVertex(int v)
        {
            int V = graph.V;
            if (v < 0 || v >= V)
                throw new ArgumentException("vertex " + v + " is not between 0 and " + (V - 1));
        }

        public string toString()
        {
            StringBuilder s = new StringBuilder();
            s.Append(graph.V + " vertices, " + graph.E + " edges " + "\n");
            
            for (int v = 0; v < graph.V; v++)
            {
                s.Append(nameOf(v) + ": ");
                foreach (int w in graph.adjVerticles(v))
                {                    
                    s.Append(nameOf(w) + " ");
                }
                s.Append("\n");
            }
            return s.ToString();
        }

    }
}
