using System;
using Adscol;

namespace CS_Abstract_Data_Structures
{
    class Program
    {
        static void Main(string[] args)
        {
            // Call method to test corresponding data structure methods
            // LinkedListTest();
            Console.WriteLine("Hello world!");

            BagTest();

            Console.ReadKey();
        }

        static void LinkedListTest()
        {
            LinkedList<char> list = new LinkedList<char>();
            list.add('x');
            list.add('y');
            list.add('d');
            list.add('q');
            list.add('u');
            list.add('i');
            list.print();

            Console.WriteLine(list.size());
            list.clear();
            list.print();

            string st = "abcdefghijklmnopqrstuvwxyz";
            list.add(st[0]);
            
            Console.WriteLine();
            for (int i = 0; i < st.Length; i++)
            {
                list.add(st[i]);
            }

            list.print();
            list.clear();

            LinkedList<int> nums = new LinkedList<int>();

            for (int i = 0; i < 10; i++)
            {
                nums.add(i);
            }

            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(nums.get(i));
            }
        }

        static void DoublyLinkedListTest()
        {
            DoublyLinkedList<int> nums = new DoublyLinkedList<int>();

            nums.add(5);

            for (int i = 1; i <= 10; i++)
            {
                nums.add(i);
            }

            nums.print();

            Console.WriteLine();
            nums.print();

            Console.WriteLine();
            Console.WriteLine("Is Empty: ");
            Console.WriteLine(nums.isEmpty());

            Console.WriteLine("Size: ");
            Console.WriteLine(nums.size());

            nums.clear();
            Console.WriteLine("Is Empty: ");
            Console.WriteLine(nums.isEmpty());

            Console.WriteLine("Size: ");
            Console.WriteLine(nums.size());
        }

        static void LinkedListStackTest()
        {
            LinkedListStack<int> nums = new LinkedListStack<int>();

            for (int i = 1; i <= 10; i++)
            {
                nums.push(i);
            }

            Console.WriteLine(nums.peek());

            Console.WriteLine(nums.pop());
            Console.WriteLine(nums.pop());
            Console.WriteLine(nums.pop());
            Console.WriteLine(nums.size());
            Console.WriteLine(nums.isEmpty());

            Console.WriteLine();
            nums.print();
        }

        static void StackTest()
        {
            Stack<int> nums = new Stack<int>();

            for (int i = 1; i <= 10; i++)
            {
                nums.push(i);
            }

            Console.WriteLine(nums.peek());

            Console.WriteLine(nums.pop());
            Console.WriteLine(nums.pop());
            Console.WriteLine(nums.pop());
            Console.WriteLine(nums.size());
            Console.WriteLine(nums.isEmpty());

            Console.WriteLine();
            nums.print();
        }

        static void LinkedListQueueTest()
        {
            LinkedListQueue<int> nums = new LinkedListQueue<int>();

            for (int i = 1; i <= 10; i++)
            {
                nums.enqueue(i);
            }

            Console.WriteLine(nums.peek());

            Console.WriteLine(nums.dequeue());
            Console.WriteLine(nums.dequeue());
            Console.WriteLine(nums.dequeue());
            Console.WriteLine(nums.size());

            Console.WriteLine("Is empty: " + nums.isEmpty() + "\n");

            nums.print();
            nums.clear();
            Console.WriteLine();

            for (int i = 1; i <= 10; i++)
            {
                nums.enqueue(i);
            }

            nums.print();
        }

        static void QueueTest()
        {
            Queue<int> nums = new Queue<int>();

            for (int i = 1; i <= 10; i++)
            {
                nums.enqueue(i);
            }

            Console.WriteLine(nums.peek());

            Console.WriteLine(nums.dequeue());
            Console.WriteLine(nums.dequeue());
            Console.WriteLine(nums.dequeue());
            Console.WriteLine(nums.size());

            Console.WriteLine("Is empty: " + nums.isEmpty() + "\n");

            nums.print();
            nums.clear();
            Console.WriteLine();

            for (int i = 1; i <= 10; i++)
            {
                nums.enqueue(i);
            }

            nums.print();
        }
        
