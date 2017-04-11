/*
 * Author:  Daniel Szelogowski (C) 2017
 * Created: 4/7/17
 * Purpose: A collection of data structures written in C# using generics.
 * 
 * Current implemented:
 *  -Linked List
 *  -Doubly Linked List
 *  -Stack (Linked List)
 *  -Stack
 *  -Queue (Linked List)
 *  -Queue
 *  -Sorted Set (Linked List)
 *  -Sorted Set
 *  -Set (Linked List)
 *  -Set
 *  -Multiset (Linked List) (Sorted List)
 *  -Multiset (Sorted List)
 *  -Bag (LInked List)
 *  -Bag
 *  -Binary (Search) Tree
 *  -Priority Queue
 *  -ArrayList
 *  -Deque (Double Ended Queue)
 *  -Circular Queue
 *  -Circular Linked List
 *  -SortedMap
 *  -Map
 *  -HashMap (Dictionary)
 *  -Treap
 *  -HashSet
 *
 * To do:
 *  -Multimap
 *  -TreeSet
 *  -MaxHeap (Binary Tree)
 *  -MaxHeap
 *  -MinHeap (Binary Tree)
 *  -MinHeap
 *  -Skip List
 *  -Unrolled Linked LIst
 *  -Bitset
 *  -Bitfield
 *  -Queap
 *  -Trie
 *  -Splay Tree
 *  -2 3 Tree (2-3)
 *  -2 4 Tree (2-3-4)
 *  -AVL Tree
 *  -B-Tree
 *  -B+Tree
 *  -Ternary Tree
 *  -Red Black Tree
 *  -Undirected Graph
 *  -Directed Graph
 *  -Incidence Matrix
 *  -Adjacency List
 *  -Adjacency Matrix
 * 
 **************************************************************************/

using System;

namespace Adscol
{
    interface AdsClass<T>
    {
        //TODO: void removeAll(T t);
        void print();
        System.Collections.Generic.List<T> getList();
        bool contains(T t);
        void clear();
        int size();
        bool isEmpty();
    }

    interface AdsClassMin
    {
        void clear();
        int size();
        bool isEmpty();
    }

    class Node<T>
    {
        public T myObj;
        public Node<T> myPrev;
        public Node<T> myNext;

        public Node(T t)
        {
            myObj = t;
            myNext = null;
            myPrev = null;
        }
    }

    class LinkedList<T> : AdsClass<T>
    {
        private Node<T> myList;
        private Node<T> myLast;

        private void addLast(T t)
        {
            myLast = myList;
            while (myLast.myNext != null)
            {
                myLast = myLast.myNext;
            }
            Node<T> temp = new Node<T>(t);
            myLast.myNext = temp;
        }

        public LinkedList()
        {
            myList = null;
            myLast = null;
        }

        public LinkedList(T t)
        {
            myList = new Node<T>(t);
            myLast = myList;
        }

        public T this[int index]
        {
            get
            {
                return get(index);
            }
            set
            {
                set(index, value);
            }
        }

        public void add(T t)
        {
            if (myList == null)
            {
                Node<T> temp = new Node<T>(t);
                myList = temp;
                myLast = temp;
            } else
            {
                this.addLast(t);
            }
        }

        public void add(int index, T t)
        {
            if (index == 0)
            {
                Node<T> temp = new Node<T>(t);
                temp.myNext = myList;
                myList = temp;
            } else if (index >= this.size() - 1)
            {
                this.addLast(t);
            } else
            {
                int cnt = 0;
                myLast = myList;
                Node<T> temp = new Node<T>(t);
                while ((myLast.myNext != null) && (cnt <= index))
                {
                    if (cnt == (index - 1))
                    {
                        temp.myNext = myLast.myNext;
                        myLast.myNext = temp;
                    }
                    cnt++;
                    myLast = myLast.myNext;
                }
            }
        }

        public void remove(int index)
        {
            if (index == 0)
            {
                myLast = myList;
                Node<T> temp = myLast.myNext;
                myList = temp;
                myLast = myList;
            }
            else if (index == (this.size() - 1))
            {
                myLast = myList;
                while (myLast.myNext.myNext != null)
                {
                    myLast = myLast.myNext;
                }
                myLast.myNext = null;
            }
            else
            {
                int cnt = 0;
                myLast = myList;
                while ((myLast.myNext != null) && (cnt <= index))
                {
                    if (cnt == (index - 1))
                    {
                        Node<T> temp = myLast;
                        temp.myNext = myLast.myNext.myNext;
                        myLast = temp;
                    }
                    cnt++;
                    myLast = myLast.myNext;
                }
            }
        }

        public void set(int index, T t)
        {
            Node<T> temp = new Node<T>(t);
            if (index == 0)
            {
                temp.myNext = myList.myNext;
                myList = temp;
                myLast = myList;
            }
            else if (index == (this.size() - 1))
            {
                myLast = myList;
                while (myLast.myNext.myNext != null)
                {
                    myLast = myLast.myNext;
                }
                myLast.myNext = temp;
            }
            else
            {
                int cnt = 0;
                myLast = myList;
                while ((myLast.myNext != null) && (cnt <= index))
                {
                    if (cnt == (index - 1))
                    {
                        temp.myNext = myLast.myNext.myNext;
                        myLast.myNext = temp;
                    }
                    cnt++;
                    myLast = myLast.myNext;
                }
            }
        }
        
        public T get(int index)
        {
            int cnt = 0;
            myLast = myList;
            while ((myLast.myNext != null) && (cnt <= index))
            {
                if (cnt == index) return myLast.myObj;
                myLast = myLast.myNext;
                cnt++;
            }
            if (cnt == index) return myLast.myObj;
            return default(T);
        }

        public void print()
        {
            myLast = myList;
            while (myLast != null)
            {
                Console.WriteLine(myLast.myObj);
                myLast = myLast.myNext;
            }
        }

        public System.Collections.Generic.List<T> getList()
        {
            var items = new System.Collections.Generic.List<T>();

            for (int i = 0; i < this.size(); i++)
            {
                items.Add(this.get(i));
            }
            return items;
        }

        public bool contains(T t)
        {
            var items = this.getList();

            for (int i = 0; i < items.Count; i++)
            {
                if (items[i].Equals(t)) return true;
            }
            return false;
        }

        public void clear()
        {
            myList = null;
            myLast = null;
        }

        public int size()
        {
            int cnt = 0;
            myLast = myList;
            while (myLast != null)
            {
                cnt++;
                myLast = myLast.myNext;
            }
            return cnt;
        }

        public bool isEmpty()
        {
            return (this.size() == 0);
        }
    }

    class DoublyLinkedList<T> : AdsClass<T>
    {
        //TODO: add remove(index, add(index), set(index)
        private Node<T> myList;

        public DoublyLinkedList()
        {
            myList = null;
        }

        public DoublyLinkedList(T t)
        {
            myList = new Node<T>(t);
        }

        public void add(T t)
        {
            Node<T> temp = new Node<T>(t);
            if (myList == null)
            {
                myList = temp;
                myList.myNext = myList;
                myList.myPrev = myList;
            } else
            {
                temp.myNext = myList;
                temp.myPrev = myList.myPrev;
                myList.myPrev = temp;
                temp.myPrev.myNext = temp;
            }
        }

        public void removeLast()
        {
            myList.myPrev = myList.myPrev.myPrev;
            myList.myPrev.myNext = myList;
            return;
        }

        public void removeFirst()
        {
            Node<T> temp = myList.myNext;
            temp.myPrev = myList.myPrev;
            temp.myNext = myList.myNext.myNext;
            myList.myPrev.myNext = temp;
            myList = temp;
        }

        public T get(int index)
        {
            int cnt = 0;
            Node<T> temp = myList;
            if (cnt == index)
            {
                return temp.myObj;
            } else
            {
                cnt++;
                if (cnt == index) return temp.myNext.myObj;
            }
            temp = temp.myNext;

            while ((temp != myList) && (cnt <= index))
            {
                if (cnt == index) return temp.myObj;
                temp = temp.myNext;
                cnt++;
            }
            if (cnt == index) return temp.myObj;
            return default(T);
        }

        public void print()
        {
            Node<T> temp = myList;
            Console.WriteLine(myList.myObj);
            temp = temp.myNext;

            while (temp != myList)
            {
                Console.WriteLine(temp.myObj);
                temp = temp.myNext;
            }
        }

        public System.Collections.Generic.List<T> getList()
        {
            var items = new System.Collections.Generic.List<T>();

            for (int i = 0; i < this.size(); i++)
            {
                items.Add(this.get(i));
            }
            return items;
        }

        public bool contains(T t)
        {
            var items = getList();

            for (int i = 0; i < items.Count; i++)
            {
                if (items[i].Equals(t)) return true;
            }
            return false;
        }

        public void clear()
        {
            myList = null;
        }

        public int size()
        {
            if (myList == null) return 0;

            int cnt = 0;
            Node<T> temp = myList;
            cnt++;
            temp = myList.myNext;

            while (temp != myList)
            {
                cnt++;
                temp = temp.myNext;
            }

            return cnt;
        }

        public bool isEmpty()
        {
            return this.size() == 0;
        }
    }

    class LinkedListStack<T> : AdsClass<T>
    {
        private Node<T> myList;
        private Node<T> myLast;

        private void addFirst(T t)
        {
            Node<T> temp = new Node<T>(t);
            temp.myNext = myList;
            myList = temp;
        }
       
        public LinkedListStack()
        {
            myList = null;
            myLast = null;
        }

        public LinkedListStack(T t)
        {
            myList = new Node<T>(t);
            myLast = myList;
        }

