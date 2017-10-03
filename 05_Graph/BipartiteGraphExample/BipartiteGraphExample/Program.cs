using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BipartiteGraphExample
{
    class Program
    {
        static void Main(string[] args)
        {
            Graph g = new Graph("tinyG.txt");
            Console.WriteLine(g.toString());
            Bipartite b = new Bipartite(g);
            if (b.isBipartite) Console.WriteLine("Yes! Bipartite!");
            else Console.WriteLine("Not Bipartite");
            b.showCycle();
            Console.ReadLine();
        }
    }
}
