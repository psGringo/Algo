using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepthFirstSearch
{
    class Program
    {
        static void Main(string[] args)
        {
            Graph g = new Graph("tinyG.txt");
            
            Console.WriteLine(g.toString());
            Console.WriteLine("Which verticles are marked?");
            DepthFirstSearch dfs = new DepthFirstSearch(g);
            dfs.dfs(g,0);
            Console.WriteLine();
            dfs.dfs(g, 7);
            Console.WriteLine();
            dfs.dfs(g, 9);
            Console.WriteLine();
            dfs.unmarkAll();
            Console.WriteLine("Is verticle 12 in graph?");
            if (dfs.isVertex(g, 9, 12)) Console.WriteLine("Yes"); else Console.WriteLine("No");
            Console.Read();
        }
    }
}