        public void push(T t)
        {
            Node<T> temp = new Node<T>(t);
            if (myList == null)
            {
                myList = temp;
                myLast = temp;
            } else
            {
                this.addFirst(t);
            }
        }

        public T pop()
        {
            T obj = myList.myObj;
            myLast = myList;
            Node<T> temp = myLast.myNext;
            myList = temp;
            myLast = myList;
            return obj;
        }

        public T peek()
        {
            return myList.myObj;
        }

        public void print()
        {
            myLast = myList;
            while (myLast != null)
            {
                Console.WriteLine(myLast.myObj);
                myLast = myLast.myNext;
            }
        }

        public System.Collections.Generic.List<T> getList()
        {
            var items = new System.Collections.Generic.List<T>();

            myLast = myList;
            while (myLast != null)
            {
                items.Add(myLast.myObj);
                myLast = myLast.myNext;
            }

            return items;
        }

        public bool contains(T t)
        {
            var items = this.getList();

            for (int i = 0; i < items.Count; i++)
            {
                if (items[i].Equals(t)) return true;
            }

            return false;
        }

        public void clear()
        {
            myLast = null;
            myList = null;
        }

        public int size()
        {
            int cnt = 0;
            myLast = myList;
            while (myLast != null)
            {
                cnt++;
                myLast = myLast.myNext;
            }
            return cnt;
        }

        public bool isEmpty()
        {
            return this.size() == 0;
        }

    }

    class Stack<T> : AdsClass<T>
    {
        private System.Collections.Generic.List<T> myList;

        public Stack()
        {
            myList = new System.Collections.Generic.List<T>();
        }

        public Stack(T t) : this()
        {
            myList.Add(t);
        }

        public void push(T t)
        {
            myList.Add(t);
        }

        public T pop()
        {
            if (myList.Count == 0) return default(T);
            T temp = myList[myList.Count - 1];
            myList.RemoveAt(myList.Count - 1);
            return temp;
        }

        public T peek()
        {
            return myList[myList.Count - 1];
        }

        public void print()
        {
            foreach (var item in myList)
            {
                Console.WriteLine(item);
            }
        }

        public System.Collections.Generic.List<T> getList()
        {
            return myList;
        }

        public bool contains(T t)
        {
            return myList.Contains(t);
        }

        public void clear()
        {
            myList.Clear();
        }

        public int size()
        {
            return myList.Count;
        }

        public bool isEmpty()
        {
            return myList.Count == 0;
        }
    }

    class LinkedListQueue<T> : AdsClass<T>
    {
        private Node<T> myList;
        private Node<T> myLast;

        public LinkedListQueue()
        {
            myList = null;
            myLast = null;
        }

        public LinkedListQueue(T t)
        {
            myList = new Node<T>(t);
            myLast = myList;
        }

        public void enqueue(T t)
        {
            Node<T> temp = new Node<T>(t);
            if (myList == null)
            {
                myList = temp;
                myLast = temp;
            } else
            {
                myLast = myList;
                while (myLast.myNext != null)
                {
                    myLast = myLast.myNext;
                }
                myLast.myNext = temp;
            }
        }

        public T dequeue()
        {
            T obj = myList.myObj;
            myLast = myList;
            Node<T> temp = myLast.myNext;
            myList = temp;
            myLast = myList;
            return obj;
        }

        public T peek()
        {
            return myList.myObj;
        }

        public void print()
        {
            myLast = myList;
            while (myLast != null)
            {
                Console.WriteLine(myLast.myObj);
                myLast = myLast.myNext;
            }
        }

        public System.Collections.Generic.List<T> getList()
        {
            var items = new System.Collections.Generic.List<T>();
            myLast = myList;
            while (myLast != null)
            {
                items.Add(myLast.myObj);
                myLast = myLast.myNext;
            }
            return items;
        }

        public bool contains(T t)
        {
            var items = this.getList();

            for (int i = 0; i < items.Count; i++)
            {
                if (items[i].Equals(t)) return true;
            }
            return false;
        }

        public void clear()
        {
            myList = null;
            myLast = null;
        }

        public int size()
        {
            int cnt = 0;
            myLast = myList;
            while (myLast != null)
            {
                cnt++;
                myLast = myLast.myNext;
            }
            return cnt;
        }

        public bool isEmpty()
        {
            return this.size() == 0;
        }
    }

    class Queue<T> : AdsClass<T>
    {
        private System.Collections.Generic.List<T> myList;

        public Queue()
        {
            myList = new System.Collections.Generic.List<T>();
        }

        public Queue(T t) : this()
        {
            myList.Add(t);
        }

        public void enqueue(T t)
        {
            myList.Add(t);
        }

        public T dequeue()
        {
            if (myList.Count == 0) return default(T);
            T temp = myList[0];
            myList.RemoveAt(0);
            return temp;
        }

        public T peek()
        {
            if (myList.Count == 0) return default(T);
            return myList[0];
        }

        public void print()
        {
            foreach (var item in myList)
            {
                Console.WriteLine(item);
            }
        }

        public System.Collections.Generic.List<T> getList()
        {
            return myList;
        }

        public bool contains(T t)
        {
            return myList.Contains(t);
        }

        public void clear()
        {
            myList.Clear();
        }

        public int size()
        {
            return myList.Count;
        }

        public bool isEmpty()
        {
            return myList.Count == 0;
        }
    }

    class LinkedListSortedSet<T> : AdsClass<T> where T : IComparable
    {
        private Node<T> myList;
        private Node<T> myLast;

        private void addSorted(T t)
        {
            myLast = myList;
            Node<T> temp = new Node<T>(t);
            if (temp.myObj.CompareTo(myLast.myObj) == -1)
            {
                temp.myNext = myLast;
                myList = temp;
                return;
            }

            while (myLast.myNext != null)
            {
                if (temp.myObj.CompareTo(myLast.myNext.myObj) == -1)
                {
                    temp.myNext = myLast.myNext;
                    myLast.myNext = temp;
                    return;
                }
                myLast = myLast.myNext;
            }

            myLast.myNext = temp;
        }

        public LinkedListSortedSet()
        {
            myList = null;
            myLast = null;
        }

        public LinkedListSortedSet(T t)
        {
            myList = new Node<T>(t);
            myLast = myList;
        }


        public void add(T t)
        {
            Node<T> temp = new Node<T>(t);
            if (myList == null)
            {
                myList = temp;
                myLast = temp;
            } else
            {
                if (!this.contains(t)) this.addSorted(t);
            }
        }

        public void remove(int index)
        {
            if (index == 0)
            {
                myLast = myList;
                Node<T> temp = myLast.myNext;
                myList = temp;
                myLast = myList;
            }
            else if (index >= (this.size() - 1))
            {
                myLast = myList;
                while (myLast.myNext.myNext != null)
                {
                    myLast = myLast.myNext;
                }
                myLast.myNext = null;
            }
            else
            {
                int cnt = 0;
                myLast = myList;
                Node<T> tempx;
                while ((myLast.myNext != null) && (cnt <= index))
                {
                    if (cnt == (index - 1))
                    {
                        tempx = myLast;
                        tempx.myNext = myLast.myNext.myNext;
                        myLast = tempx;
                    }
                    cnt++;
                    myLast = myLast.myNext;
                }
            }
        }

        public T get(int index)
        {
            int cnt = 0;
            myLast = myList;
            T obj = default(T);
            while ((myLast.myNext != null) && (cnt <= index))
            {
                if (cnt == index) obj = myLast.myObj;
                myLast = myLast.myNext;
                cnt++;
            }
            if (cnt == index) obj = myLast.myObj;
            myLast = myList;
            return obj;
        }

        public void print()
        {
            myLast = myList;
            while (myLast != null)
            {
                Console.WriteLine(myLast.myObj);
                myLast = myLast.myNext;
            }
        }

        public System.Collections.Generic.List<T> getList()
        {
            var items = new System.Collections.Generic.List<T>();

            for (int i = 0; i < this.size(); i++)
            {
                items.Add(this.get(i));
            }
            return items;
        }

        public bool contains(T t)
        {
            var items = this.getList();

            for (int i = 0; i < this.size(); i++)
            {
                if (items[i].Equals(t)) return true;
            }
            return false;
        }

        public void clear()
        {
            myList = null;
            myLast = null;
        }

        public int size()
        {
            int cnt = 0;
            myLast = myList;
            while (myLast != null)
            {
                cnt++;
                myLast = myLast.myNext;
            }
            return cnt;
        }

        public bool isEmpty()
        {
            return (this.size() == 0);
        }
    }

    class SortedSet<T> : AdsClass<T> where T : IComparable
    {
        private System.Collections.Generic.List<T> myList;
        
        private void addSorted(T t)
        {
            for (int i = 0; i < myList.Count; i++)
            {
                if (t.CompareTo(myList[i]) == -1)
                {
                    myList.Insert(i, t);
                    return;
                }
            }
            myList.Add(t);
        }

        public SortedSet()
        {
            myList = new System.Collections.Generic.List<T>();
        }

        public SortedSet(T t) : this()
        {
            myList.Add(t);
        }

        public void add(T t)
        {
            if (!this.contains(t)) this.addSorted(t);
        }

        public void remove(int index)
        {
            myList.RemoveAt(index);
        }

        public T get(int index)
        {
            return myList[index];
        }

        public void print()
        {
            foreach (var item in myList)
            {
                Console.WriteLine(item);
            }
        }

        public System.Collections.Generic.List<T> getList()
        {
            return myList;
        }

        public bool contains(T t)
        {
            return myList.Contains(t);
        }

