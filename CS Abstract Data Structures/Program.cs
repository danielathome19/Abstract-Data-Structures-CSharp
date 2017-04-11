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
            
            MapTest();

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

        static void BinaryTreeTest()
        {
            BinaryTree<int> nums = new BinaryTree<int>();

            Random rand = new Random();

            for (int i = 0; i < 100; i++)
            {
                int x = rand.Next(0, 10);
                nums.add(x);
            }

            nums.printInOrder();

            Console.WriteLine();
            Console.WriteLine("Size: " + nums.size());
            Console.WriteLine("Height: " + nums.height());
            Console.WriteLine("Width: " + nums.width());
            Console.WriteLine();

            nums.remove(9);
            nums.invert();

            nums.printInOrder();

            Console.WriteLine();
            Console.WriteLine("Size: " + nums.size());
            Console.WriteLine();

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();

            BinaryTree<char> tree = new BinaryTree<char>();

            tree.add('2');
            tree.add('+');
            tree.add('3');
            tree.add('*');
            tree.add('6');

            tree.printPreOrder();
            Console.WriteLine();
            tree.printInOrder();
            Console.WriteLine();
            tree.printPostOrder();
            Console.WriteLine();
        }

        static void PriorityQueueTest()
        {
            PriorityQueue<char> queue = new PriorityQueue<char>();

            Random rand = new Random();

            for (int i = 0; i < 50; i++)
            {
                int pr = rand.Next(0, 10);
                char let = (char)rand.Next(65, 126);

                queue.enqueue(let, pr);
            }

            Console.WriteLine("Size: " + queue.size());
            queue.print();

            Console.WriteLine(queue.peek());
            Console.WriteLine(queue.dequeue());
            Console.WriteLine(queue.dequeue());
            Console.WriteLine(queue.dequeue());
            Console.WriteLine(queue.dequeue());
            Console.WriteLine(queue.peek());

            queue.print();
        }

        static void ArrayListTest()
        {
            ArrayList<int> list = new ArrayList<int>();

            for (int i = 0; i < 100; i++)
            {
                list.add(i);
            }

            Console.WriteLine("Size: " + list.size());

            list = list.subList(0, 50);
            Console.WriteLine("Size: " + list.size());

            list.print();

            Console.WriteLine(list.isEmpty());

            list.reverse();
            list[0] = 350;
            Console.WriteLine(list.get(5));
            Console.WriteLine(list[5]);
            Console.WriteLine(list.contains(3));
            list.print();
        }

        static void DequeTest()
        {
            Deque<int> list = new Deque<int>();

            try
            {
                if (list.isEmpty())
                {
                    Console.WriteLine("Empty queue");
                }

                list.pushBack(100);
                list.pushBack(200);
                list.pushBack(300);

                Console.WriteLine("Size: " + list.size());
                
                Console.WriteLine(list.popBack());
                Console.WriteLine(list.popBack());
                Console.WriteLine(list.popBack());
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }

            Deque<int> list2 = new Deque<int>();

            try
            {
                if (list2.isEmpty())
                {
                    Console.WriteLine("Empty queue");
                }
                
                list2.pushBack(100);
                list2.pushBack(200);
                list2.pushBack(300);

                Console.WriteLine("Size: " + list2.size());
                
                Console.WriteLine(list2.popFront());
                Console.WriteLine(list2.popFront());
                Console.WriteLine(list2.popFront());
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        static void CircularQueueTest()
        {
            CircularQueue<int> list = new CircularQueue<int>(5);

            for (int i = 0; i < 5; i++)
            {
                list.enqueue(i);
            }

            list.print();

            Console.WriteLine();
            Console.WriteLine("Size: " + list.size());
            list.clear();
            Console.WriteLine("Size: " + list.size());

            CircularQueue<string> q = new CircularQueue<string>(3);

            q.enqueue("The");
            q.enqueue("end");
            q.enqueue("is");
            q.enqueue("nigh!");

            q.enqueue("Cool");

            q.print();
        }

        static void CircularLinkedListTest()
        {
            CircularLinkedList<int> list = new CircularLinkedList<int>();

            Console.WriteLine("Starting");

            list.addBack(43);
            list.addBack(83);
            list.addBack(98);
            list.addBack(65);
            list.addBack(4983);
            list.addBack(9898);
            list.addFront(5555555);

            Console.WriteLine("Size: " + list.size());

            list.print();

            list.popBack();
            Console.WriteLine("Size: " + list.size());
            list.print();

            list.popFront();
            Console.WriteLine("Size: " + list.size());
            list.print();

            Console.WriteLine("Finished");
        }

        static void SortedMapTest()
        {
            SortedMap<string, int> table = new SortedMap<string, int>();

            table.add("Jane", 35);
            table.add("Joe", 14);
            table.add("Jack", 71);
            table.add("Jill", 64);
            table.add("Abe", 33);
            table.add("Beth", 21);
            table.add("Chuck", 12);
            table.add("Dot", 38);
            table.add("Mike", 75);
            table.add("Nick", 58);
            table.add("Otis", 45);

            table.print();

            Console.WriteLine("\nSize: " + table.size());
            Console.WriteLine(table.get("wow"));
            Console.WriteLine(table.get("Jane"));
            Console.WriteLine(table.get("Joe"));
            Console.WriteLine(table.get("Jack"));
            Console.WriteLine(table.get("Jill"));

            table.remove("Jane");
            table.remove("Joe");

            Console.WriteLine("\nSize: " + table.size());

            Console.WriteLine(table.get("Jane"));
            Console.WriteLine(table.get("Joe"));

            table.add("Otis", 45);
            table.add("Otis", 45);
            table.add("Otis", 45);

            Console.WriteLine("\nSize: " + table.size());
            table.add("Jane", 35);
            table.add("Joe", 14);

            Console.WriteLine("\nSize: " + table.size());
        }

        static void MapTest()
        {
            Map<string, int> table = new Map<string, int>();

            table.add("Jane", 35);
            table.add("Joe", 14);
            table.add("Jack", 71);
            table.add("Jill", 64);
            table.add("Abe", 33);
            table.add("Beth", 21);
            table.add("Chuck", 12);
            table.add("Dot", 38);
            table.add("Mike", 75);
            table.add("Nick", 58);
            table.add("Otis", 45);

            table.print();

            Console.WriteLine("\nSize: " + table.size());
            Console.WriteLine(table.get("wow"));
            Console.WriteLine(table.get("Jane"));
            Console.WriteLine(table.get("Joe"));
            Console.WriteLine(table.get("Jack"));
            Console.WriteLine(table.get("Jill"));

            table.remove("Jane");
            table.remove("Joe");

            Console.WriteLine("\nSize: " + table.size());

            Console.WriteLine(table.get("Jane"));
            Console.WriteLine(table.get("Joe"));

            table.add("Otis", 45);
            table.add("Otis", 45);
            table.add("Otis", 45);

            Console.WriteLine("\nSize: " + table.size());
            table.add("Jane", 35);
            table.add("Joe", 14);

            Console.WriteLine("\nSize: " + table.size());
        }
    }
}
