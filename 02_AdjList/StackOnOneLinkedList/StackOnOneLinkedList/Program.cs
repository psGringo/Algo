using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackOnOneLinkedList
{
    class Program
    {
        static void Main(string[] args)
        {
            // fill stack with Count elements
            int Count = 10;
            CustomStackLinkedList<string> stack = new CustomStackLinkedList<string>();
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


        }
    }

    class CustomStackLinkedList<T> : IEnumerable<T>
    {
        Node<T> first;
        private int N;
        class Node<T>
        {
            public T item;
            public Node<T> next;
        }

        public bool isEmpty() { return (first == null) || (N == 0); }
        public int size() { return N; }
        public void push(T item)
        {
            // adding to the begining
            Node<T> oldfirst = first;
            first = new Node<T>();
            first.item = item;
            first.next = oldfirst;
            N++;
        }

        public T pop()
        {
            T item = first.item;
            first = first.next;
            N--;
            return item;
        }


        /*
        IEnumerator IEnumerable.GetEnumerator()
        {
            //throw new NotImplementedException();
        }
    */

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public IEnumerator<T> GetEnumerator()
        {
            var node = first;
            while (node != null)
            {
                yield return node.item;
                node = node.next;
            }
        }

    }

}
