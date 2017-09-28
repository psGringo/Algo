using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchTableExample
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }

    class ST<Key,Value>:IEnumerable<Key>
    {
        private int N=0;
        private Value[] a;

        ST(int ACapacity)
        {
            a=new Value[ACapacity];
        }

        void Put(Key key, Value value)
        {
            // some implementation
        }

        Value get(Key key)
        {
            // some implementation
        }

        void delete(Key key)
        {
            Put(key, null);
        }

        void contains(Key key)
        {

        }

        bool isEmpty()
        {
            return (N == 0);
        }

        int size()
        {
            return N;
        }

        // also iteration support
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return a.GetEnumerator();
        }

        
        public IEnumerator<Key> GetEnumerator()
        {
            //return a.GetEnumerator;
            foreach(var val in a)
            {
                yield return val;
            }
            /*
            var node = first;
            while (node != null)
            {
                yield return node.item;
                node = node.next;
            }
            */
            
        }
        
    }
}
