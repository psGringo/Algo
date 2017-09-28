using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearchExampleSTExample
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

            BinarySearchST<string, int> bst = new BinarySearchST<string, int>(13);
            //adding
            for (int i = 0; i < a.Length; i++)
            {
                bst.put(a[i], i);
            }
            bst.ConsoleDisplay();
            Console.Read();
        }
    }

    class BinarySearchST<Key, Value> where Key : IComparable
    {
        private Key[] keys;
        private Value[] vals;
        private int N;
        public BinarySearchST(int capacity)
        {
            keys = new Key[capacity];
            vals = new Value[capacity];
        }
        public int size()
        {
            return N;
        }

        public bool isEmpty()
        {
            return (N == 0);
        }


        public Value get(Key key)
        {
            if (isEmpty()) return default(Value);
            int i = rank<Key>(key, 0, keys.Length - 1);
            if (i <= N && keys[i].CompareTo(key) == 0) return vals[i];
            else return default(Value);
        }

        public void put(Key key, Value val)
        {
            int i = rank<Key>(key, 0, keys.Length);
            if (i <= N && keys[i].CompareTo(key) == 0) // if found and equal to just change value
            {
                vals[i]=val;
                return;
            }
            for (int j = N; j > i; j--) // if not found - shift values
            {
                keys[j] = keys[j - 1];
                vals[j] = vals[j - 1];
            }
            keys[i] = key;
            vals[i] = val;
            N++;
        }

        public int rank<T>(T key, int lo, int hi) where T : IComparable
        {
            if (hi < lo) return lo;
            int mid = (hi - lo) / 2; //lo + (hi - lo) / 2;
            int cmp = key.CompareTo(keys[mid]);
            if (cmp < 0) { rank<T>(key, lo, mid - 1); }
            else if (cmp > 0) { rank<T>(key, mid + 1, hi); }
            else return mid;
            return -1;
        }

        public void ConsoleDisplay()
        {
            Console.WriteLine();
            Console.WriteLine("key" + " " + "val");
            for (int i=0;i<vals.Length;i++)
            {
                Console.WriteLine(keys[i]+" "+vals[i]);
            }
        }
    }
}
