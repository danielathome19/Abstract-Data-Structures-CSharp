﻿/*
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
 *
 * To do:
 *  -Circular Queue
 *  -Circular Linked List
 *  -SortedMap
 *  -Map
 *  -HashMap (Dictionary)
 *  -Heap
 *  -Skip List
 *  -Bitset
 *  -Undirected Graph
 *  -Directed Graph
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

    interface AdsClassMin<T>
    {
        bool contains(T t);
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

    class BinaryTree<T> : AdsClassMin<T> where T : IComparable
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
            while (numCounter(root, t) != 0)
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
}
