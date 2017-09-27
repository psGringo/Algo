using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriorityQueueExample
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            PriorityQueue pq = new PriorityQueue(3);
            pq.Enqueue(1);
            pq.Enqueue(2);
            pq.Enqueue(3);

            Console.WriteLine(pq.Dequeue());
            Console.WriteLine();
            pq.Display();
           */
          //  int[] a =  { 5, 2, 7, 10 };
            PyramidSort2 ps = new PyramidSort2();

            Int32[] arr = new Int32[100];
            //заполняем массив случайными числами
            Random rd = new Random();
            for (Int32 i = 0; i < arr.Length; ++i)
            {
                arr[i] = rd.Next(1, 101);
            }
            System.Console.WriteLine("The array before sorting:");
            foreach (Int32 x in arr)
            {
                System.Console.Write(x + " ");
            }
            //сортировка
            ps.Pyramid_Sort(arr, arr.Length);

            System.Console.WriteLine("\n\nThe array after sorting:");
            foreach (Int32 x in arr)
            {
                System.Console.Write(x + " ");
            }
            System.Console.WriteLine("\n\nPress the <Enter> key");
            System.Console.ReadLine();
            //foreach (var val in a) Console.Write(val);

            Console.ReadLine();

        }
    }


     class PyramidSort2
    {
         Int32 add2pyramid(Int32[] a, Int32 i, Int32 N)
        {
            Int32 imax;
            Int32 temp;
            if ((2 * i + 2) < N)
            {
                if (a[2 * i + 1] < a[2 * i + 2]) imax = 2 * i + 2;
                else imax = 2 * i + 1;
            }
            else imax = 2 * i + 1;

            if (imax >= N) return i;

            if (a[i] < a[imax])
            {
                temp = a[i];
                a[i] = a[imax];
                a[imax] = temp;

                if (imax < N / 2) i = imax;
            }
            return i;
        }


        public void Pyramid_Sort(Int32[] arr, Int32 len)
        {
            //step 1: building the pyramid
            for (Int32 i = len / 2 - 1; i >= 0; --i)
            {
                long prev_i = i;
                i = add2pyramid(arr, i, len);
                if (prev_i != i) ++i;
            }

            //step 2: sorting
            Int32 buf;
            for (Int32 k = len - 1; k > 0; --k)
            {
                buf = arr[0];
                arr[0] = arr[k];
                arr[k] = buf;
                Int32 i = 0, prev_i = -1;
                while (i != prev_i)
                {
                    prev_i = i;
                    i = add2pyramid(arr, i, k);
                }
            }
        }

    }


    class PyramidSort
    {
        public void Execute(ref int[] a)
        {
            int N = a.Length;
            for (int k = N / 2; k >= 1; k--)
            {
                sink(ref a, k, N);
            }

            while (N > 1)
            {
                swap(ref a,1,N--);
                sink(ref a, 1, N);
            }
        }

        void sink(ref int[] a, int k, int N)
        {
            while (2 * k <= N)
            {
                int j = 2 * k;
                if ((j < N) && (j < j + 1)) j++;
                if (!(k < j)) break;                
                swap(ref a,k, j);
                k = j;
            }
        }
        private void swap(ref int[] a, int i, int j)
        {
            int temp = a[i];
            a[i] = a[j];
            a[j] = temp;
        }
    }

    class PriorityQueue
    {
        private int[] pq; // inside array pyramid binary tree
        private int N = 0; // pq[0] not used

        public void Display()
        {
            foreach (int val in pq) Console.Write(val+" ");
        }

        public PriorityQueue(int maxN)
        {
            pq = new int[maxN + 1];
        }

        public bool isEmpty()
        {
            return N == 0;
        }

        public int size()
        {
            return N;
        }

        public void Enqueue(int el)
        {
            pq[++N] = el;
            swimUp(N);
        }

        public int Dequeue()
        {
            int max = pq[1];
            Swap(1, N--);
            //pq[N + 1] = null;
            swimDown(1);
            return max;
        }

        private void Swap(int i,int j)
        {            
            int temp = pq[i];
            pq[i] = pq[j];
            pq[j] = temp;
        }

        private void swimUp(int k)
        {
            while ((k > 1) && (pq[k / 2] < pq[k]))
            {                
                Swap(k/2,k);                
                k = k / 2;
            }
        }

        private void swimDown(int k)
        {
            while (2 * k <= N)
            {
                int j = 2 * k;
                if ((j < N) && (j < j + 1)) j++;
                if (!(k < j)) break;
                //swap
                Swap(k,j);               
                k = j;
            }
        }


    }
}

