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

        }
    }

    class BinarySearchST<Key, Value> where Key:IComparable
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
        /*
        public Value get(Key key)
        {

        }
        */

        public int rank(Key key, int lo, int hi)
        {
            if (hi < lo) return lo;
            int mid = lo + (hi - lo) / 2;
            int cmp = key.CompareTo(key);
            if (cmp < 0) return rank(key,lo,mid-1);
            if (cmp > 0) return rank(key, mid + 1, hi);
            else return mid;
        }
    }
}