        public void clear()
        {
            myList.Clear();
        }

        public int size()
        {
            return myList.Count;
        }

        public bool isEmpty()
        {
            return (this.size() == 0);
        }

    }

    class LinkedListSet<T> : AdsClass<T>
    {
        private Node<T> myList;
        private Node<T> myLast;

        private void addLast(T t)
        {
            myLast = myList;
            while (myLast.myNext != null)
            {
                myLast = myLast.myNext;
            }
            Node<T> temp = new Node<T>(t);
            myLast.myNext = temp;
        }

        public LinkedListSet()
        {
            myList = null;
            myLast = null;
        }

        public LinkedListSet(T t)
        {
            myList = new Node<T>(t);
            myLast = myList;
        }

        public void add(T t)
        {
            Node<T> temp = new Node<T>(t);
            if (myList == null)
            {
                myList = temp;
                myLast = temp;
            }
            else
            {
                if (!this.contains(t)) this.addLast(t);
            }
        }

        public void remove(int index)
        {
            if (index == 0)
            {
                myLast = myList;
                Node<T> temp = myLast.myNext;
                myList = temp;
                myLast = myList;
            }
            else if (index >= (this.size() - 1))
            {
                myLast = myList;
                while (myLast.myNext.myNext != null)
                {
                    myLast = myLast.myNext;
                }
                myLast.myNext = null;
            }
            else
            {
                int cnt = 0;
                myLast = myList;
                Node<T> tempx;
                while ((myLast.myNext != null) && (cnt <= index))
                {
                    if (cnt == (index - 1))
                    {
                        tempx = myLast;
                        tempx.myNext = myLast.myNext.myNext;
                        myLast = tempx;
                    }
                    cnt++;
                    myLast = myLast.myNext;
                }
            }
        }

        public T get(int index)
        {
            int cnt = 0;
            myLast = myList;
            T obj = default(T);
            while ((myLast.myNext != null) && (cnt <= index))
            {
                if (cnt == index) obj = myLast.myObj;
                myLast = myLast.myNext;
                cnt++;
            }
            if (cnt == index) obj = myLast.myObj;
            myLast = myList;
            return obj;
        }

        public void print()
        {
            myLast = myList;
            while (myLast != null)
            {
                Console.WriteLine(myLast.myObj);
                myLast = myLast.myNext;
            }
        }

        public System.Collections.Generic.List<T> getList()
        {
            var items = new System.Collections.Generic.List<T>();

            for (int i = 0; i < this.size(); i++)
            {
                items.Add(this.get(i));
            }
            return items;
        }

        public bool contains(T t)
        {
            var items = this.getList();

            for (int i = 0; i < this.size(); i++)
            {
                if (items[i].Equals(t)) return true;
            }
            return false;
        }

        public void clear()
        {
            myList = null;
            myLast = null;
        }

        public int size()
        {
            int cnt = 0;
            myLast = myList;
            while (myLast != null)
            {
                cnt++;
                myLast = myLast.myNext;
            }
            return cnt;
        }

        public bool isEmpty()
        {
            return (this.size() == 0);
        }
    }

    class Set<T> : AdsClass<T>
    {
        private System.Collections.Generic.List<T> myList;

        public Set()
        {
            myList = new System.Collections.Generic.List<T>();
        }

        public Set(T t) : this()
        {
            myList.Add(t);
        }

        public void add(T t)
        {
            if (!this.contains(t)) myList.Add(t);
        }

        public void remove(int index)
        {
            myList.RemoveAt(index);
        }

        public T get(int index)
        {
            return myList[index];
        }

        public void print()
        {
            foreach (var item in myList)
            {
                Console.WriteLine(item);
            }
        }

        public System.Collections.Generic.List<T> getList()
        {
            return myList;
        }
        
        public bool contains(T t)
        {
            return myList.Contains(t);
        }

        public void clear()
        {
            myList.Clear();
        }

        public int size()
        {
            return myList.Count;
        }

        public bool isEmpty()
        {
            return (this.size() == 0);
        }

    }

    class LinkedListMultiset<T> : AdsClass<T> where T : IComparable
    {
        private Node<T> myList;
        private Node<T> myLast;

        private void addSorted(T t)
        {
            myLast = myList;
            Node<T> temp = new Node<T>(t);
            if (temp.myObj.CompareTo(myLast.myObj) == -1)
            {
                temp.myNext = myLast;
                myList = temp;
                return;
            }
            while (myLast.myNext != null)
            {
                if (temp.myObj.CompareTo(myLast.myNext.myObj) == -1)
                {
                    temp.myNext = myLast.myNext;
                    myLast.myNext = temp;
                    return;
                }
                myLast = myLast.myNext;
            }

            myLast.myNext = temp;
        }

        public LinkedListMultiset()
        {
            myList = null;
            myLast = null;
        }

        public LinkedListMultiset(T t) : this()
        {
            myList = new Node<T>(t);
            myLast = myList;
        }

        public void add(T t)
        {
            Node<T> temp = new Node<T>(t);
            if (myList == null)
            {
                myList = temp;
                myLast = temp;
            } else
            {
                this.addSorted(t);
            }
        }

        public void remove(int index)
        {
            if (index == 0)
            {
                myLast = myList;
                Node<T> temp = myLast.myNext;
                myList = temp;
                myLast = myList;
            }
            else if (index == (this.size() - 1))
            {
                myLast = myList;
                while (myLast.myNext.myNext != null)
                {
                    myLast = myLast.myNext;
                }
                myLast.myNext = null;
            }
            else
            {
                int cnt = 0;
                myLast = myList;
                Node<T> tempx;
                while ((myLast.myNext != null) && (cnt <= index))
                {
                    if (cnt == (index - 1))
                    {
                        tempx = myLast;
                        tempx.myNext = myLast.myNext.myNext;
                        myLast = tempx;
                    }
                    cnt++;
                    myLast = myLast.myNext;
                }
            }
        }

        public T get(int index)
        {
            int cnt = 0;
            myLast = myList;
            T obj = default(T);
            while ((myLast.myNext != null) && (cnt <= index))
            {
                if (cnt == index) obj = myLast.myObj;
                myLast = myLast.myNext;
                cnt++;
            }
            if (cnt == index) obj = myLast.myObj;
            myLast = myList;
            return obj;
        }

        public void print()
        {
            myLast = myList;
            while (myLast != null)
            {
                Console.WriteLine(myLast.myObj);
                myLast = myLast.myNext;
            }
        }

        public System.Collections.Generic.List<T> getList()
        {
            var items = new System.Collections.Generic.List<T>();

            for (int i = 0; i < this.size(); i++)
            {
                items.Add(this.get(i));
            }
            return items;
        }

        public Adscol.Set<T> getSet()
        {
            var items = new Adscol.Set<T>();

            for (int i= 0; i < this.size(); i++)
            {
                items.add(this.get(i));
            }
            return items;
        }

        public bool contains(T t)
        {
            var items = this.getList();

            for (int i = 0; i < items.Count; i++)
            {
                if (items[i].Equals(t)) return true;
            }
            return false;
        }

        public void clear()
        {
            myList = null;
            myLast = null;
        }

        public int size()
        {
            int cnt = 0;
            myLast = myList;
            while (myLast != null)
            {
                cnt++;
                myLast = myLast.myNext;
            }
            return cnt;
        }

        public bool isEmpty()
        {
            return (this.size() == 0);
        }
    }

    class Multiset<T> : AdsClass<T> where T : IComparable 
    {
        private System.Collections.Generic.List<T> myList;

        private void addSorted(T t)
        {
            for (int i = 0; i < myList.Count; i++)
            {
                if (t.CompareTo(myList[i]) == -1)
                {
                    myList.Insert(i, t);
                    return;
                }
            }
            myList.Add(t);
        }

        public Multiset()
        {
            myList = new System.Collections.Generic.List<T>();
        }

        public Multiset(T t) : this()
        {
            myList.Add(t);
        }

        public void add(T t)
        {
            this.addSorted(t);
        }

        public void remove(int index)
        {
            myList.RemoveAt(index);
        }

        public T get(int index)
        {
            return myList[index];
        }

        public void print()
        {
            foreach (var item in myList)
            {
                Console.WriteLine(item);
            }
        }

        public System.Collections.Generic.List<T> getList()
        {
            return myList;
        }

        public Adscol.Set<T> getSet()
        {
            var items = new Adscol.Set<T>();

            foreach (var item in myList)
            {
                items.add(item);
            }

            return items;
        }

        public bool contains(T t)
        {
            return myList.Contains(t);
        }

        public void clear()
        {
            myList.Clear();
        }

        public int size()
        {
            return myList.Count;
        }

        public bool isEmpty()
        {
            return (this.size() == 0);
        }

    }

    class LinkedListBag<T> : AdsClass<T>
    {
        private Node<T> myList;
        private Node<T> myLast;

        private void addLast(T t)
        {
            myLast = myList;
            while (myLast.myNext != null)
            {
                myLast = myLast.myNext;
            }
            Node<T> temp = new Node<T>(t);
            myLast.myNext = temp;
        }

        public LinkedListBag()
        {
            myList = null;
            myLast = null;
        }

        public LinkedListBag(T t)
        {
            myList = new Node<T>(t);
            myLast = myList;
        }

        public void add(T t)
        {
            if (myList == null)
            {
                Node<T> temp = new Node<T>(t);
                myList = temp;
                myLast = temp;
            }
            else
            {
                this.addLast(t);
            }
        }

