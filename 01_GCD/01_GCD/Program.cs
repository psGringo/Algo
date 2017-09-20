using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_GCD
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("gcd(10,5)="+gcd(10,5));
            Console.Read();
        }

        public static int gcd(int p, int q)
        {
            if (q == 0) return p;
            int r = p % q;
            return gcd(q, r);
        }

    }
}
