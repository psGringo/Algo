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
            PriorityQueue pq = new PriorityQueue(3);
            pq.Enqueue(1);
            pq.Enqueue(2);
            pq.Enqueue(3);

            Console.WriteLine(pq.Dequeue());
            Console.WriteLine();
            pq.Display();            
            Console.ReadLine();

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

