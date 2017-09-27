using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MergeSort
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
                a[i] = r.Next(100);
            }

            MergeSort ms = new MergeSort();
            //ms.Execute(ref a,true);
            ms.Execute(ref a, false);

            foreach (int i in a) Console.WriteLine(i);
            Console.ReadLine();
        }

        
    }

    public class MergeSort
    {

        private int[] aux;

        public void Execute(ref int[] a,bool UpDownComing)
        {
            aux = new int[a.Length];
            if (UpDownComing) SortDownComing(a, 0, a.Length-1);

        }

        void SortDownComing(int[] a,int lo,int hi) // << !!! NOT DESC
        {
            if (hi <= lo) return;
            int mid = lo + (hi - lo) / 2;
            // Console.WriteLine("Sort a " + lo + " " + hi);
            SortDownComing(a, lo, mid);
            SortDownComing(a, mid+1, hi);
            Merge(a,lo,mid,hi);
        }

        void SortUpComing(int[] a) // // << !!! NOT ASC
        {
            int N = a.Length;
            for (int sz = 1; sz <= N; sz = 2 * sz)
            {
                for (int lo = 0; lo <= N - sz; lo += 2 * sz)
                {
                    Merge(a, lo, lo + sz - 1, Math.Min(lo + 2 * sz - 1, N - 1));
                }
            }
        }

        public void Merge(int[] a, int lo, int mid, int hi)
        {
            Console.WriteLine("Merge a " + lo + " "+mid+" " + hi);
            int i = lo, j = mid + 1;            
            for (int k = lo; k <= hi; k++) aux[k] = a[k];            
            for (int k = lo; k <= hi; k++)
            {
                if (i > mid) a[k] = aux[j++];  // left data is over, get data from right
                else if(j > hi) a[k] = aux[i++]; //right data is over, get data from left
                else if (aux[j] < aux[i]) a[k] = aux[j++]; // key from right  < key from left - get data from right
                else a[k] = aux[i++]; // key from right  >= key from left - get data from left
            }
        }

    }


}
