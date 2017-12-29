using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GraphBasics2;

namespace GraphBasics2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello friends");
            try
            {
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
