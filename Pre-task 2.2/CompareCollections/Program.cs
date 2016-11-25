using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompareCollections
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Comparing ArrayList with LinkedList");
            Console.WriteLine();
            new ArrayListTiming().DefineArrayListTiming();
            Console.WriteLine();
            new LinkedListTiming().DefineLinkedListTiming();
            Console.WriteLine();
            Console.WriteLine("Comparing Stack with Queue");
            Console.WriteLine();
            new ListStackTiming().DefineListStackTiming();
            Console.WriteLine();
            new ListQueueTiming().DefineListQueueTiming();
            Console.WriteLine();
            Console.WriteLine("Comparing HashTable with Dictionary");
            Console.WriteLine();
            new HashTableTiming().DefineHashTableTiming();
            Console.WriteLine();
            new DictionaryTiming().DefineDictionaryTiming();
            Console.ReadLine();
        }

    }

    public class ArrayListTiming
    {
        public void DefineArrayListTiming()
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            ArrayList al = new ArrayList();

            for (int i = 0; i < 15000000; i++)
            {
                al.Add(i);
            }

            sw.Stop();

            Console.WriteLine("Creation of Array List time: " + sw.Elapsed);

            sw.Restart();

            sw.Start();

            al.IndexOf(7500000);

            sw.Stop();

            Console.WriteLine("Search of Array List object time: " + sw.Elapsed);

            sw.Restart();

            sw.Start();

            al.Remove(7500000); 
	        
            sw.Stop();

            Console.WriteLine("Remove of Array List objects time: " + sw.Elapsed);

        }
    }

    public class LinkedListTiming
    {
        public void DefineLinkedListTiming()
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            LinkedList<int> ll = new LinkedList<int>();

            for (int i = 0; i < 15000000; i++)
            {
                ll.AddLast(i);
            }

            sw.Stop();

            Console.WriteLine("Creation of Linked List time: " + sw.Elapsed);

            sw.Restart();

            sw.Start();

            ll.Find(7500000);

            sw.Stop();

            Console.WriteLine("Search of Linked List object time: " + sw.Elapsed);

            sw.Restart();

            sw.Start();

            ll.Remove(7500000);

            sw.Stop();

            Console.WriteLine("Remove of Linked List objects time: " + sw.Elapsed);

        }
    }

    public class ListStackTiming
    {
        public void DefineListStackTiming()
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            Stack ls = new Stack();

            for (int i = 0; i < 15000000; i++)
            {
                ls.Push(i);
            }

            sw.Stop();

            Console.WriteLine("Creation of Stack List time: " + sw.Elapsed);

            sw.Restart();

            sw.Start();

            ls.Peek();

            sw.Stop();

            Console.WriteLine("Search of Stack List object time: " + sw.Elapsed);

            sw.Restart();

            sw.Start();

            ls.Pop();

            sw.Stop();

            Console.WriteLine("Remove of Stack objects time: " + sw.Elapsed);

        }
    }


    public class ListQueueTiming
    {
        public void DefineListQueueTiming()
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            Queue lq = new Queue();

            for (int i = 0; i < 15000000; i++)
            {
                lq.Enqueue(i);
            }

            sw.Stop();

            Console.WriteLine("Creation of Queue List time: " + sw.Elapsed);

            sw.Restart();

            sw.Start();

            lq.Peek();

            sw.Stop();

            Console.WriteLine("Search of Queue List object time: " + sw.Elapsed);

            sw.Restart();

            sw.Start();

            lq.Dequeue();

            sw.Stop();

            Console.WriteLine("Remove of Queue objects time: " + sw.Elapsed);

        }
    }

    public class HashTableTiming
    {
        public void DefineHashTableTiming()
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            Hashtable ht = new Hashtable();

            for (int i = 0, y = 0; i < 10000000; i++, y++)
            {
                ht.Add(i, y);
            }

            sw.Stop();

            Console.WriteLine("Creation of HashTable List time: " + sw.Elapsed);

            sw.Restart();

            sw.Start();

            ht.ContainsValue(5000000);

            sw.Stop();

            Console.WriteLine("Search of HashTable List object time: " + sw.Elapsed);

            sw.Restart();

            sw.Start();

            ht.Remove(5000000);

            sw.Stop();

            Console.WriteLine("Remove of HashTable objects time: " + sw.Elapsed);

        }
    }

    public class DictionaryTiming
    {
        public void DefineDictionaryTiming()
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            Dictionary<int, int> d = new Dictionary<int, int>();

            for (int i = 0, y = 0; i < 10000000; i++, y++)
            {
                d.Add(i, y);
            }

            sw.Stop();

            Console.WriteLine("Creation of Dictionary List time: " + sw.Elapsed);

            sw.Restart();

            sw.Start();

            d.ContainsValue(5000000);

            sw.Stop();

            Console.WriteLine("Search of Dictionary List object time: " + sw.Elapsed);

            sw.Restart();

            sw.Start();

            d.Remove(5000000);

            sw.Stop();

            Console.WriteLine("Remove of Dictionary objects time: " + sw.Elapsed);

        }
    }

}
