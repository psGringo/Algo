using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortExamplesSelectionSort
{
    class Program
    {
        static void Main(string[] args)
        {
            int Count = 100;
            Random r = new Random();
            int[] a = new int[Count];
            
            for (int i = 0; i < a.Length; i++)
            {
                a[i] = r.Next(1000);
            }

            SelectionSort(ref a);

            foreach (int i in a) Console.WriteLine(i);
            Console.ReadLine();
            
        }

        static void SelectionSort(ref int[] a)
        {
            for (int i = 0; i < a.Length; i++)
            {
                int min = i;
                // find min
                for (int j = i; j < a.Length; j++)
                {
                    if (a[j] < a[min]) min = j;
                }

                // exchange
                int temp = a[i];
                a[i] = a[min];
                a[min] = temp;
            }
        }
    }
}
