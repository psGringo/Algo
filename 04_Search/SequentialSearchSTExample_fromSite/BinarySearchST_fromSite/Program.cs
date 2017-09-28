using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 this example illustrates symbol table realized on linked list
 source http://algs4.cs.princeton.edu/code/edu/princeton/cs/algs4/BinarySearchST.java.html
     */

namespace BinarySearchST_fromSite
{
    class Program
    {
        static void Main(string[] args)
        {
            //Standart_TestClient stc = new Standart_TestClient();
            //stc.Execute();

            FrequencyCounter_TestClient ftc = new FrequencyCounter_TestClient();
            ftc.Execute();

            Console.Read();
        }
    }

    public class Standart_TestClient
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
        public void Execute()
        {

            BinarySearchST<string, int> st = new BinarySearchST<string, int>();
            //adding
            for (int i = 0; i < a.Length; i++)
            {
                st.put(a[i], i);
            }
            if (st.contains("X")) Console.WriteLine("Yes! Contains X");
            st.ConsoleDisplay();
           // st.delete("L");
           // Console.WriteLine();
           // st.ConsoleDisplay();

        }
    }

    public class FrequencyCounter_TestClient
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


        public void Execute()
        {
            BinarySearchST<string, int> st = new BinarySearchST<string, int>(a.Length);
            //adding
            for (int i = 0; i < a.Length; i++)
            {
                // to Key we write Word, to Value we write Frequency
                if (!st.contains(a[i])) st.put(a[i], 1);
                else st.put(a[i], st.get(a[i]) + 1);
            }
            //st.ConsoleDisplay();
            // search max frequent word
            string maxFrequentWord = " ";
            st.put(maxFrequentWord, 0);
            
            foreach (var val in st)
            {
                if ((val!=null)&&(st.get(val) > st.get(maxFrequentWord))) maxFrequentWord = val;
            }
            Console.WriteLine("maxFrequentWord=" + maxFrequentWord + " maxFrequency " + st.get(maxFrequentWord));            
            st.ConsoleDisplay();
        }
    }
}
