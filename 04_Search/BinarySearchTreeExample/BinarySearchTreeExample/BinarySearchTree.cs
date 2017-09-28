using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearchTreeExample
{
    // binary search tree
    public class BST<Key, Value> : IEnumerable<Key> where Key : IComparable
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
    * Initializes an empty symbol table.
    */
        public BST()
        {
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
     * Returns the value associated with the given key.
     *
     * @param  key the key
     * @return the value associated with the given key if the key is in the symbol table
     *         and {@code null} if the key is not in the symbol table
     * @throws IllegalArgumentException if {@code key} is {@code null}
     */
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
            Trace.Assert(check());
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
     * Removes the smallest key and associated value from the symbol table.
     *
     * @throws NoSuchElementException if the symbol table is empty
     */
        public void deleteMin()
        {
            if (isEmpty()) throw new ArgumentException("Symbol table underflow");
            root = deleteMin(root);
            Trace.Assert(check());
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
            Trace.Assert(check());
        }

        private Node deleteMax(Node x)
        {
            if (x.right == null) return x.left;
            x.right = deleteMax(x.right);
            x.size = size(x.left) + size(x.right) + 1;
            return x;
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
            if (key == null) throw new ArgumentException("called delete() with a null key");
            root = delete(root, key);
            Trace.Assert(check());
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
         * Returns the largest key in the symbol table.
         *
         * @return the largest key in the symbol table
         * @throws NoSuchElementException if the symbol table is empty
         */
        public Key max()
        {
            if (isEmpty()) throw new ArgumentException("called max() with empty symbol table");
            return max(root).key;
        }

        private Node max(Node x)
        {
            if (x.right == null) return x;
            else return max(x.right);
        }

        /**
         * Returns the largest key in the symbol table less than or equal to {@code key}.
         *
         * @param  key the key
         * @return the largest key in the symbol table less than or equal to {@code key}
         * @throws NoSuchElementException if there is no such key
         * @throws IllegalArgumentException if {@code key} is {@code null}
         */
        public Key floor(Key key)
        {
            if (key == null) throw new ArgumentException("argument to floor() is null");
            if (isEmpty()) throw new ArgumentException("called floor() with empty symbol table");
            Node x = floor(root, key);
            if (x == null) return default(Key);
            else return x.key;
        }

        private Node floor(Node x, Key key)
        {
            if (x == null) return null;
            int cmp = key.CompareTo(x.key);
            if (cmp == 0) return x;
            if (cmp < 0) return floor(x.left, key);
            Node t = floor(x.right, key);
            if (t != null) return t;
            else return x;
        }



        /**
         * Returns the smallest key in the symbol table greater than or equal to {@code key}.
         *
         * @param  key the key
         * @return the smallest key in the symbol table greater than or equal to {@code key}
         * @throws NoSuchElementException if there is no such key
         * @throws IllegalArgumentException if {@code key} is {@code null}
         */
        public Key ceiling(Key key)
        {
            if (key == null) throw new ArgumentException("argument to ceiling() is null");
            if (isEmpty()) throw new ArgumentException("called ceiling() with empty symbol table");
            Node x = ceiling(root, key);
            if (x == null) return default(Key);
            else return x.key;
        }

        private Node ceiling(Node x, Key key)
        {
            if (x == null) return null;
            int cmp = key.CompareTo(x.key);
            if (cmp == 0) return x;
            if (cmp < 0)
            {
                Node t = ceiling(x.left, key);
                if (t != null) return t;
                else return x;
            }
            return ceiling(x.right, key);
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
        /**
* Return the number of keys in the symbol table strictly less than {@code key}.
*
* @param  key the key
* @return the number of keys in the symbol table strictly less than {@code key}
* @throws IllegalArgumentException if {@code key} is {@code null}
*/
        public int rank(Key key)
        {
            if (key == null) throw new ArgumentException("argument to rank() is null");
            return rank(key, root);
        }

        // Number of keys in the subtree less than key.
        private int rank(Key key, Node x)
        {
            if (x == null) return 0;
            int cmp = key.CompareTo(x.key);
            if (cmp < 0) return rank(key, x.left);
            else if (cmp > 0) return 1 + size(x.left) + rank(key, x.right);
            else return size(x.left);
        }

        //-------- iteraror
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }


        /*
         public void InOrder_Rec(TNode root)
    {
        if (root != null)
         {
              InOrder_Rec(root.Left);
              Console.Write(root.Data +" ");
              InOrder_Rec(root.Right);
        }
    }
                 */

        private void TraverseBinaryTreeKey(Node x, ref Queue<Key> q)
        {
            if (x != null)
            {
                q.Enqueue(x.key);
                TraverseBinaryTreeKey(x.left,ref q);
                TraverseBinaryTreeKey(x.right,ref q);
            }            
        }

        private void TraverseBinaryTreeValue(Node x, ref Queue<Value> q)
        {
            if (x != null)
            {
                q.Enqueue(x.val);
                TraverseBinaryTreeValue(x.left, ref q);
                TraverseBinaryTreeValue(x.right, ref q);
            }
        }

        public IEnumerator<Key> GetEnumerator()
        {
            Queue<Key> q = new Queue<Key>();
            TraverseBinaryTreeKey(root, ref q);
            return q.GetEnumerator();
            //foreach (Key key in q) yield return q.Dequeue(key);
        }

        public void ConsoleDisplay()
        {
            Console.WriteLine();
            Console.WriteLine("key" + " " + "val");

            Queue<Key> q = new Queue<Key>();
            TraverseBinaryTreeKey(root, ref q);

            Queue<Value> v = new Queue<Value>();
            TraverseBinaryTreeValue(root, ref v);

            Console.WriteLine();
            foreach (Key key in q) Console.Write(key + " ");
            Console.WriteLine();
            foreach (Value val in v) Console.Write(val + " ");
        }
        /*************************************************************************
    *  Check integrity of BST data structure.
    ***************************************************************************/
        private bool check()
        {
            //if (!isBST()) StdOut.println("Not in symmetric order");
            if (!isSizeConsistent()) Console.WriteLine("Subtree counts not consistent");// StdOut.println("Subtree counts not consistent");
            //if (!isRankConsistent()) StdOut.println("Ranks not consistent");
            return isBST() && isSizeConsistent();// && isRankConsistent();
        }

        // does this binary tree satisfy symmetric order?
        // Note: this test also ensures that data structure is a binary tree since order is strict
        private bool isBST()
        {
            return isBST(root, default(Key), default(Key));
        }

        // is the tree rooted at x a BST with all keys strictly between min and max
        // (if min or max is null, treat as empty constraint)
        // Credit: Bob Dondero's elegant solution
        private bool isBST(Node x, Key min, Key max)
        {
            if (x == null) return true;
            if (min != null && x.key.CompareTo(min) <= 0) return false;
            if (max != null && x.key.CompareTo(max) >= 0) return false;
            return isBST(x.left, min, x.key) && isBST(x.right, x.key, max);
        }

        // are the size fields correct?
        private bool isSizeConsistent() { return isSizeConsistent(root); }
        private bool isSizeConsistent(Node x)
        {
            if (x == null) return true;
            if (x.size != size(x.left) + size(x.right) + 1) return false;
            return isSizeConsistent(x.left) && isSizeConsistent(x.right);
        }

        // check that ranks are consistent
        /*
        private bool isRankConsistent()
        {
            for (int i = 0; i < size(); i++)
                if (i != rank(select(i))) return false;
            for (Key key in keys())
                if (key.CompareTo(select(rank(key))) != 0) return false;
            return true;
        }
        */

    }
}
