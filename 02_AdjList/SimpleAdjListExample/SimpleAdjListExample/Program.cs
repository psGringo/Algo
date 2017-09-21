using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleAdjListExample
{
    class Program
    {
        static void Main(string[] args)
        {
            Node<string> first = new Node<string>();
            Node<string> second = new Node<string>();
            Node<string> third = new Node<string>();

            first.item = "to";
            second.item = "be";
            third.item = "or";

            first.next = second;
            second.next = third;

            // insert to begin of list
            Node<string> oldfirst = first;
            first = new Node<string>();
            first.item = "not";
            first.next = oldfirst;

            //delete from begin
            first = null;

            //insert to the end
            Node<string> oldlast = third;
            third = new Node<string>();
            third.item = "some item";

            // traverse
            for (Node<string> x = first; x != null; x = x.next)
            {
                x.item = "someValue";                
            }

        }
    }

    public class Node<T>
    {
        public T item;
        public Node<T> next;
        
    }


}
