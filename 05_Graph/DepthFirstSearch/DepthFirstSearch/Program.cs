using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchInGraphExample
{
    class Program
    {
        static void Main(string[] args)
        {
            Graph g = new Graph("tinyG.txt");
            Console.WriteLine(g.toString());
            //testDFS(g);
            testBFS(g);
            Console.ReadLine();

        }

        static void testBFS(Graph g)
        {
            BreadthFirstPaths bfp = new BreadthFirstPaths(g);
            // graph consists of 3 parts so we start search since 3 start elements
            bfp.bfs(g, 0);
            Console.WriteLine();
            bfp.bfs(g, 7);
            Console.WriteLine();
            bfp.bfs(g, 9);
        }

        static void testDFS(Graph g)
        {
            
            Console.WriteLine("Which verticles are marked?");
            DepthFirstSearch dfs = new DepthFirstSearch(g);

            // graph consists of 3 parts so we start search since 3 start elements
            dfs.dfs(g, 0);
            
            Console.WriteLine();
            dfs.dfs(g, 7); // will write to console if verticle marked
            Console.WriteLine();
            
            dfs.dfs(g, 9); // will write to console if verticle marked
            Console.WriteLine();

            dfs.unmarkAll();
            Console.WriteLine("Is verticle 12 in graph?");
            if (dfs.isVertex(g, 9, 12)) Console.WriteLine("Yes"); else Console.WriteLine("No");
            Console.Read();
        }
    }
}
