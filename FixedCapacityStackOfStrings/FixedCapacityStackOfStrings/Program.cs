﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackExamples
{
    class Program
    {
        static void Main(string[] args)
        {
            // fill stack with Count elements
            int Count = 10;
            FixedCapacityStackOfStrings s = new FixedCapacityStackOfStrings(Count);
            Random r = new Random();
            Console.WriteLine("lets fill stack with Count elements");
            for (int i = 0; i < Count; i++)
            {
                int someRandomNumber = r.Next(100);
                s.push(someRandomNumber.ToString());
                Console.WriteLine(someRandomNumber);
            }
            
            Console.WriteLine("lets take last 5 elements from stack");
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine(s.pop());
            }

            Console.ReadLine();

        }
    }

    class FixedCapacityStackOfStrings
    {
    private string[] a;
    public int N;
    public FixedCapacityStackOfStrings(int ACapacity)
    {
        a = new string[ACapacity];
    }
        public bool isEmpty() { return N == 0; }
        public int size() { return N; }
        public void push(string item)
        {
            a[N++] = item;
        }
        public string pop()
        {
            return a[--N];
        }
}

}