        public T get(int index)
        {
            int cnt = 0;
            myLast = myList;
            while ((myLast.myNext != null) && (cnt <= index))
            {
                if (cnt == index) return myLast.myObj;
                myLast = myLast.myNext;
                cnt++;
            }
            if (cnt == index) return myLast.myObj;
            return default(T);
        }

        public void print()
        {
            myLast = myList;
            while (myLast != null)
            {
                Console.WriteLine(myLast.myObj);
                myLast = myLast.myNext;
            }
        }

        public System.Collections.Generic.List<T> getList()
        {
            var items = new System.Collections.Generic.List<T>();

            for (int i = 0; i < this.size(); i++)
            {
                items.Add(this.get(i));
            }
            return items;
        }

        public bool contains(T t)
        {
            var items = this.getList();

            for (int i = 0; i < items.Count; i++)
            {
                if (items[i].Equals(t)) return true;
            }
            return false;
        }

        public void clear()
        {
            myList = null;
            myLast = null;
        }

        public int size()
        {
            int cnt = 0;
            myLast = myList;
            while (myLast != null)
            {
                cnt++;
                myLast = myLast.myNext;
            }
            return cnt;
        }

        public bool isEmpty()
        {
            return (this.size() == 0);
        }
    }

    class Bag<T> : AdsClass<T>
    {
        private System.Collections.Generic.List<T> myList;

        public Bag()
        {
            myList = new System.Collections.Generic.List<T>();
        }

        public Bag(T t) : this()
        {
            myList.Add(t);
        }

        public void add(T t)
        {
            myList.Add(t);
        }

        public T get(int index)
        {
            return myList[index];
        }

        public void print()
        {
            foreach (var item in myList)
            {
                Console.WriteLine(item);
            }
        }

        public System.Collections.Generic.List<T> getList()
        {
            return myList;
        }

        public bool contains(T t)
        {
            return myList.Contains(t);
        }

        public void clear()
        {
            myList.Clear();
        }

        public int size()
        {
            return myList.Count;
        }

        public bool isEmpty()
        {
            return (this.size() == 0);
        }
    }

    class TreeNode<T>
    {
        public T myObj;
        public TreeNode<T> myLeft;
        public TreeNode<T> myRight;

        public TreeNode(T t)
        {
            myObj = t;
            myLeft = null;
            myRight = null;
        }
    }

    class BinaryTree<T> : AdsClassMin where T : IComparable
    {
        private TreeNode<T> root;
        private System.Collections.Generic.List<T> items;

        private void getListInOrderT(TreeNode<T> r)
        {
            if (r == null) return;
            getListInOrderT(r.myLeft);
            items.Add(r.myObj);
            getListInOrderT(r.myRight);
        }

        private void getListPreOrderT(TreeNode<T> r)
        {
            if (r == null) { return; }
            items.Add(r.myObj);
            getListPreOrderT(r.myLeft);
            getListPreOrderT(r.myRight);
        }

        private void getListPostOrderT(TreeNode<T> r)
        {
            if (r == null) { return; }
            getListPostOrderT(r.myLeft);
            getListPostOrderT(r.myRight);
            items.Add(r.myObj);
        }

        private static void printInOrderT(TreeNode<T> r)
        {
            if (r == null) return;
            printInOrderT(r.myLeft);
            Console.WriteLine(r.myObj);
            printInOrderT(r.myRight);
        }

        private static void printPreOrderT(TreeNode<T> r)
        {
            if (r == null) return;
            Console.WriteLine(r.myObj);
            printPreOrderT(r.myLeft);
            printPreOrderT(r.myRight);
        }

        private static void printPostOrderT(TreeNode<T> r)
        {
            if (r == null) return;
            printPostOrderT(r.myLeft);
            printPostOrderT(r.myRight);
            Console.WriteLine(r.myObj);
        }

        private static void invertTree(TreeNode<T> r)
        {
            if (r == null) return;
            TreeNode<T> temp = r.myLeft;
            r.myLeft = r.myRight;
            r.myRight = temp;
            invertTree(r.myLeft);
            invertTree(r.myRight);
        }

        private static int countItems(TreeNode<T> r)
        {
            if (r == null) return 0;
            return countItems(r.myLeft) + 1 + countItems(r.myRight);
        }

        private static int numCounter(TreeNode<T> r, T t)
        {
            if (r == null) { return 0; }

            if (r.myObj.Equals(t))
            {
                return numCounter(r.myLeft, t) + 1 + numCounter(r.myRight, t);
            }
            else
            {
                return numCounter(r.myLeft, t) + 0 + numCounter(r.myRight, t);
            }
        }

        private int maxWidth = 0;

        private int findMaxWidth(TreeNode<T> r)
        {
            Queue<TreeNode<T>> q = new Queue<TreeNode<T>>();
            int levelNodes = 0;
            if (r == null) return 0;
            q.enqueue(r);

            while (!q.isEmpty())
            {
                levelNodes = q.size();

                if (levelNodes > maxWidth)
                {
                    maxWidth = levelNodes;
                }

                while (levelNodes > 0)
                {
                    TreeNode<T> n = q.dequeue();
                    if (n.myLeft != null) q.enqueue(n.myLeft);
                    if (n.myRight != null) q.enqueue(n.myRight);
                    levelNodes--;
                }
            }

            return maxWidth;
        }

        private int findMaxHeight(TreeNode<T> r)
        {
            if (r == null) return 0;
            return (1 + Math.Max(findMaxHeight(r.myLeft), findMaxHeight(r.myRight)));
        }

        private void addNode(TreeNode<T> node)
        {
            if (root == null)
            {
                root = node;
            }
            else
            {
                TreeNode<T> prev = root;
                TreeNode<T> spot = root;

                while (spot != null)
                {
                    if (node.myObj.CompareTo(spot.myObj) == -1)
                    {
                        prev = spot;
                        spot = spot.myLeft;
                    }
                    else
                    {
                        prev = spot;
                        spot = spot.myRight;
                    }
                }

                if (node.myObj.CompareTo(prev.myObj) == -1)
                {
                    prev.myLeft = node;
                }
                else
                {
                    prev.myRight = node;
                }
            }
        }

        public BinaryTree()
        {
            root = null;
            items = new System.Collections.Generic.List<T>();
        }

        public BinaryTree(T t) : this()
        {
            this.add(t);
        }

        public void add(T t)
        {
            TreeNode<T> temp = new TreeNode<T>(t);

            if (root == null)
            {
                root = temp;
            }
            else
            {
                TreeNode<T> prev = root;
                TreeNode<T> spot = root;

                while (spot != null)
                {
                    if (temp.myObj.CompareTo(spot.myObj) == -1)
                    {
                        prev = spot;
                        spot = spot.myLeft;
                    }
                    else
                    {
                        prev = spot;
                        spot = spot.myRight;
                    }
                }

                if (temp.myObj.CompareTo(prev.myObj) == -1)
                {
                    prev.myLeft = temp;
                }
                else
                {
                    prev.myRight = temp;
                }
            }
        }

        public void remove(T t)
        {
            TreeNode<T> prev = root;
            TreeNode<T> spot = root;
            bool passedRoot = false;
            int oldCount = numCounter(root, t);
            while (numCounter(root, t) != (oldCount - 1))
            {
                if (spot.myObj.Equals(t) && !passedRoot)
                {
                    if (root.myRight != null)
                    {
                        TreeNode<T> temp = root.myRight.myLeft;
                        TreeNode<T> tempL = root.myLeft;
                        root = root.myRight;
                        root.myLeft = tempL;
                        this.addNode(temp);
                    }
                    else if (root.myLeft != null)
                    {
                        TreeNode<T> temp = root.myLeft.myRight;
                        TreeNode<T> tempR = root.myRight;
                        root = root.myLeft;
                        root.myRight = tempR;
                        this.addNode(temp);
                    }
                    else
                    {
                        root = null;
                    }
                }

                while (!spot.myObj.Equals(t))
                {
                    if (t.CompareTo(spot.myObj) == -1)
                    {
                        prev = spot;
                        spot = spot.myLeft;
                    }
                    else
                    {
                        prev = spot;
                        spot = spot.myRight;
                    }
                }

                if ((spot.myLeft == null) && (spot.myRight == null))
                {
                    if (t.CompareTo(prev.myObj) == -1)
                    {
                        prev.myLeft = null;
                    }
                    else
                    {
                        prev.myRight = null;
                    }
                }
                else
                {
                    if ((spot.myLeft == null) || (spot.myRight == null))
                    {
                        if (t.CompareTo(prev.myObj) == -1)
                        {
                            if (spot.myLeft == null)
                            {
                                prev.myLeft = spot.myRight;
                            }
                            else
                            {
                                prev.myLeft = spot.myLeft;
                            }
                        }
                        else
                        {
                            if (spot.myRight == null)
                            {
                                prev.myRight = spot.myRight;
                            }
                            else
                            {
                                prev.myRight = spot.myLeft;
                            }
                        }
                    }
                    else
                    {
                        TreeNode<T> pmover = spot.myRight;
                        TreeNode<T> mover = spot.myRight;
                        while (mover.myLeft != null)
                        {
                            pmover = mover;
                            mover = mover.myLeft;
                        }
                        if (pmover == mover)
                        {
                            spot.myObj = mover.myObj;
                            spot.myRight = mover.myRight;
                        }
                        else
                        {
                            spot.myObj = mover.myObj;
                            pmover.myLeft = mover.myRight;
                        }
                    }
                }
                passedRoot = true;
            }
        }

        public void removeAll(T t)
        {
            while (this.contains(t))
            {
                remove(t);
            }
        }

