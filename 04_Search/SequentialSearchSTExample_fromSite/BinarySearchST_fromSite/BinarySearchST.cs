using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearchST_fromSite
{
    //public class SequentialSearchST<Key, Value> : IEnumerable<Key>
    public class BinarySearchST<Key, Value>: IEnumerable<Key> where Key : IComparable
    {
        private static int INIT_CAPACITY = 2;
        private Key[] keys;
        private Value[] vals;
        private int n = 0;

        /**
   * Initializes an empty symbol table.
   */
        public BinarySearchST()
        {
            keys = new Key[INIT_CAPACITY];
            vals = new Value[INIT_CAPACITY];
        }
        /**
 * Initializes an empty symbol table with the specified initial capacity.
 * @param capacity the maximum capacity
 */
        public BinarySearchST(int capacity)
        {
            keys = new Key[capacity];
            vals = new Value[capacity];
        }
        // resize the underlying arrays
        private void resize(int capacity)
        {
            Trace.Assert(capacity >= n, "Error, capacity < n");
            Key[] tempk = new Key[capacity];
            Value[] tempv = new Value[capacity];
            for (int i = 0; i < n; i++)
            {
                tempk[i] = keys[i];
                tempv[i] = vals[i];
            }
            vals = tempv;
            keys = tempk;
        }
        /**
    * Returns the number of key-value pairs in this symbol table.
    *
    * @return the number of key-value pairs in this symbol table
    */
        public int size()
        {
            return n;
        }

        /**
         * Returns true if this symbol table is empty.
         *
         * @return {@code true} if this symbol table is empty;
         *         {@code false} otherwise
         */
        public bool isEmpty()
        {
            return size() == 0;
        }

        /**
 * Does this symbol table contain the given key?
 *
 * @param  key the key
 * @return {@code true} if this symbol table contains {@code key} and
 *         {@code false} otherwise
 * @throws IllegalArgumentException if {@code key} is {@code null}
 */
        public bool contains(Key key)
        {
            if (key == null) throw new ArgumentException("argument to contains() is null");
            return get(key) != null;
        }

        /**
     * Returns the value associated with the given key in this symbol table.
     *
     * @param  key the key
     * @return the value associated with the given key if the key is in the symbol table
     *         and {@code null} if the key is not in the symbol table
     * @throws IllegalArgumentException if {@code key} is {@code null}
     */
        public Value get(Key key)
        {
            if (key == null) throw new ArgumentException("argument to get() is null");
            if (isEmpty()) return default(Value);
            int i = rank(key);
            if (i < n && keys[i].CompareTo(key) == 0) return vals[i];
            return default(Value);
        }
        /**
  * Returns the number of keys in this symbol table strictly less than {@code key}.
  *
  * @param  key the key
  * @return the number of keys in the symbol table strictly less than {@code key}
  * @throws IllegalArgumentException if {@code key} is {@code null}
  */
        public int rank(Key key)
        {
            if (key == null) throw new ArgumentException("argument to rank() is null");

            int lo = 0, hi = n - 1;
            while (lo <= hi)
            {
                int mid = lo + (hi - lo) / 2;
                int cmp = key.CompareTo(keys[mid]);
                if (cmp < 0) hi = mid - 1;
                else if (cmp > 0) lo = mid + 1;
                else return mid;
            }
            return lo;
        }
        /**
   * Inserts the specified key-value pair into the symbol table, overwriting the old 
   * value with the new value if the symbol table already contains the specified key.
   * Deletes the specified key (and its associated value) from this symbol table
   * if the specified value is {@code null}.
   *
   * @param  key the key
   * @param  val the value
   * @throws IllegalArgumentException if {@code key} is {@code null}
   */
        public void put(Key key, Value val)
        {
            if (key == null) throw new ArgumentException("first argument to put() is null");

            if (val == null)
            {
                delete(key);
                return;
            }

            int i = rank(key);

            // key is already in table
            if (i < n && keys[i].CompareTo(key) == 0)
            {
                vals[i] = val;
                return;
            }

            // insert new key-value pair
            if (n == keys.Length) resize(2 * keys.Length);

            for (int j = n; j > i; j--)
            {
                keys[j] = keys[j - 1];
                vals[j] = vals[j - 1];
            }
            keys[i] = key;
            vals[i] = val;
            n++;

            Trace.Assert(check());
        }

        /**
  * Removes the specified key and associated value from this symbol table
  * (if the key is in the symbol table).
  *
  * @param  key the key
  * @throws IllegalArgumentException if {@code key} is {@code null}
  */
        public void delete(Key key)
        {
            if (key == null) throw new ArgumentException("argument to delete() is null");
            if (isEmpty()) return;

            // compute rank
            int i = rank(key);
            // key not in table
            if (i == n || keys[i].CompareTo(key) != 0)
            {
                return;
            }
            for (int j = i; j < n - 1; j++)
            {
                keys[j] = keys[j + 1];
                vals[j] = vals[j + 1];
            }
            n--;
            keys[n] = default(Key);  // to avoid loitering
            vals[n] = default(Value);
            // resize if 1/4 full
            if (n > 0 && n == keys.Length / 4) resize(keys.Length / 2);
            Trace.Assert(check());
        }

        /**
  * Removes the smallest key and associated value from this symbol table.
  *
  * @throws NoSuchElementException if the symbol table is empty
  */
        public void deleteMin()
        {
            if (isEmpty()) throw new ArgumentException("Symbol table underflow error");
            delete(min());
        }

        /**
         * Removes the largest key and associated value from this symbol table.
         *
         * @throws NoSuchElementException if the symbol table is empty
         */
        public void deleteMax()
        {
            if (isEmpty()) throw new ArgumentException("Symbol table underflow error");
            delete(max());
        }

        /***************************************************************************
    *  Ordered symbol table methods.
    ***************************************************************************/

        /**
          * Returns the smallest key in this symbol table.
          *
          * @return the smallest key in this symbol table
          * @throws NoSuchElementException if this symbol table is empty
          */
        public Key min()
        {
            if (isEmpty()) throw new ArgumentException("called min() with empty symbol table");
            return keys[0];
        }

        /**
         * Returns the largest key in this symbol table.
         *
         * @return the largest key in this symbol table
         * @throws NoSuchElementException if this symbol table is empty
         */
        public Key max()
        {
            if (isEmpty()) throw new ArgumentException("called max() with empty symbol table");
            return keys[n - 1];
        }

        /**
         * Return the kth smallest key in this symbol table.
         *
         * @param  k the order statistic
         * @return the {@code k}th smallest key in this symbol table
         * @throws IllegalArgumentException unless {@code k} is between 0 and
         *        <em>n</em>–1
         */
        public Key select(int k)
        {
            if (k < 0 || k >= size())
            {
                throw new ArgumentException("called select() with invalid argument: " + k);
            }
            return keys[k];
        }

        /**
         * Returns the largest key in this symbol table less than or equal to {@code key}.
         *
         * @param  key the key
         * @return the largest key in this symbol table less than or equal to {@code key}
         * @throws NoSuchElementException if there is no such key
         * @throws IllegalArgumentException if {@code key} is {@code null}
         */
        public Key floor(Key key)
        {
            if (key == null) throw new ArgumentException("argument to floor() is null");
            int i = rank(key);
            if (i < n && key.CompareTo(keys[i]) == 0) return keys[i];
            if (i == 0) return default(Key);
            else return keys[i - 1];
        }

        /**
         * Returns the smallest key in this symbol table greater than or equal to {@code key}.
         *
         * @param  key the key
         * @return the smallest key in this symbol table greater than or equal to {@code key}
         * @throws NoSuchElementException if there is no such key
         * @throws IllegalArgumentException if {@code key} is {@code null}
         */
        public Key ceiling(Key key)
        {
            if (key == null) throw new ArgumentException("argument to ceiling() is null");
            int i = rank(key);
            if (i == n) return default(Key);
            else return keys[i];
        }

        /**
         * Returns the number of keys in this symbol table in the specified range.
         *
         * @param lo minimum endpoint
         * @param hi maximum endpoint
         * @return the number of keys in this symbol table between {@code lo} 
         *         (inclusive) and {@code hi} (inclusive)
         * @throws IllegalArgumentException if either {@code lo} or {@code hi}
         *         is {@code null}
         */
        public int size(Key lo, Key hi)
        {
            if (lo == null) throw new ArgumentException("first argument to size() is null");
            if (hi == null) throw new ArgumentException("second argument to size() is null");

            if (lo.CompareTo(hi) > 0) return 0;
            if (contains(hi)) return rank(hi) - rank(lo) + 1;
            else return rank(hi) - rank(lo);
        }


        /***************************************************************************
  *  Check internal invariants.
  ***************************************************************************/

        private bool check()
        {
            return isSorted() && rankCheck();
        }

        // are the items in the array in ascending order?
        private bool isSorted()
        {
            for (int i = 1; i < size(); i++)
                if (keys[i].CompareTo(keys[i - 1]) < 0) return false;
            return true;
        }

        // check that rank(select(i)) = i
        private bool rankCheck()
        {
            for (int i = 0; i < size(); i++)
                if (i != rank(select(i))) return false;
            for (int i = 0; i < size(); i++)
                if (keys[i].CompareTo(select(rank(keys[i]))) != 0) return false;
            return true;
        }

        public void ConsoleDisplay()
        {
            Console.WriteLine();
            Console.WriteLine("key" + " " + "val");
            for (int i=0; i<keys.Length;i++)
            {
                if (keys[i] != null)
                Console.WriteLine(" " + keys[i] + "  " + vals[i]);
            }
        }

        //iterator

        // iteraror
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }


        public IEnumerator<Key> GetEnumerator()
        {
            foreach (Key key in keys) yield return key;    
        }
    }
}
