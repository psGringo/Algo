using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinearProbingHashST
{
    class Program
    {
        static void Main(string[] args)
        {
            LinearProbingHashST<string, int> lp = new LinearProbingHashST<string, int>(16);
            string[] a =  {
                "S",
                "E",
                "A",
                "R",
                "C",
                "H",
                "E",
                "X",
                "A",
                "M",
                "P",
                "L",
                "E"
            };
           
            for (int i = 0; i < a.Length; i++)
            {
                lp.put(a[i], i);
            }
            lp.ConsoleDisplay();
            Console.ReadLine();
        }
    }
}