        public int width()
        {
            int w = findMaxWidth(root);
            maxWidth = 0;
            return w;
        }

        public int height()
        {
            return findMaxHeight(root);
        }

        public void invert()
        {
            invertTree(root);
        }

        public void printPreOrder()
        {
            printPreOrderT(root);
        }

        public void printInOrder()
        {
            printInOrderT(root);
        }

        public void printPostOrder()
        {
            printPreOrderT(root);
        }

        public System.Collections.Generic.List<T> getListPreOrder()
        {
            items.Clear();
            getListPreOrderT(root);
            return items;
        }

        public System.Collections.Generic.List<T> getListInOrder()
        {
            items.Clear();
            getListInOrderT(root);
            return items;
        }

        public System.Collections.Generic.List<T> getListPostOrder()
        {
            items.Clear();
            getListPostOrderT(root);
            return items;
        }

        public bool contains(T t)
        {
            var items = this.getListInOrder();

            for (int i = 0; i < items.Count; i++)
            {
                if (items[i].Equals(t)) return true;
            }
            return false;
        }

        public void clear()
        {
            root = null;
            items.Clear();
        }

        public int size()
        {
            return countItems(root);
        }

        public bool isEmpty()
        {
            return (this.size() == 0);
        }
    }

    class PQNode<T> : IComparable<PQNode<T>>
    {
        public int priority;
        public T myObj;

        public PQNode(int p, T t)
        {
            priority = p;
            myObj = t;
        }

        public int CompareTo(PQNode<T> o)
        {
            if (this.priority < o.priority) return -1;
            if (this.priority == o.priority) return 0;
            if (this.priority > o.priority) return 1;
            return -1;
        }
    }

    class PriorityQueue<T> : AdsClass<T>
    {
        private System.Collections.Generic.List<PQNode<T>> myList;

        public PriorityQueue()
        {
            myList = new System.Collections.Generic.List<PQNode<T>>();
        }

        public void enqueue(T t, int priority)
        {
            myList.Add(new PQNode<T>(priority, t));

            myList.Sort();
        }

        public T dequeue()
        {
            T temp = myList[0].myObj;
            myList.RemoveAt(0);
            return temp;
        }

        public T peek()
        {
            return myList[0].myObj;
        }

        public void print()
        {
            foreach (PQNode<T> item in myList)
            {
                Console.WriteLine("Priority: " + item.priority + " Data: " + item.myObj);
            }
        }

        public System.Collections.Generic.List<T> getList()
        {
            var items = new System.Collections.Generic.List<T>();

            foreach (PQNode<T> item in myList)
            {
                items.Add(item.myObj);
            }
            return items;
        }

        public bool contains(T t)
        {
            var items = this.getList();
            return items.Contains(t);
        }

        public void clear()
        {
            myList.Clear();
        }

        public int size()
        {
            return myList.Count;
        }

        public bool isEmpty()
        {
            return (this.size() == 0);
        }

    }

    class ArrayList<T> : AdsClass<T>
    {
        private T[] array;
        private int _size;
        private int memsize;
        const int basesize = 16;

        private void copy(ArrayList<T> a)
        {
            array = new T[a.memsize];
            if (array == null)
            {
                throw memFail();
            }

            for (int i = 0; i < a._size; i++)
            {
                array[i] = a.array[i];
            }

            memsize = a.memsize;
            _size = a._size;
        }
        
        private void doubleSize()
        {
            T[] temp = null;
            int new_size;
            if (memsize == 0)
            {
                temp = new T[basesize];
                new_size = 1;
            } else
            {
                temp = new T[memsize * 2];
                new_size = memsize * 2;
            }
            if (temp == null)
            {
                throw memFail();
            }

            for (int i = 0; i < _size; i++)
            {
                temp[i] = array[i];
            }

            array = temp;
            memsize = new_size;
        }

        private void halfsize()
        {
            int resize = memsize / 2;
            if (memsize < (basesize * 2))
            {
                resize = basesize;
            }

            T[] temp = new T[resize];

            if (temp == null)
            {
                throw memFail();
            }

            for (int i = 0; i < _size; i++)
            {
                temp[i] = array[i];
            }

            array = temp;
            memsize = resize;
        }

        private Exception memFail()
        {
            return new Exception("Memory Allocation Failed");
        }

        private IndexOutOfRangeException badAccess()
        {
            return new IndexOutOfRangeException("Attempting to subscript array element that doesn't exist");
        }

        public ArrayList()
        {
            array = new T[basesize];
            if (array == null)
            {
                throw memFail();
            }

            _size = 0;
            memsize = basesize;
        }

        public ArrayList(int size)
        {
            if (size == 0)
            {
                array = null;
            } else
            {
                array = new T[size];
                if (array == null)
                {
                    throw memFail();
                }
            }

            _size = 0;
            memsize = size;
        }

        public ArrayList(ArrayList<T> a)
        {
            copy(a);
        }

        public T this[int index]
        {
            get
            {
                return get(index);
            }
            set
            {
                set(index, value);
            }
        }

        public void add(T t)
        {
            if ((_size + 1) > memsize)
            {
                doubleSize();
            }

            array[_size] = t;
            _size++;
        }

        public void add(int index, T t)
        {
            if (index > _size)
            {
                throw badAccess();
            }
            if ((_size + 1) > memsize)
            {
                doubleSize();
            }
            for (int i = _size; i > index; i--)
            {
                array[i] = array[i - 1];
            }
            array[index] = t;
            _size++;
        }

        public void appendAll(ArrayList<T> items)
        {
            for (int i = 0; i < items._size; i++)
            {
                add(items.array[i]);
            }
        }

        public void remove(int index)
        {
            if (index > (_size - 1))
            {
                throw badAccess();
            }
            for (int i = index; i < _size - 1; i++)
            {
                array[i] = array[i + 1];
            }
            _size--;
            if (_size <= (memsize / 4) && memsize > basesize)
            {
                halfsize();
            }
        }

        public void set(int index, T t)
        {
            if (index > _size)
            {
                throw badAccess();
            }
            array[index] = t;
        }

        public T get(int index)
        {
            if (index > (_size - 1))
            {
                throw badAccess();
            }
            return array[index];
        }

        public void print()
        {
            for (int i = 0; i < _size; i++)
            {
                Console.WriteLine(array[i]);
            }
        }

        public System.Collections.Generic.List<T> getList()
        {
            var items = new System.Collections.Generic.List<T>();

            for (int i = 0; i < _size; i++)
            {
                items.Add(array[i]);
            }
            return items;
        }

        public bool contains(T t)
        {
            for (int i = 0; i < _size; i++)
            {
                if (array[i].Equals(t))
                {
                    return true;
                }
            }
            return false;
        }

        public void clear()
        {
            for (int i = _size - 1; i >= 0; i--)
            {
                remove(i);
            }
        }

        public int size()
        {
            return _size;
        }

        public bool isEmpty()
        {
            return (this.size() == 0);
        }

        public bool equals(ArrayList<T> a)
        {
            if (_size != a._size)
            {
                return false;
            }

            for (int i = 0; i < _size; i++)
            {
                if (array[i].Equals(a.array[i]))
                {
                    return false;
                }
            }
            return true;
        }

        public void reverse()
        {
            T[] temp = new T[memsize];
            if (temp == null)
            {
                throw memFail();
            }

            for (int i = _size - 1; i >= 0; i--)
            {
                temp[_size - 1 - i] = array[i];
            }

            array = temp;
        }

        public void trimToSize()
        {
            if (_size == memsize)
            {
                return;
            }
            T[] temp = new T[_size];
            if (temp == null)
            {
                memFail();
            }
            for (int i = 0; i < _size; i++)
            {
                temp[i] = array[i];
            }
            
            array = temp;
            memsize = _size;
        }

        public ArrayList<T> subList(int fromIndex, int toIndex)
        {
            ArrayList<T> temp = new ArrayList<T>();
            if (temp == null)
            {
                throw memFail();
            }

            if (toIndex >= _size || fromIndex >= _size)
            {
                throw badAccess();
            }

            if (fromIndex >= toIndex)
            {
                return temp;
            }

            for (int i = fromIndex; i < toIndex; i++)
            {
                temp.add(array[i]);
            }
            return temp;
        }
    }

    class Deque<T> : AdsClass<T>
    {
        private System.Collections.Generic.List<T> myList;

        public Deque()
        {
            myList = new System.Collections.Generic.List<T>();
        }

        public void pushFront(T t)
        {
            myList.Insert(0, t);
        }

        public void pushBack(T t)
        {
            myList.Add(t);
        }

        public T popFront()
        {
            T obj = myList[0];
            myList.RemoveAt(0);
            return obj;
        }

        public T popBack()
        {
            T obj = myList[myList.Count - 1];
            myList.RemoveAt(myList.Count - 1);
            return obj;
        }

        public T peekFront()
        {
            return myList[0];
        }

        public T peekBack()
        {
            return myList[myList.Count - 1];
        }

        public void print()
        {
            foreach (var item in myList)
            {
                Console.WriteLine(item);
            }
        }

        public System.Collections.Generic.List<T> getList()
        {
            return myList;
        }

        public bool contains(T t)
        {
            return myList.Contains(t);
        }

        public void clear()
        {
            myList.Clear();
        }

        public int size()
        {
            return myList.Count;
        }

        public bool isEmpty()
        {
            return (this.size() == 0);
        }
    }

    class CircularQueue<T> : AdsClass<T>
    {
        private const int DEFAULT_SIZE = 10;
        private int myMaxSize;
        private int myCurrentSize;
        private int myStart;
        private int myEnd;
        private T[] myBuffer;

