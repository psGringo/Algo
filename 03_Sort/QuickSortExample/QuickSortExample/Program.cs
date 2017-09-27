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
            int[] a = { 3, 2, 5, 6,7,8,9,10 };
            QuickSortHoar qsh = new QuickSortHoar();
            qsh.Execute(ref a,0,a.Length-1);

            foreach (var val in a) Console.Write(val+" ");
            Console.Read();
        }
    }

    class QuickSortHoar
    {
        void Swap(ref int i,ref int j)
        {
            int temp = i;
            i = j;
            j = temp;
        }

         public void Execute(ref int[] a, int lo, int hi)
        {
            int p = a[(hi - lo) / 2 + lo];            
            int i = lo, j = hi;
            while (i <= j)
            {
                while (a[i] < p && i <= hi) ++i;
                while (a[j] > p && j >= lo) --j;
                if (i <= j)
                {              
                    Swap(ref a[i],ref a[j]);
                    ++i; --j;
                }
            }
            if (j > lo) Execute(ref a, lo, j);
            if (i < hi) Execute(ref a, i, hi);
        }
    }
}

//

/*
 *        int partition(ref int[] a,int lo,int hi)
    {

        int pivot = a[lo];
        int i = lo-1;
        int j = hi+1;

        while (i<=j)
        {
            //  while (a[++i] <= pivot) { if (i == hi) break; } //do { i++; } 
            //  while (a[--j] >= pivot) { if (j == lo) break; } //do { j--; } 
            while (a[++i] < pivot && i <= hi) { if (i == hi) break; }
            while (a[--j] > pivot && j >= lo) { if (j == lo) break; }
            if (i <= j)
            {
                swap(ref a[i], ref a[j]);
                ++i;++j;
                return j;
            }

        }
        return j;
    }

    public void Execute(ref int[] a, int lo, int hi)
    {
        if (lo < hi) 
        {
           int p = partition(ref a,lo,hi);
           Execute(ref a,lo,p);
           Execute(ref a, p, hi);
        }
    }
 * 
 * 
 */
