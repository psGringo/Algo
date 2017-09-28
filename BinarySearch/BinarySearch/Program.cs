using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearch
{
    class Program
    {
        static void Main(string[] args)
        {
            Random r = new Random();
            //int[] a = new int[100];
            //for (int i = 0; i < 100; i++) a[i] = r.Next(100);
            int[] a = { 1, 3, 5, 6, 12,30,40,55,16,18,20 };
            //int[] a = { 1, 5, 3 };
            Array.Sort(a);
            if (BinarySearch(5, a) != -1) Console.WriteLine("Non recursive BS: Element found");
            if (BinarySearchGeneric<int>(5, a) != -1) Console.WriteLine("Non recursive Generic BS: Element found");
            if (BinarySearchRecursive(5, a, 0, a.Length) != -1) Console.WriteLine("Recursive BS: Element found");
            if (BinarySearchRecursiveGeneric<int>(5, a, 0, a.Length) != -1) Console.WriteLine("Recursive Generic BS: Element found");

            Console.ReadLine();

        }

        static int BinarySearch(int key, int[] a)
        {
            int low = 0;
            int hi = a.Length - 1;
            while (low <= hi)
            {
                int mid = (low + hi) / 2;
                if (key < a[mid]) hi = mid - 1;
                else if (key > a[mid]) low = mid + 1;
                else return mid;
            }
            return -1;
        }

        public static int BinarySearchRecursive(int key, int[] a, int lo, int hi)
        {
            if (hi < lo) return lo;
            int mid = lo + (hi - lo) / 2;
            if (key < a[mid]) return BinarySearchRecursive(key, a, lo, mid - 1);            
            else if (key > a[mid]) return BinarySearchRecursive(key, a, mid + 1, hi);
            else return mid;
        }

        static int BinarySearchGeneric<T>(T key, int[] a) where T : IComparable
        {
            int low = 0;
            int hi = a.Length - 1;
            while (low <= hi)
            {
                int mid = (low + hi) / 2;
                int cmp = key.CompareTo(a[mid]);
                if (cmp < 0) { hi = mid - 1; }
                else if (cmp > 0) { low = mid + 1; }
                else return mid;
            }
            return -1;
        }

        public static int BinarySearchRecursiveGeneric<T>(T key, int[] a, int lo, int hi) where T : IComparable
        {
            //  if (hi < lo) return lo;
            int mid = lo + (hi - lo) / 2;
            int cmp = key.CompareTo(a[mid]);
            if (cmp < 0) { return BinarySearchRecursiveGeneric(key, a, lo, mid - 1); }
            else if (cmp > 0) { return BinarySearchRecursiveGeneric(key, a, mid + 1, hi); }
            else return mid;            
        }
    }
}