        public CircularQueue()
        {
            myMaxSize = DEFAULT_SIZE;
            myBuffer = new T[myMaxSize];
            myStart = 0;
            myEnd = 0;
            myCurrentSize = 0;
        }

        public CircularQueue(int size)
        {
            myMaxSize = size;
            myBuffer = new T[myMaxSize];
            myStart = 0;
            myEnd = 0;
            myCurrentSize = 0;
        }

        public void enqueue(T t)
        {
            myEnd = (myEnd + 1) % myMaxSize;
            myBuffer[myEnd] = t;
            if (myCurrentSize == myMaxSize)
            {
                myStart = (myStart + 1) % myMaxSize;
            }
            else
            {
                myCurrentSize++;
            }
        }

        public T dequeue()
        {
            if (myCurrentSize == 0)
            {
                return default(T);
            }
            else
            {
                myStart = (myStart + 1) % myMaxSize;
                myCurrentSize--;
                return myBuffer[myStart];
            }
        }

        public T peek()
        {
            if (myCurrentSize == 0)
            {
                return default(T);
            }
            else
            {
                myStart = (myStart + 1) % myMaxSize;
                return myBuffer[myStart];
            }
        }

        public void print()
        {
            int tempLoc = 0;
            for (int i = 0; i < myCurrentSize; i++)
            {
                tempLoc = (tempLoc + 1) % myMaxSize;
                Console.WriteLine(myBuffer[tempLoc]);
            }
        }

        public System.Collections.Generic.List<T> getList()
        {
            var items = new System.Collections.Generic.List<T>();

            int tempLoc = 0;
            for (int i = 0; i < myCurrentSize; i++)
            {
                tempLoc = (tempLoc + 1) % myMaxSize;
                items.Add(myBuffer[tempLoc]);
            }

            return items;
        }

        public bool contains(T t)
        {
            var items = this.getList();

            for (int i = 0; i < items.Count; i++)
            {
                if (items[i].Equals(t)) return true;
            }

            return false;
        }

        public void clear()
        {
            myCurrentSize = 0;
            myStart = 0;
            myEnd = 0;
            myBuffer = new T[myMaxSize];
        }

        public int size()
        {
            return myCurrentSize;
        }

        public bool isEmpty()
        {
            return (this.size() == 0);
        }

        public bool isFull()
        {
            return (myCurrentSize == myMaxSize);
        }
    }

    class CircularLinkedList<T> : AdsClass<T>
    {
        private Node<T> myList;

        public CircularLinkedList()
        {
            myList = null;
        }

        public void addFront(T t)
        {
            Node<T> temp = new Node<T>(t);

            if (myList == null)
            {
                temp.myNext = temp;
                myList = temp;
                return;
            }

            Node<T> myLast = myList;

            while (myLast.myNext != myList)
            {
                myLast = myLast.myNext;
            }

            if (myList != null)
            {
                temp.myNext = myList;
                myLast.myNext = temp;
                myList = temp;
            }
        }

        public void addBack(T t)
        {
            Node<T> temp = new Node<T>(t);

            if (myList == null)
            {
                temp.myNext = temp;
                myList = temp;
                return;
            }

            Node<T> myLast = myList;
            while (myLast.myNext != myList)
            {
                myLast = myLast.myNext;
            }

            myLast.myNext = temp;
            temp.myNext = myList;
        }

        public T popFront()
        {
            Node<T> temp = myList;
            Node<T> myLast = myList;

            if (myList != null)
            {
                while (myLast.myNext != myList)
                {
                    myLast = myLast.myNext;
                }
                myList = temp.myNext;
                myLast.myNext = myList;
                T obj = temp.myObj;
                temp = null;
                return obj;
            }
            return default(T);
        }

        public T popBack()
        {
            Node<T> temp = myList;
            Node<T> myLast = myList;

            if (myList != null)
            {
                while (myLast.myNext != myList)
                {
                    temp = myLast;
                    myLast = myLast.myNext;
                }
                T obj = temp.myObj;
                temp.myNext = myList;
                myLast = null;
                return obj;
            }
            return default(T);
        }

        public void print()
        {
            Node<T> myLast = myList;

            if (myList != null)
            {
                while (myLast.myNext != myList)
                {
                    Console.WriteLine(myLast.myObj);
                    myLast = myLast.myNext;
                }
                Console.WriteLine(myLast.myObj);
            }
        }

        public System.Collections.Generic.List<T> getList()
        {
            var items = new System.Collections.Generic.List<T>();

            Node<T> myLast = myList;

            if (myList != null)
            {
                while (myLast.myNext != myList)
                {
                    items.Add(myLast.myObj);
                    myLast = myLast.myNext;
                }
                items.Add(myLast.myObj);
            }
            return items;
        }

        public bool contains(T t)
        {
            var items = this.getList();

            for (int i = 0; i < items.Count; i++)
            {
                if (items[i].Equals(t)) return true;
            }

            return false;
        }

        public void clear()
        {
            myList = null;
        }

        public int size()
        {
            Node<T> myLast = myList;
            int cnt = 0;
            if (myList != null)
            {
                cnt++;
                while (myLast.myNext != myList)
                {
                    myLast = myLast.myNext;
                    cnt++;
                }
                return cnt;
            }
            return 0;
        }

        public bool isEmpty()
        {
            return (this.size() == 0);
        }
    }

    class Entry<K, V> : IComparable<Entry<K, V>> where K : IComparable
    {
        private K key;
        private V value;
        private bool cleared;

        public Entry(K key, V value)
        {
            this.key = key;
            this.value = value;
            this.cleared = false;
        }

        public K getKey()
        {
            return key;
        }

        public V getValue()
        {
            return value;
        }

        public bool isCleared()
        {
            return cleared;
        }

        public void setKey(K key)
        {
            this.key = key;
        }

        public void setValue(V value)
        {
            this.value = value;
        }

        public void setCleared(bool cleared)
        {
            this.cleared = cleared;
        }

        public int CompareTo(Entry<K, V> o)
        {
            return key.CompareTo(o.key);
        }
    }

    class SortedMap<K, V> : AdsClassMin where K : IComparable
    {
        private System.Collections.Generic.List<Entry<K, V>> myMap;

        private int indexOf(K key)
        {
            for (int i = 0; i < myMap.Count; i++)
            {
                if (myMap[i].getKey().Equals(key)) return i;
            }
            return -1;
        }

        public SortedMap()
        {
            myMap = new System.Collections.Generic.List<Entry<K, V>>();
        }

        public V this[K key]
        {
            get
            {
                return get(key);
            }
        }

        public void add(K key, V value)
        {
            if (!containsKey(key))
            {
                Entry<K, V> temp = new Entry<K, V>(key, value);
                myMap.Add(temp);
                myMap.Sort();
            }
        }

        public void remove(K key)
        {
            if (containsKey(key))
            {
                myMap.RemoveAt(this.indexOf(key));
            }
        }

        public V get(K key)
        {
            if (containsKey(key))
            {
                return myMap[this.indexOf(key)].getValue();
            }
            return default(V);
        }
        
        public void print()
        {
            for (int i = 0; i < myMap.Count; i++)
            {
                Console.WriteLine("Key: " + myMap[i].getKey() + "\tValue: " + myMap[i].getValue());
            }
        }

        public System.Collections.Generic.List<K> getKeyList()
        {
            var keys = new System.Collections.Generic.List<K>();

            for (int i = 0; i < myMap.Count; i++)
            {
                keys.Add(myMap[i].getKey());
            }
            return keys;
        }

        public System.Collections.Generic.List<V> getValueList()
        {
            var values = new System.Collections.Generic.List<V>();

            for (int i = 0; i < myMap.Count; i++)
            {
                values.Add(myMap[i].getValue());
            }
            return values;
        }

        public bool containsKey(K key)
        {
            for (int i = 0; i < myMap.Count; i++)
            {
                if (myMap[i].getKey().Equals(key)) return true;
            }
            return false;
        }

        public bool containsValue(V value)
        {
            for (int i = 0; i < myMap.Count; i++)
            {
                if (myMap[i].getValue().Equals(value)) return true;
            }
            return false;
        }

        public void clear()
        {
            myMap.Clear();
        }

        public int size()
        {
            return myMap.Count;
        }

        public bool isEmpty()
        {
            return (this.size() == 0);
        }
    }
    
    class Map<K, V> : AdsClassMin where K : IComparable
    {
        private System.Collections.Generic.List<Entry<K, V>> myMap;

        private int indexOf(K key)
        {
            for (int i = 0; i < myMap.Count; i++)
            {
                if (myMap[i].getKey().Equals(key)) return i;
            }
            return -1;
        }

        public Map()
        {
            myMap = new System.Collections.Generic.List<Entry<K, V>>();
        }

        public V this[K key]
        {
            get
            {
                return get(key);
            }
        }

        public void add(K key, V value)
        {
            if (!containsKey(key))
            {
                Entry<K, V> temp = new Entry<K, V>(key, value);
                myMap.Add(temp);
            }
        }

        public void remove(K key)
        {
            if (containsKey(key))
            {
                myMap.RemoveAt(this.indexOf(key));
            }
        }

        public V get(K key)
        {
            if (containsKey(key))
            {
                return myMap[this.indexOf(key)].getValue();
            }
            return default(V);
        }

        public void print()
        {
            for (int i = 0; i < myMap.Count; i++)
            {
                Console.WriteLine("Key: " + myMap[i].getKey() + "\tValue: " + myMap[i].getValue());
            }
        }

