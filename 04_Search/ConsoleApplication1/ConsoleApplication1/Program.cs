using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeparateChainingHashSTExample
{
    class Program
    {
        static void Main(string[] args)
        {
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
            SeparateChainingHashST<string, int> st = new SeparateChainingHashST<string, int>(10);
            for (int i = 0; i < a.Length; i++)
            {
                st.put(a[i], i);
            }

            //what is inside?
            st.ConsoleDisplay();
            Console.Read();

        }

        static int hash(string s)
        {
            int a = 0x7FFFFFFF;
            return (s.GetHashCode() * a % 5);
        }
    }
}
