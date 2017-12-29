using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphBasics2
{
    class Graph
    {
        public int V { get; set; }
        public int E { get; set; }
        public Bag<int>[] adj;
        public Graph(int V)
        {
            if (V < 0)
            {
                throw new ArgumentException();
            }

            this.V = V;
            this.E = 0;
            adj = new Bag<int>[V];
            for (int v = 0; v <= V; v++)
            {
                adj[v] = new Bag<int>();
            }
        }
        public Graph(string aFilePath)
        {
       
            if (!File.Exists(aFilePath)) throw new Exception("file not exists");
            string[] ReadText = File.ReadAllLines(aFilePath);
            this.V = Convert.ToInt32(ReadText[0]);
            this.E = 0; //Convert.ToInt32(ReadText[1]);
            // init adj obj
            adj = new Bag<int>[V];
            for (int v = 0; v < V; v++)
            {
                adj[v] = new Bag<int>();
            }
            for (var i = 2; i < ReadText.Length; i++)
            {
                string[] splitted;
                splitted = ReadText[i].Split(' ');
                //if (splitted.Count<string> = 2)
                {
                    int v = Convert.ToInt32(splitted[0]);
                    int w = Convert.ToInt32(splitted[1]);
                    this.AddEdge(v, w);
                }

            }
        }
        // vertices and edges
        public int Vertices() { return V; }
        public int Edges() { return E; }
        public void ValidateVertex(int v)
        {
            if (v < 0 || v > V) { throw new ArgumentException(); }
        }
        // adding undirected edge to the graph
        public void AddEdge(int v, int w)
        {
            ValidateVertex(v);
            ValidateVertex(w);
            E++;
            adj[v].Push(w);
            adj[w].Push(v);
        }
        //returns vertices adjacent to vertex
        public Bag<int> AdjacentVerticles(int v)
        {
            ValidateVertex(v);
            return adj[v];
        }
        // returns degree of vertex
        public int Degree(int v)
        {
            ValidateVertex(v);
            return adj[v].Size();
        }
        // returns string representation of Graph
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(V + " vertices, " + E + " edges " + "\n");
            for (var v = 0; v < V; v++)
            {
                sb.Append(v + ":");
                foreach (int w in adj[v])
                {
                    sb.Append(w + " ");
                }
                sb.AppendLine();
            }
            return sb.ToString();
        }
    }
}
