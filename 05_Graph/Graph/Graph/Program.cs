using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphExample
{
    class Program
    {
        static void Main(string[] args)
        {
            Graph g = new Graph("123.txt");
            Console.WriteLine(g.toString());
            Console.Read();
        }
    }
}
