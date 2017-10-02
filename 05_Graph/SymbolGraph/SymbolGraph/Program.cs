using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SymbolGraphExample
{
    class Program
    {
        static void Main(string[] args)
        {
            SymbolGraph sg = new SymbolGraph("Airports.txt", ' ');
            Console.WriteLine(sg.toString());
            Console.ReadLine();
        }
    }
}
