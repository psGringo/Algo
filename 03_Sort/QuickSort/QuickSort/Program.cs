using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickSortExample
{
    class Program
    {
        static void Main(string[] args)
        {
            
            int Count = 100;
            Random r = new Random(100);
            int[] a = new int[Count];
            
            for (int i = 0; i < a.Length; i++)
            {
                a[i] = r.Next(100);
            }
            
            
            
            //quicksort(a,0,a.Length-1); // << works!!

            //QuickSort qs = new QuickSort();
            //qs.execute(ref a, 0, a.Length - 1); // doesn't work

            //int[] a = { 5, 3, 6, 4, 2, 9, 1, 8, 7 };
            //int[]  a = { 5, 3, 6, 4};
           // QuickSort(a,0,a.Length-1); // works!
            qSort(a,0,a.Length-1); // doesn't work

            foreach (int i in a) Console.WriteLine(i);
            Console.ReadLine();
        }

        //-----------------------------------------------


        static void qSort(int[] a, int lo, int hi) // Works!
        // Works! https://habrahabr.ru/sandbox/29775/
        // http://algolist.manual.ru/sort/quick_sort.php
        {
            int i = lo, j = hi;
            int pivIndex = (i + j) / 2; 
            int p = a[pivIndex];

            while (i <= j)
            {
                while (a[i] < p) i++;
                while ((a[j] > p)) j--;

                if (i <= j)
                {
                    int temp = a[i];
                    a[i] = a[j];
                    a[j] = temp;
                    i++;
                    j--;
                }
            }


            /*
            int t = a[pivIndex];
            a[pivIndex] = a[hi];
            a[hi] = t;
        */

            
            if ((j > 0)&&(lo!=pivIndex)) qSort(a, lo, pivIndex); 
            if ((i < hi )&& (hi!= pivIndex)) qSort(a, pivIndex, hi);

          //  if ((j > 0)&&(pivIndex > lo)) qSort(a, lo, pivIndex-1);
          //  if ((i < hi)&&(pivIndex < hi)) qSort(a, pivIndex+1, hi);

        }


        static void QuickSort(int[] a, int lo, int hi) // Works! https://gist.github.com/lbsong/6833729
        {
            if (lo >= hi)
            {
                return;
            }

            int num = a[lo];

            /*
            Console.WriteLine("Before");
            Console.WriteLine("pivot index = "+lo);
            Console.WriteLine("pivot value = " + a[lo]);            
            foreach (int val in a) Console.Write(val+" ");
            Console.WriteLine(" ");
            */

            int i = lo, j = hi;

            while (i < j)
            {
                while (i < j && a[j] >= num)
                {
                    j--;
                }

                a[i] = a[j];

                while (i < j && a[i] <= num)
                {
                    i++;
                }

                a[j] = a[i];
            }
                  
           
            a[i] = num;

            /*
            Console.WriteLine("After");
            Console.WriteLine("pivot index = " + lo);
            Console.WriteLine("pivot value = " + a[lo]);
            Console.WriteLine("i index = " + i);
            Console.WriteLine("j index = " + j);
            foreach (int val in a) Console.Write(val + " ");
            Console.WriteLine(" ");
            */

            QuickSort(a, lo, i - 1);
            QuickSort(a, i + 1, hi);
        }



        //------------------------------------------------

        static int partition(int[] a, int lo, int hi)
        {
            int temp;//swap helper
            int pivot = lo;//divides left and right subarrays
            for (int i = lo; i <= hi; i++)
            {
                if (a[i] < a[hi]) //array[end] is pivot
                {
                    temp = a[pivot]; // swap
                    a[pivot] = a[i];
                    a[i] = temp;
                    pivot += 1;
                }
            }
            //put pivot(array[end]) between left and right subarrays
            temp = a[pivot];
            a[pivot] = a[hi];
            a[hi] = temp;
            return pivot;
        }

        public static void quicksort(int[] a, int lo, int hi)
        {
            if (lo >= hi)
            {
                return;
            }
            int pivot = partition(a, lo, hi);
            quicksort(a, lo, pivot - 1);
            quicksort(a, pivot + 1, hi);
        }

    }

    class QuickSort
    {
        int partition(ref int[] a, int lo, int hi)
        {
            int i = lo;
            int j = hi + 1;
            int pivot = lo;

            while (true)
            {
                while (a[++i] < a[pivot]) if (i == hi) break;
                while (a[--j] > a[pivot]) if (j == lo) break;
                if (i >= j) break;
                // exchange
                
                int temp = a[i];
                a[i] = a[j];
                a[j] = temp;                        
            }

            //put pivot(array[end]) between left and right subarrays
            int t = a[pivot];
            a[pivot] = a[hi];
            a[hi] = t;

            return j;
        }

        public void execute(ref int[] a, int lo, int hi)
        {
            if (lo >= hi)
            {
                return;
            }
            int pivot = partition(ref a, lo, hi);
            execute(ref a, lo, pivot - 1);
            execute(ref a, pivot + 1, hi);
        }

    }
}
