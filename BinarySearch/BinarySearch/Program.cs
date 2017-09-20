using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearch
{
    class Program
    {
        static void Main(string[] args)
        {
            // init Random Array
            int Count=1000000;
            int MinValue=7;
            int MaxValue=1000;
            int nSteps = 0;
            Random r = new Random();

            int[] a = new int[Count];
            for (int i = 0; i < Count; i++)
            {
                a[i]=r.Next(MinValue,MaxValue);
            }

            // use of BinarySearch
            Array.Sort(a);            
            //foreach (int i in a) Console.WriteLine(i);
            if (BinarySearch(5, a,ref nSteps) != -1) Console.WriteLine("Element found");
            else Console.WriteLine("Element not found!");
            Console.WriteLine("Number of steps " + nSteps);
            Console.ReadLine();

        }

        static int BinarySearch(int key, int[] a, ref int nSteps)
        {
            int low = 0;
            int hi = a.Length - 1;
            nSteps = 0;

            while (low<=hi)
            {
                nSteps++;
                int mid = (low + hi) / 2;
                if (key < a[mid]) hi = mid - 1;
                else if (key > a[mid]) low = mid + 1;
                else return mid;
            }
            return -1;
        }

    }
}
