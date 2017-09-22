using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueueOnOneLinkedList
{
    class Program
    {
        static void Main(string[] args)
        {
            // fill stack with Count elements
            int Count = 10;
            CustomQueueOnLinkedList<string> queue = new CustomQueueOnLinkedList<string>();            
            Random r = new Random();
            Console.WriteLine("lets fill queue with Count elements");
            for (int i = 0; i < Count; i++)
            {
                int someRandomNumber = r.Next(100);
                queue.Enque(someRandomNumber.ToString());
            }

            
            // iterator
            foreach (var s in queue) { Console.WriteLine(s.ToString()); }
            
            Console.WriteLine("What size of queue now?");
            Console.WriteLine(queue.size());

            Console.WriteLine("lets take last 5 elements from queue");
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine(queue.Deque());
            }
            Console.WriteLine("What size of queue now?");
            Console.WriteLine(queue.size());
            Console.WriteLine("If queue isEmpty?");
            if (queue.isEmpty()) Console.WriteLine("Yes"); else Console.WriteLine("No");
            
            Console.ReadLine();

        }
    }

    class CustomQueueOnLinkedList<T> : IEnumerable<T>
    {

        Node<T> first;
        Node<T> last;
        private int N;

        class Node<T>
        {
            public T item;
            public Node<T> next;
        }

        public bool isEmpty()
        {
            return ((last == null) || (N == 0));
        }
        public int size()
        {
            return N;
        }

        public void Enque(T item)
        {
            Node<T> lastOld = last;
            last = new Node<T>();
            last.item = item;
            last.next = null;
            if (isEmpty()) first = last;else lastOld.next = last;
            N++;
        }

        public T Deque()
        {
            T item = first.item;
            first = first.next;
            if (isEmpty()) last = null;
            N--;
            return item;
        }

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
