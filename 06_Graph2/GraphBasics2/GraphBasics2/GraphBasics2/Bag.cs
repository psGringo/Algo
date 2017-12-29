using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphBasics2
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
        public bool IsEmpty() { return (first == null) || (N == 0); }
        public int Size() { return N; }
        public void Push(T item) // adding to the begining always
        {
            Node<T> tempNode = first;
            first = new Node<T>();
            first.item = item;
            first.next = tempNode;
            N++;
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
