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
            int Count = 10;
            Random r = new Random();
            int[] a = new int[Count];
            
            for (int i = 0; i < a.Length; i++)
            {
                a[i] = r.Next(1000);
            }

            //SelectionSort(ref a);
            //InsertionSort(ref a);
            //BubbleSort(ref a);
            shellSort2(ref a);

            foreach (int i in a) Console.WriteLine(i);
            Console.ReadLine();
            
        }

        static void SelectionSort(ref int[] a) // complexity O(n^2)
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


        static void InsertionSort(ref int[] a) // complexity O(n^2)
        {
            for (int i = 0; i < a.Length; i++)
            {
                
                for (int j = i; j>0; j--)
                {
                    if (a[j] < a[j - 1])
                    {
                        // exchange
                        int temp = a[j];
                        a[j] = a[j-1];
                        a[j-1] = temp;
                    }
                }               
            }
        }


        static void BubbleSort(ref int[] a) // complexity O(n^2)
        {
       
            for (int i = 0; i < a.Length; i++)
            {

                for (int j = 0; j < a.Length-1; j++)
                {
                    if (a[j] > a[j+1])
                    {
                        // exchange
                        int temp = a[j+1];
                        a[j+1] = a[j];
                        a[j] = temp;
                    }
                }
            }           
        }

      

        static void shellSort2(ref int[] a)
        {
            int j;
            int step = a.Length / 2;
            while (step > 0)
            {
                for (int i = 0; i < (a.Length - step); i++)
                {
                    j = i;
                    while ((j >= 0) && (a[j] > a[j + step]))
                    {
                        int tmp = a[j];
                        a[j] = a[j + step];
                        a[j + step] = tmp;
                        j -= step;
                    }
                }
                step = step / 2;
            }
        }





    }
}
