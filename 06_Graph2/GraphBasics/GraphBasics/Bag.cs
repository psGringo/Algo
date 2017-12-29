using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphBasics
{
    class Bag<T> : IEnumerable<T>
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
            Node<T> temp = first;
            first = new Node<T>();
            first.item = item;
            first.next = temp;
            N++;
        }
        // enumerators
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
