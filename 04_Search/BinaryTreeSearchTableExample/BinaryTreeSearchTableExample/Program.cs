using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTreeSearchTableExample
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }

    class BST<Key, Value> where Key : IComparable
    {
        private Node root;             // root of BST
        private class Node
        {
            public Key key;           // sorted by key
            public Value val;         // associated data
            public Node left, right;  // left and right subtrees
            public int size;          // number of nodes in subtree

            public Node(Key key, Value val, int size)
            {
                this.key = key;
                this.val = val;
                this.size = size;
            }
        }

        /**
  * Returns true if this symbol table is empty.
  * @return {@code true} if this symbol table is empty; {@code false} otherwise
  */
        public bool isEmpty()
        {
            return size() == 0;
        }

        /**
       * Returns the number of key-value pairs in this symbol table.
       * @return the number of key-value pairs in this symbol table
       */
        public int size()
        {
            return size(root);
        }

        // return number of key-value pairs in BST rooted at x
        private int size(Node x)
        {
            if (x == null) return 0;
            else return x.size;
        }

        public Value get(Key key)
        {
            return get(root, key);
        }

        private Value get(Node x, Key key)
        {
            if (key == null) throw new ArgumentException("called get() with a null key");
            if (x == null) return default(Value);
            int cmp = key.CompareTo(x.key);
            if (cmp < 0) return get(x.left, key);
            else if (cmp > 0) return get(x.right, key);
            else return x.val;
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
            if (key == null) throw new ArgumentException("calledput() with a null key");
            if (val == null)
            {
                delete(key);
                return;
            }
            root = put(root, key, val);
           // assert check();
        }

        private Node put(Node x, Key key, Value val)
        {
            if (x == null) return new Node(key, val, 1);
            int cmp = key.CompareTo(x.key);
            if (cmp < 0) x.left = put(x.left, key, val);
            else if (cmp > 0) x.right = put(x.right, key, val);
            else x.val = val;
            x.size = 1 + size(x.left) + size(x.right);
            return x;
        }

        /**
 * Removes the specified key and its associated value from this symbol table     
 * (if the key is in this symbol table).    
 *
 * @param  key the key
 * @throws IllegalArgumentException if {@code key} is {@code null}
 */

        /**
* Removes the smallest key and associated value from the symbol table.
*
* @throws NoSuchElementException if the symbol table is empty
*/
        public void deleteMin()
        {
            if (isEmpty()) throw new ArgumentException("Symbol table underflow");
            root = deleteMin(root);
           // assert check();
        }

        private Node deleteMin(Node x)
        {
            if (x.left == null) return x.right;
            x.left = deleteMin(x.left);
            x.size = size(x.left) + size(x.right) + 1;
            return x;
        }

        /**
         * Removes the largest key and associated value from the symbol table.
         *
         * @throws NoSuchElementException if the symbol table is empty
         */
        public void deleteMax()
        {
            if (isEmpty()) throw new ArgumentException("Symbol table underflow");
            root = deleteMax(root);
           // assert check();
        }

        private Node deleteMax(Node x)
        {
            if (x.right == null) return x.left;
            x.right = deleteMax(x.right);
            x.size = size(x.left) + size(x.right) + 1;
            return x;
        }

        public void delete(Key key)
        {
            if (key == null) throw new ArgumentException("called delete() with a null key");
            root = delete(root, key);
            //assert check();
        }

        private Node delete(Node x, Key key)
        {
            if (x == null) return null;

            int cmp = key.CompareTo(x.key);
            if (cmp < 0) x.left = delete(x.left, key);
            else if (cmp > 0) x.right = delete(x.right, key);
            else
            {
                if (x.right == null) return x.left;
                if (x.left == null) return x.right;
                Node t = x;
                x = min(t.right);
                x.right = deleteMin(t.right);
                x.left = t.left;
            }
            x.size = size(x.left) + size(x.right) + 1;
            return x;
        }

        /**
 * Returns the smallest key in the symbol table.
 *
 * @return the smallest key in the symbol table
 * @throws NoSuchElementException if the symbol table is empty
 */
        public Key min()
        {
            if (isEmpty()) throw new ArgumentException("called min() with empty symbol table");
            return min(root).key;
        }

        private Node min(Node x)
        {
            if (x.left == null) return x;
            else return min(x.left);
        }

        /**
 * Return the kth smallest key in the symbol table.
 *
 * @param  k the order statistic
 * @return the {@code k}th smallest key in the symbol table
 * @throws IllegalArgumentException unless {@code k} is between 0 and
 *        <em>n</em>–1
 */
        public Key select(int k)
        {
            if (k < 0 || k >= size())
            {
                throw new ArgumentException("called select() with invalid argument: " + k);
            }
            Node x = select(root, k);
            return x.key;
        }

        // Return key of rank k. 
        private Node select(Node x, int k)
        {
            if (x == null) return null;
            int t = size(x.left);
            if (t > k) return select(x.left, k);
            else if (t < k) return select(x.right, k - t - 1);
            else return x;
        }

    }
}
