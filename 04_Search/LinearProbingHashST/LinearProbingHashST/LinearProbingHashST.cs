using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinearProbingHashST
{
    class LinearProbingHashST<Key,Value>
    {
        private int INIT_CAPACITY = 4;

        public int n;           // number of key-value pairs in the symbol table
        public int m;           // size of linear probing table
        public Key[] keys;      // the keys
        public Value[] vals;    // the values
                                 
        /**
         * Initializes an empty symbol table.
        */
        public LinearProbingHashST()
        {            
            m = INIT_CAPACITY;
            n = 0;
            keys = new Key[m];
            vals = new Value[m];
        }

        /**
         * Initializes an empty symbol table with the specified initial capacity.
         *
         * @param capacity the initial capacity
         */
        public LinearProbingHashST(int capacity)  
        {
            m = capacity;
            n = 0;
            keys = new Key[m]; 
            vals = new Value[m];
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
         * Returns true if this symbol table contains the specified key.
         *
         * @param  key the key
         * @return {@code true} if this symbol table contains {@code key};
         *         {@code false} otherwise
         * @throws IllegalArgumentException if {@code key} is {@code null}
         */
        public bool contains(Key key)
        {
            if (key == null) throw new ArgumentException("argument to contains() is null");
            return get(key) != null;
        }

        // hash function for keys - returns value between 0 and M-1
        private int hash(Key key)
        {
            return (key.GetHashCode() & 0x7fffffff) % m;
        }
        // resizes the hash table to the given capacity by re-hashing all of the keys
        private void resize(int capacity)
        {
            LinearProbingHashST<Key, Value> temp = new LinearProbingHashST<Key, Value>(capacity);
            for (int i = 0; i < m; i++)
            {
                if (keys[i] != null)
                {
                    temp.put(keys[i], vals[i]);
                }
            }
            keys = temp.keys;
            vals = temp.vals;
            m = temp.m;
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

            // double table size if 50% full
            if (n >= m / 2) resize(2 * m);

            int i;
            for (i = hash(key); keys[i] != null; i = (i + 1) % m)
            {
                if (keys[i].Equals(key))
                {
                    vals[i] = val;
                    return;
                }
            }
            keys[i] = key;
            vals[i] = val;
            n++;
        }
        /**
    * Returns the value associated with the specified key.
    * @param key the key
    * @return the value associated with {@code key};
    *         {@code null} if no such value
    * @throws IllegalArgumentException if {@code key} is {@code null}
    */
        public Value get(Key key)
        {
            if (key == null) throw new ArgumentException("argument to get() is null");
            for (int i = hash(key); keys[i] != null; i = (i + 1) % m)
                if (keys[i].Equals(key))
                    return vals[i];
            return default(Value);
        }
        /**
    * Removes the specified key and its associated value from this symbol table     
    * (if the key is in this symbol table).    
    *
    * @param  key the key
    * @throws IllegalArgumentException if {@code key} is {@code null}
    */
        public void delete(Key key)
        {
            if (key == null) throw new ArgumentException("argument to delete() is null");
            if (!contains(key)) return;

            // find position i of key
            int i = hash(key);
            while (!key.Equals(keys[i]))
            {
                i = (i + 1) % m;
            }

            // delete key and associated value
            keys[i] = default(Key);
            vals[i] = default(Value);

            // rehash all keys in same cluster
            i = (i + 1) % m;
            while (keys[i] != null)
            {
                // delete keys[i] an vals[i] and reinsert
                Key keyToRehash = keys[i];
                Value valToRehash = vals[i];
                keys[i] = default(Key);
                vals[i] = default(Value);
                n--;
                put(keyToRehash, valToRehash);
                i = (i + 1) % m;
            }

            n--;

            // halves size of array if it's 12.5% full or less
            if (n > 0 && n <= m / 8) resize(m / 2);

            Trace.Assert(check());
        }
        /**
     * Returns all keys in this symbol table as an {@code Iterable}.
     * To iterate over all of the keys in the symbol table named {@code st},
     * use the foreach notation: {@code for (Key key : st.keys())}.
     *
     * @return all keys in this symbol table
     */
        public IEnumerable<Key> allkeys()
        {
            Queue<Key> queue = new Queue<Key>();
            for (int i = 0; i < m; i++)
                if (keys[i] != null) queue.Enqueue(keys[i]);
            return queue;
        }

        public void ConsoleDisplay()
        {
            Console.WriteLine("key" + " " + "val");
            for (int i = 0; i < m; i++)
            {
                if (keys[i] != null)
                Console.WriteLine(" " + keys[i] + "  " + vals[i]);
            }
        }


        // integrity check - don't check after each put() because
        // integrity not maintained during a delete()
        private bool check()
        {

            // check that hash table is at most 50% full
            if (m < 2 * n)
            {
                Console.WriteLine("Hash table size m = " + m + "; array size n = " + n);
                return false;
            }

            // check that each key in table can be found by get()
            for (int i = 0; i < m; i++)
            {
                if (keys[i] == null) continue;
                else if (!get(keys[i]).Equals(vals[i]))
                {
                    Console.WriteLine("get[" + keys[i] + "] = " + get(keys[i]) + "; vals[i] = " + vals[i]);
                    return false;
                }
            }
            return true;
        }

    }
}