        public System.Collections.Generic.List<K> getKeyList()
        {
            var keys = new System.Collections.Generic.List<K>();

            for (int i = 0; i < myMap.Count; i++)
            {
                keys.Add(myMap[i].getKey());
            }
            return keys;
        }

        public System.Collections.Generic.List<V> getValueList()
        {
            var values = new System.Collections.Generic.List<V>();

            for (int i = 0; i < myMap.Count; i++)
            {
                values.Add(myMap[i].getValue());
            }
            return values;
        }

        public bool containsKey(K key)
        {
            for (int i = 0; i < myMap.Count; i++)
            {
                if (myMap[i].getKey().Equals(key)) return true;
            }
            return false;
        }

        public bool containsValue(V value)
        {
            for (int i = 0; i < myMap.Count; i++)
            {
                if (myMap[i].getValue().Equals(value)) return true;
            }
            return false;
        }

        public void clear()
        {
            myMap.Clear();
        }

        public int size()
        {
            return myMap.Count;
        }

        public bool isEmpty()
        {
            return (this.size() == 0);
        }
    }

    class HashMap<K, V> : AdsClassMin where K : IComparable
    {
        private System.Collections.Generic.List<Entry<K, V>> hashTable;

        private int numberOfEntries;
        private int tableSize;
        private double loadFactor;

        private void checkForRehashing()
        {
            loadFactor = (double)numberOfEntries / tableSize;
            if (loadFactor >= 0.75) rehash();
        }

        private void rehash()
        {
            var prevHashTable = hashTable;

            numberOfEntries = 0;
            tableSize *= 2;
            loadFactor = 0;
            hashTable = new System.Collections.Generic.List<Entry<K, V>>();
            for (int i = 0; i < tableSize; i++) hashTable.Add(null);

            for (int i = 0; i < prevHashTable.Count; i++)
            {
                if (prevHashTable[i] != null && !prevHashTable[i].isCleared())
                    add(prevHashTable[i].getKey(), prevHashTable[i].getValue());
            }
        }

        public HashMap()
        {
            numberOfEntries = 0;
            tableSize = 16;
            loadFactor = 0;
            hashTable = new System.Collections.Generic.List<Entry<K, V>>();
            for (int i = 0; i < tableSize; i++)
            {
                hashTable.Add(null);
            }
        }
        
        public V this[K key]
        {
            get
            {
                return get(key);
            }
        }

        public int searchForEntry(K key)
        {
            int index;
            int homePosition = key.GetHashCode() % tableSize;
            for (int i = 0; i < tableSize; i++)
            {
                index = (homePosition + i * ((((homePosition / tableSize) % (tableSize / 2)) * 2) + 1)) % tableSize;
                index = Math.Abs(index);
                if (hashTable[index] == null) return -1;
                else if (hashTable[index].isCleared()) continue;
                else if (key.GetHashCode() == hashTable[index].getKey().GetHashCode()) return index;
            }
            return -1;
        }

        public void add(K key, V value)
        {
            int positionInfo = searchForEntry(key);
            if (positionInfo == -1)
            {
                int homePosition = key.GetHashCode() % tableSize;
                int index;
                for (int i = 0; i < tableSize; i++)
                {
                    index = (homePosition + i * ((((homePosition / tableSize) % (tableSize / 2)) * 2) + 1)) % tableSize;
                    index = Math.Abs(index);
                    if (hashTable[index] == null || hashTable[index].isCleared())
                    {
                        hashTable[index] = new Entry<K, V>(key, value);
                        numberOfEntries++;
                        checkForRehashing();
                        return;
                    }
                }
                Console.WriteLine("Unable to put entry. Memory Full.");
            }
            else
            {
                hashTable[positionInfo].setValue(value);
            }
        }

        public void remove(K key)
        {
            int positionInfo = searchForEntry(key);
            if (positionInfo != -1)
            {
                hashTable[positionInfo].setCleared(true);
                numberOfEntries--;
            }
        }

        public V get(K key)
        {
            int positionInfo = searchForEntry(key);
            if (positionInfo != -1) return hashTable[positionInfo].getValue();

            return default(V);
        }

        public void print()
        {
            for (int i = 0; i < hashTable.Count; i++)
            {
                if (hashTable[i] != null && !hashTable[i].isCleared()) Console.WriteLine("Key: " + hashTable[i].getKey() + "\tValue: " + hashTable[i].getValue());
            }
        }

        public System.Collections.Generic.List<K> getKeyList()
        {
            var keys = new System.Collections.Generic.List<K>();

            for (int i = 0; i < hashTable.Count; i++)
            {
                if (hashTable[i] != null && !hashTable[i].isCleared()) keys.Add(hashTable[i].getKey());
            }
            return keys;
        }

        public System.Collections.Generic.List<V> getValueList()
        {
            var values = new System.Collections.Generic.List<V>();

            for (int i = 0; i < hashTable.Count; i++)
            {
                if (hashTable[i] != null && !hashTable[i].isCleared()) values.Add(hashTable[i].getValue());
            }
            return values;
        }

        public bool containsKey(K key)
        {
            return (searchForEntry(key) != -1);
        }

        public bool containsValue(V value)
        {
            for (int i = 0; i < hashTable.Count; i++)
            {
                if (hashTable[i] != null && !hashTable[i].isCleared())
                    if (hashTable[i].getValue().Equals(value)) return true;
            }
            return false;
        }

        public void clear()
        {
            numberOfEntries = 0;
            tableSize = 16;
            loadFactor = 0;
            hashTable = new System.Collections.Generic.List<Entry<K, V>>();
            for (int i = 0; i < tableSize; i++)
            {
                hashTable.Add(null);
            }
        }

        public int size()
        {
            return numberOfEntries;
        }

        public bool isEmpty()
        {
            return (this.size() == 0);
        }

    }

    class TreapNode<T> where T : IComparable
    {
	    public T myObj;
        public int priority;
        public TreapNode<T> myLeft;
        public TreapNode<T> myRight;
        
        public TreapNode(T data, int priority)
        {
            this.myObj = data;
            this.priority = priority;

            myLeft = null;
            myRight = null;
        }
    }

    class Treap<T> : AdsClassMin where T : IComparable
    {
        private int numElements;
        private TreapNode<T> root;
        private HashSet<int> hs;

        private System.Collections.Generic.List<T> items;

        private void getListInOrderT(TreapNode<T> r)
        {
            if (r == null) return;
            getListInOrderT(r.myLeft);
            items.Add(r.myObj);
            getListInOrderT(r.myRight);
        }

        private void getListPreOrderT(TreapNode<T> r)
        {
            if (r == null) { return; }
            items.Add(r.myObj);
            getListPreOrderT(r.myLeft);
            getListPreOrderT(r.myRight);
        }

        private void getListPostOrderT(TreapNode<T> r)
        {
            if (r == null) { return; }
            getListPostOrderT(r.myLeft);
            getListPostOrderT(r.myRight);
            items.Add(r.myObj);
        }

        private static void printInOrderT(TreapNode<T> r)
        {
            if (r == null) return;
            printInOrderT(r.myLeft);
            Console.WriteLine(r.myObj);
            printInOrderT(r.myRight);
        }

        private static void printPreOrderT(TreapNode<T> r)
        {
            if (r == null) return;
            Console.WriteLine(r.myObj);
            printPreOrderT(r.myLeft);
            printPreOrderT(r.myRight);
        }

        private static void printPostOrderT(TreapNode<T> r)
        {
            if (r == null) return;
            printPostOrderT(r.myLeft);
            printPostOrderT(r.myRight);
            Console.WriteLine(r.myObj);
        }

        private static void invertTree(TreapNode<T> r)
        {
            if (r == null) return;
            TreapNode<T> temp = r.myLeft;
            r.myLeft = r.myRight;
            r.myRight = temp;
            invertTree(r.myLeft);
            invertTree(r.myRight);
        }

        private TreapNode<T> rightRotation(TreapNode<T> workingNode)
        {
            TreapNode<T> oldRoot = workingNode;
            TreapNode<T> rtLChld = workingNode.myLeft;
            TreapNode<T> rtLChldRChld = rtLChld.myRight;

            workingNode = rtLChld;
            workingNode.myRight = oldRoot;
            oldRoot.myLeft = rtLChldRChld;

            return workingNode;
        }

        private TreapNode<T> leftRotation(TreapNode<T> workingNode)
        {
            TreapNode<T> oldRoot = workingNode;
            TreapNode<T> rtRChld = workingNode.myRight;
            TreapNode<T> rtRChldLChld = rtRChld.myLeft;

            workingNode = rtRChld;
            workingNode.myLeft = oldRoot;
            oldRoot.myRight = rtRChldLChld;

            return workingNode;
        }

        private TreapNode<T> insert(TreapNode<T> workingNode, T data, int priority)
        {
            if (workingNode == null)
            {
                ++numElements;
                hs.add(priority);
                return new TreapNode<T>(data, priority);
            }
            else if (data.CompareTo(workingNode.myObj) < 0)
            {
                workingNode.myLeft = insert(workingNode.myLeft, data, priority);

                if (workingNode.myLeft.priority < workingNode.priority)
                {
                    workingNode = rightRotation(workingNode);
                }
            }
            else if (data.CompareTo(workingNode.myObj) > 0)
            {
                workingNode.myRight = insert(workingNode.myRight, data, priority);
                if (workingNode.myRight.priority < workingNode.priority)
                {
                    workingNode = leftRotation(workingNode);
                }
            }
            else
            {
                ;
            }

            return workingNode;
        }

