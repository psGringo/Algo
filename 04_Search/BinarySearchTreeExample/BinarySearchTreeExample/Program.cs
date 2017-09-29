using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearchTreeExample
{
    class Program
    {
        static void Main(string[] args)
        {
            //Standart_TestClient sc = new Standart_TestClient();
            //sc.Execute();

            FrequencyCounter_TestClient fct = new FrequencyCounter_TestClient();
            fct.Execute();

            Console.ReadLine();
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

            BST<string, int> st = new BST<string, int>();
            //Array.Sort(a); // we sort because we use binary search inside

            //adding
            for (int i = 0; i < a.Length; i++)
            {
                st.put(a[i], i);
            }
            if (st.contains("X")) Console.WriteLine("Yes! Contains X");
            st.ConsoleDisplay();
            st.delete("L");
            // Console.WriteLine();
            st.ConsoleDisplay();

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
            BST<string, int> st = new BST<string, int>();
            //adding
            for (int i = 0; i < a.Length; i++)
            {
                // to Key we write Word, to Value we write Frequency
                if (!st.contains(a[i])) st.put(a[i], 1);
                else st.put(a[i], st.get(a[i]) + 1);
            }
            st.ConsoleDisplay();
            // search max frequent word
            string maxFrequentWord = " ";
            st.put(maxFrequentWord, 0);

            foreach (var val in st)
            {
                if ((val != null) && (st.get(val) > st.get(maxFrequentWord))) maxFrequentWord = val;
            }
            Console.WriteLine("maxFrequentWord=" + maxFrequentWord + " maxFrequency " + st.get(maxFrequentWord));
            st.ConsoleDisplay();

            
        }

    }

}
