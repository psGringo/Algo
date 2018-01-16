using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphBasics
{
    public class SymbolGraph
    {
        private Dictionary<string, int> d;
        private string[] keys; // index  -> string
        private Graph G; // the underlying graph
        public SymbolGraph(string filepath, char delimiter)
        {
            d = new Dictionary<string, int>();
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
                            if (!d.ContainsKey(substring))
                                d.Add(substring, d.Count);
                        }
                    }
                }
            }
            catch (Exception e) { Console.WriteLine(e.Message); }
            // inverted index
            keys = new string[d.Count];
            foreach (KeyValuePair<string, int> entry in d)
                keys[entry.Value] = entry.Key;
            // graph
            G = new Graph(d.Count);
            try
            {
                using (StreamReader sr = new StreamReader(filepath))
                {
                    while (sr.Peek() >= 0)
                    {
                        string s = sr.ReadLine();
                        string[] substrings = s.Split(delimiter);
                        int v = d[substrings[0]];
                        int w = d[substrings[1]];
                        /*
                        // or more universal
                        for (var i = 1; i < substrings.Length; i++)
                        {
                            int w = d[substrings[i]];
                        }
                        */
                        G.AddEdge(v, w);
                    }
                }
            }
            catch (Exception e) { Console.WriteLine(e.Message); }
        }
        /**
* Does the graph contain the vertex named {@code s}?
* @param s the name of a vertex
* @return {@code true} if {@code s} is the name of a vertex, and {@code false} otherwise
*/
        public bool Contains(String s)
        {
            // return d.FirstOrDefault(x => x.Key == s).Key!=null; //st.contains(s);
            return d.ContainsKey(s); //st.contains(s);
        }
        /**
* Returns the integer associated with the vertex named {@code s}.
* @param s the name of a vertex
* @return the integer (between 0 and <em>V</em> - 1) associated with the vertex named {@code s}
*/
        public int IndexOf(String s)
        {
            return d.FirstOrDefault(x => x.Key == s).Value;
        }
        /**
* Returns the name of the vertex associated with the integer {@code v}.
* @param  v the integer corresponding to a vertex (between 0 and <em>V</em> - 1) 
* @throws IllegalArgumentException unless {@code 0 <= v < V}
* @return the name of the vertex associated with the integer {@code v}
*/
        public String nameOf(int v)
        {
            //validateVertex(v);
            return keys[v];
        }
        /**
* Returns the graph assoicated with the symbol graph. It is the client's responsibility
* not to mutate the graph.
* @return the graph associated with the symbol graph
*/
        public Graph GetGraph()
        {
            return G;
        }
        private void validateVertex(int v)
        {
            int V = G.V;
            if (v < 0 || v >= V)
                throw new ArgumentException("vertex " + v + " is not between 0 and " + (V - 1));
        }
        public string toString()
        {
            StringBuilder s = new StringBuilder();
            s.Append(G.V + " vertices, " + G.E + " edges " + "\n");

            for (int v = 0; v < G.V; v++)
            {
                s.Append(nameOf(v) + ": ");
                foreach (int w in G.adj[v])
                {
                    s.Append(nameOf(w) + " ");
                }
                s.Append("\n");
            }
            return s.ToString();
        }
    }
}