        private TreapNode<T> delete(TreapNode<T> workingNode, T data)
        {
            if (workingNode == null)
            {
                return null;
            }
            else if (data.CompareTo(workingNode.myObj) < 0)
            {
                workingNode.myLeft = delete(workingNode.myLeft, data);
            }
            else if (data.CompareTo(workingNode.myObj) > 0)
            {
                workingNode.myRight = delete(workingNode.myRight, data);
            }
            else
            {
                if (workingNode.myLeft == null && workingNode.myRight == null)
                {
                    --numElements;
                    hs.remove(workingNode.priority);
                    return null;
                }
                else if (workingNode.myRight == null)
                {
                    workingNode = rightRotation(workingNode);
                    workingNode.myRight = delete(workingNode.myRight, data);
                }
                else if (workingNode.myLeft == null)
                {
                    workingNode = leftRotation(workingNode);
                    workingNode.myLeft = delete(workingNode.myLeft, data);
                }
                else
                {
                    if (workingNode.myLeft.priority < workingNode.myRight.priority)
                    {
                        workingNode = rightRotation(workingNode);
                        workingNode.myRight = delete(workingNode.myRight, data);
                    }
                    else
                    {
                        workingNode = leftRotation(workingNode);
                        workingNode.myLeft = delete(workingNode.myLeft, data);
                    }
                }
            }
            return workingNode;
        }

        private bool contains(TreapNode<T> root, T data)
        {
            if (root == null)
            {
                return false;
            }
            else if (data.CompareTo(root.myObj) < 0)
            {
                return contains(root.myLeft, data);
            }
            else if (data.CompareTo(root.myObj) > 0)
            {
                return contains(root.myRight, data);
            }
            else
            {
                return true;
            }
        }

        private int getHeight(TreapNode<T> workingNode, int currHeight)
        {
            if (workingNode == null) return currHeight;

            currHeight += 1;

            int leftHeight = getHeight(workingNode.myLeft, currHeight);
            int rightHeight = getHeight(workingNode.myRight, currHeight);

            return (leftHeight > rightHeight ? leftHeight : rightHeight);
        }

        private int maxWidth = 0;

        private int getWidth(TreapNode<T> r)
        {
            Queue<TreapNode<T>> q = new Queue<TreapNode<T>>();
            int levelNodes = 0;
            if (r == null) return 0;
            q.enqueue(r);

            while (!q.isEmpty())
            {
                levelNodes = q.size();

                if (levelNodes > maxWidth)
                {
                    maxWidth = levelNodes;
                }

                while (levelNodes > 0)
                {
                    TreapNode<T> n = q.dequeue();
                    if (n.myLeft != null) q.enqueue(n.myLeft);
                    if (n.myRight != null) q.enqueue(n.myRight);
                    levelNodes--;
                }
            }

            return maxWidth;
        }

        public Treap()
        {
            hs = new HashSet<int>();
            numElements = 0;
            root = null;
            items = new System.Collections.Generic.List<T>();
        }

        public void add(T data)
        {
            Random rand = new Random();
            int tempPriority = (int)(rand.Next() * int.MaxValue);
            tempPriority += 1;
            while (hs.contains(tempPriority))
            {
                tempPriority = (int)(rand.Next() * int.MaxValue);
                tempPriority += 1;
            }

            root = insert(root, data, tempPriority);
        }

        public void add(T data, int priority)
        {
            if (hs.contains(priority)) return;

            root = insert(root, data, priority);
        }

        public void remove(T data)
        {
            root = delete(root, data);
        }


        public void removeAll(T t)
        {
            while (this.contains(t))
            {
                remove(t);
            }
        }

        public int width()
        {
            int w = getWidth(root);
            maxWidth = 0;
            return w;
        }
        
        public int height()
        {
            return getHeight(root, -1);
        }

        public void invert()
        {
            invertTree(root);
        }

        public void printPreOrder()
        {
            printPreOrderT(root);
        }

        public void printInOrder()
        {
            printInOrderT(root);
        }

        public void printPostOrder()
        {
            printPreOrderT(root);
        }

        public System.Collections.Generic.List<T> getListPreOrder()
        {
            items.Clear();
            getListPreOrderT(root);
            return items;
        }

        public System.Collections.Generic.List<T> getListInOrder()
        {
            items.Clear();
            getListInOrderT(root);
            return items;
        }

        public System.Collections.Generic.List<T> getListPostOrder()
        {
            items.Clear();
            getListPostOrderT(root);
            return items;
        }

        public bool contains(T data)
        {
            return contains(root, data);
        }

        public void clear()
        {
            hs.clear();
            numElements = 0;
            root = null;
            items.Clear();
        }

        public int size()
        {
            return numElements;
        }

        public bool isEmpty()
        {
            return (this.size() == 0);
        }
    }

    class HSNode<T> : IComparable<T> where T : IComparable<T>
    {
        private enum State
        {
            EMPTY,
            IN_USE,
            DELETED
        }

        private T element;
        private State state = State.EMPTY;

        public HSNode(T o)
        {
            setElement(o);
        }

        public int CompareTo(T other)
        {
            int cmpTo = element.CompareTo(other);
            return state == State.IN_USE ? cmpTo : -1;
        }

        public bool equals(T other)
        {
            if (state != State.IN_USE)
                return false;

            return this.CompareTo(other) == 0;
        }

        public bool isEmpty()
        {
            return state == State.EMPTY;
        }

        public bool isInUse()
        {
            return state == State.IN_USE;
        }

        public T getElement()
        {
            return element;
        }

        public void setElement(T element)
        {
            state = State.IN_USE;
            this.element = element;
        }

        public void remove()
        {
            state = State.DELETED;
        }
    }

    class HashSet<T> : AdsClass<T> where T : IComparable<T>
    {

        private bool insert(int index, T element)
        {
            if (element == null)
                return false;

            if (elements[index] == null)
            {
                elements[index] = new HSNode<T>(element);
                return true;
            }

            if (elements[index].isInUse())
            {
                if (elements[index].equals(element))
                    return false;

                return doubleHash(index, element);
            }

            elements[index].setElement(element);
            return true;

        }

        private bool doubleHash(int index, T element)
        {

            int loopCount = 1;
            bool spaceFound = false;

            while (!spaceFound)
            {
                int newHash = getDoubleHashVal(index, loopCount);
                if (elements[newHash] == null)
                {
                    elements[newHash] = new HSNode<T>(element);
                    return true;
                }

                if (elements[newHash].equals(element))
                    return false;

                if (!elements[index].isInUse())
                {
                    elements[index].setElement(element);
                    return true;
                }

                loopCount++;

            }

            return false;
        }

        private int getDoubleHashVal(int hash, int loopCount)
        {
            loopCount = loopCount % elements.Length;
            return Math.Abs((hash + loopCount * secondaryHash(hash) % elements.Length) % elements.Length);

        }

        private int secondaryHash(int hash)
        {
            return (7919 - (hash % 7919)) % elements.Length;
        }
        
        private int hashCode(object o)
        {
            return Math.Abs(o.GetHashCode()) % elements.Length;
        }

        private void extendElementsArray()
        {
            HSNode<T>[] oldArray = elements;
            elements = new HSNode<T>[elements.Length * 2 + 1];


            for (int i = 0; i < oldArray.Length; i++)
            {
                if (oldArray[i] != null && oldArray[i].isInUse())
                    insert(hashCode(oldArray[i].getElement()), oldArray[i].getElement());
            }
        }

        private const int defaultSize = 100;
        private HSNode<T>[] elements;
        private int noElements = 0;

        public HashSet()
        {
            elements = new HSNode<T>[defaultSize];
        }

        public HashSet(int initialSize)
        {
            elements = new HSNode<T>[initialSize];
        }

        public void add(T t)
        {
            if (noElements >= elements.Length - 1) extendElementsArray();

            bool inserted = insert(hashCode(t), t);
            if (inserted) noElements++;
        }

        public void remove(T t)
        {
            int hash = hashCode(t);

            if (elements[hash] == null) return;
            
            if (elements[hash].equals(t))
            {
                elements[hash].remove();
                noElements--;
                return;
            }

            bool stop = false;
            int loopCount = 1;
            while (!stop)
            {
                int newHash = getDoubleHashVal(hash, loopCount);

                if (elements[newHash] == null || elements[newHash].isEmpty()) return;

                if (elements[newHash].equals(t))
                {
                    elements[newHash].remove();
                    noElements--;
                    return;
                }
                loopCount++;
            }
        }

        public void print()
        {
            for (int i = 0; i < elements.Length; i++)
            {
                if (elements[i] != null && elements[i].isInUse())
                    Console.WriteLine(elements[i].getElement());
            }
        }

        public System.Collections.Generic.List<T> getList()
        {
            var items = new System.Collections.Generic.List<T>();
            for (int i = 0; i < elements.Length; i++)
            {
                if (elements[i] != null && elements[i].isInUse())
                    items.Add(elements[i].getElement());
            }

            return items;
        }

        public bool contains(T t)
        {
            int hash = hashCode(t);
            if (elements[hash] == null)
                return false;


            if (elements[hash].equals(t))
            {
                return true;
            }

            bool stop = false;
            int loopCount = 1;
            while (!stop)
            {
                int newHash = getDoubleHashVal(hash, loopCount);

                if (elements[newHash] == null || elements[newHash].isEmpty())
                    return false;

                if (elements[newHash].equals(t))
                {
                    return true;
                }
                loopCount++;
            }

            return false;

        }

        public void clear()
        {
            elements = new HSNode<T>[defaultSize];
            noElements = 0;
        }
        public int size()
        {
            return noElements;
        }
        
        public bool isEmpty()
        {
            return noElements == 0;
        }
    }
}