using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphBasics2
{
    class DFS
    {
        public Boolean[] IsMarked { get; set; }
        public int Count { get; set; }
        public DFS(Graph G, int v)
        {
            this.IsMarked[] = new Boolean[G.Vertices()];
        }
        private void IsSuchVerticle(Graph G, int v) // is such v in this graph?
        {
            IsMarked[v] = true;
            Count++;
            foreach (var w in G.adj[v]) IsSuchVerticle(G, w);
        }
    }

}
