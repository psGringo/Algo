using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SequentialSearchSTExample_OnLinkedList
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] a =  {
                "S",
                "E",
                "A",
                "R",
                "C",
                "H",
                "E",
                "X",
                "A",
                "M",
                "P",
                "L",
                "E"
            };

            SequentialSearchST<string, int> st = new SequentialSearchST<string, int>();

            //adding
            for (int i = 0; i < a.Length; i++)
            {
                st.put(a[i], i);
            }
            st.ConsoleDisplay();
            st.Delete("L");
            //st.ConsoleDisplay();
            // testing iterator
            Console.WriteLine();
            foreach (var val in st) Console.WriteLine(val);

            Console.Read();
        }
    }

    public class SequentialSearchST<Key, Value> : IEnumerable<Key>
    {
        private Node first;
        private class Node
        {
            public Key key;
            public Value val;
            public Node next;

            public Node(Key key, Value val, Node next)
            {
                this.key = key;
                this.val = val;
                this.next = next;
            }
        }

        public Value get(Key key)
        {
            for (Node x = first; x != null; x = x.next)
            {
                if (key.Equals(x.key)) return x.val;
            }
            return default(Value);// null
        }

        public void put(Key key, Value val)
        {
            for (Node x = first; x != null; x = x.next)
            {
                if (key.Equals(x.key)) { x.val = val; return; }
            }
            first = new Node(key, val, first); // adding to the start of list
        }

        public void ConsoleDisplay()
        {
            Console.WriteLine();
            Console.WriteLine("key" + " " + "val");
            for (Node n = first; n != null; n = n.next)
            {
                Console.WriteLine(" " + n.key + "  " + n.val);
            }
        }

        public int size()
        {
            int i = 0;
            for (Node n = first; n != null; n = n.next)
            {
                i++;
            }
            return i;
        }

        public void Delete(Key key)
        {
            Node beforeNode = null;

            // node before
            for (Node n = first; n != null; n = n.next)
            {

                // if first node
                if ((key.Equals(n.key)) && (n == first))
                {
                    //delete first node
                    first = n.next;
                    n = n.next;
                    return;
                }

                // if last node
                if ((key.Equals(n.key)) && (n.next == null))
                {
                    beforeNode.next = null;
                    return;
                }

                // if some middle node
                if ((key.Equals(n.key)) && (n.next != null))
                {

                    beforeNode.next = n.next;
                    return;
                }

                beforeNode = n;
            }

        }


        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }


        public IEnumerator<Key> GetEnumerator()
        {
            var node = first;
            while (node != null)
            {
                yield return node.key;
                node = node.next;
            }
        }

    }
}
