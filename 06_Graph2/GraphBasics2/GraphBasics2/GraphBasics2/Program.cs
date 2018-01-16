using System;

namespace GraphBasics
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello friends");
            try
            {
                Console.WriteLine("hi it is Graph and DFS example");
                Graph g = new Graph("tinyGraph.txt");
                Console.WriteLine(g.ToString());
                Console.ReadLine();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.ReadLine();
            }


        }
    }
}