        static void LinkedListSortedSetTest()
        {
            LinkedListSortedSet<int> numsList = new LinkedListSortedSet<int>();

            for (int i = 0; i < 10; i++)
            {
                numsList.add(i);
            }

            for (int i = 0; i < 10; i++)
            {
                numsList.add(i);
            }

            numsList.print();
            Console.WriteLine("Finished first list");

            LinkedListSortedSet<int> nums2 = new LinkedListSortedSet<int>();
            Random rand = new Random();

            for (int i = 0; i < 100; i++)
            {
                int x = rand.Next(0, 10);
                nums2.add(x);
            }

            nums2.print();

            Console.WriteLine(nums2.size());
        }

        static void SortedSetTest()
        {
            SortedSet<int> numsList = new SortedSet<int>();

            for (int i = 0; i < 10; i++)
            {
                numsList.add(i);
            }

            for (int i = 0; i < 10; i++)
            {
                numsList.add(i);
            }

            numsList.print();
            Console.WriteLine("Finished first list");

            SortedSet<int> nums2 = new SortedSet<int>();
            Random rand = new Random();

            for (int i = 0; i < 100; i++)
            {
                int x = rand.Next(0, 10);
                nums2.add(x);
            }

            nums2.print();

            Console.WriteLine(nums2.size());
        }

        static void LinkedListSetTest()
        {
            LinkedListSet<int> numsList = new LinkedListSet<int>();

            for (int i = 0; i < 10; i++)
            {
                numsList.add(i);
            }

            for (int i = 0; i < 10; i++)
            {
                numsList.add(i);
            }

            numsList.print();
            Console.WriteLine("Finished first list");

            LinkedListSet<int> nums2 = new LinkedListSet<int>();
            Random rand = new Random();

            for (int i = 0; i < 100; i++)
            {
                int x = rand.Next(0, 10);
                nums2.add(x);
            }

            nums2.print();

            Console.WriteLine(nums2.size());
        }

        static void SetTest()
        {
            Set<int> numsList = new Set<int>();

            for (int i = 0; i < 10; i++)
            {
                numsList.add(i);
            }

            for (int i = 0; i < 10; i++)
            {
                numsList.add(i);
            }

            numsList.print();
            Console.WriteLine("Finished first list");

            Set<int> nums2 = new Set<int>();
            Random rand = new Random();

            for (int i = 0; i < 100; i++)
            {
                int x = rand.Next(0, 10);
                nums2.add(x);
            }

            nums2.print();

            Console.WriteLine(nums2.size());
        }

        static void LinkedListMultisetTest()
        {
            LinkedListMultiset<int> nums = new LinkedListMultiset<int>();

            Random rand = new Random();

            for (int i = 0; i < 100; i++)
            {

                int x = rand.Next(0, 10);

                nums.add(x);
            }

            nums.print();

            Console.WriteLine("Size: " + nums.size());

            Set<int> list = nums.getSet();
            list.print();
        }

        static void MultisetTest()
        {
            Multiset<int> nums = new Multiset<int>();

            Random rand = new Random();

            for (int i = 0; i < 100; i++)
            {

                int x = rand.Next(0, 10);

                nums.add(x);
            }

            nums.print();

            Console.WriteLine("Size: " + nums.size());

            Set<int> list = nums.getSet();
            list.print();
        }

        static void LinkedListBagTest()
        {
            LinkedListBag<char> items = new LinkedListBag<char>();

            string happy = "Happy Birthday";

            foreach (char x in happy)
            {
                items.add(x);
            }

            items.print();

            Console.WriteLine("Size: " + items.size());
        }

        static void BagTest()
        {
            Bag<char> items = new Bag<char>();

            string happy = "Happy Birthday";

            foreach (char x in happy)
            {
                items.add(x);
            }

            items.print();

            Console.WriteLine("Size: " + items.size());
        }
    }
}
