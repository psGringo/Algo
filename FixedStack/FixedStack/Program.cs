using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FixedStack
{
    class Program
    {
        static void Main(string[] args)
        {
            FixedGenericsStack<int> stack = new FixedGenericsStack<int>(100);
            int N = 50;
            while (N >0)
            {
                stack.push(N % 2);
                N = N / 2;
            }
            

            foreach (var s in stack) Console.WriteLine(s);
            Console.ReadLine();
            /*
               // fill stack with Count elements
               int Count = 10;
               FixedCapacityStackOfStrings stack = new FixedCapacityStackOfStrings(Count);
               //FixedGenericsStack<string> stack = new FixedGenericsStack<string>(Count);
               Random r = new Random();
               Console.WriteLine("lets fill stack with Count elements");
               for (int i = 0; i < Count; i++)
               {
                   int someRandomNumber = r.Next(100);
                   stack.push(someRandomNumber.ToString());                
               }

               // iterator
               foreach (var s in stack) { Console.WriteLine(s.ToString()); }

               Console.WriteLine("What size of stack now?");
               Console.WriteLine(stack.size());

               Console.WriteLine("lets take last 5 elements from stack");
               for (int i = 0; i < 5; i++)
               {
                   Console.WriteLine(stack.pop());
               }
               Console.WriteLine("What size of stack now?");
               Console.WriteLine(stack.size());
               Console.WriteLine("If stack isEmpty?");
               if (stack.isEmpty()) Console.WriteLine("Yes"); else Console.WriteLine("No");

               Console.ReadLine();
               */
        }

    }

    class FixedCapacityStackOfStrings:IEnumerable
    {
        private string[] a;
        public int N;
        public FixedCapacityStackOfStrings(int ACapacity)
        {
            a = new string[ACapacity];
        }
        public bool isEmpty() { return N == 0; }
        public bool isFull() { return N == a.Length; }
        public int size() { return N; }
        public void push(string item)
        {
            a[N++] = item;
        }
        public string pop()
        {
            return a[--N];
        }

        public IEnumerator GetEnumerator()
        {
            //throw new NotImplementedException();
            return a.GetEnumerator();
        }
    }

    class FixedGenericsStack<T>:IEnumerable
    {
        private T[] a;
        public int N;
        public FixedGenericsStack(int ACapacity)
        {
            a = new T[ACapacity];
        }
        public bool isEmpty() { return N == 0; }
        public bool isFull() { return N == a.Length; }
        public int size() { return N; }
        public void push(T item)
        {
            if (N == a.Length) resize(2 * a.Length);
            a[N++] = item;
        }
        public T pop()
        {
            T item = a[--N];            
            if (N > 0 && N == a.Length / 4) resize(a.Length / 2);
            return item;
        }

        public void resize(int max)
        {
            // N <= max
            T[] temp = new T[max];
            for (int i = 0; i < N; i++)
            {
                temp[i] = a[i];
            }
            a = temp;
        }

        public IEnumerator GetEnumerator()
        {
            //throw new NotImplementedException();
            return a.GetEnumerator();
        }
    }


}
