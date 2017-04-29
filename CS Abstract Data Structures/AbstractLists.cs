﻿/*
 * Author:  Daniel Szelogowski
 * Created: 4/7/17
 * Purpose: A collection of data structures written in C# using generics.
 * 
 * Current implemented:
 *  -Linked List
 *  -Doubly Linked List
 *  -Stack
 *  -Queue
 *  -Sorted Set
 *  -Set
 *  -Multiset (Sorted List)
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
 *  -TreeSet
 *  -Graph (Undirected) (Adjacency List)
 *  -Fenwick Tree
 *  -Trie
 *  -Union Find (Disjointed Set)
 *
 * To do:
 *  -Multimap
 *  -Heap (Binary Tree)
 *  -Heap
 *  -Skip List
 *  -Sorted List (Linked List)
 *  -Unrolled Linked List
 *  -Bitset
 *  -Bitfield
 *  -Queap
 *  -Quad Tree
 *  -Splay Tree
 *  -Segment Tree
 *  -2 3 Tree (2-3)
 *  -2 4 Tree (2-3-4)
 *  -AVL Tree
 *  -B-Tree
 *  -B+Tree
 *  -Ternary Tree
 *  -Red Black Tree
 *  -Directed Graph
 *  -Incidence Matrix
 *  -Adjacency Matrix
 * 
 **************************************************************************/

using System;
using System.Linq;

namespace Adscol
{
    interface AdsClass<T>
    {
        //TODO: void removeAll(T t);, implement IEnumerable, change remove(int) to removeAt, make remove(T), int indexOf
        void print();
        ArrayList<T> getList();
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
        private Node<T> myFront;

        public LinkedList()
        {
            myList = null;
            myLast = null;
            myFront = null;
        }

        public LinkedList(T t)
        {
            myList = new Node<T>(t);
            myLast = myList;
            myFront = myList;
        }

        public T this[int index]
        {
            get { 
                return get(index);
            }
            set
            {
                set(index, value);
            }
        }

        public void add(T t)
        {
            Node<T> temp = new Node<T>(t);
            if (myList == null)
            {
                myList = temp;
                myLast = temp;
                myFront = temp;
            } else
            {
                myFront.myNext = temp;
                myFront = myFront.myNext;
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
                this.add(t);
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

        public ArrayList<T> getList()
        {
            var items = new ArrayList<T>();

            for (int i = 0; i < this.size(); i++)
            {
                items.add(this.get(i));
            }
            return items;
        }

        public bool contains(T t)
        {
            var items = this.getList();

            for (int i = 0; i < items.size(); i++)
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
        //TODO: add remove(index), add(index), set(index)
        private Node<T> myList;

        public DoublyLinkedList()
        {
            myList = null;
        }

        public DoublyLinkedList(T t)
        {
            this.add(t);
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
        
        public ArrayList<T> getList()
        {
            var items = new ArrayList<T>();

            for (int i = 0; i < this.size(); i++)
            {
                items.add(this.get(i));
            }
            return items;
        }

        public bool contains(T t)
        {
            var items = getList();

            for (int i = 0; i < items.size(); i++)
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

    class Stack<T> : AdsClass<T>
    {
        private ArrayList<T> myList;

        public Stack()
        {
            myList = new ArrayList<T>();
        }

        public Stack(T t) : this()
        {
            myList.add(t);
        }

        public void push(T t)
        {
            myList.add(t);
        }

        public T pop()
        {
            if (myList.size() == 0) return default(T);
            T temp = myList[myList.size() - 1];
            myList.remove(myList.size() - 1);
            return temp;
        }

        public T peek()
        {
            return myList[myList.size() - 1];
        }

        public void print()
        {
            foreach (var item in myList)
            {
                Console.WriteLine(item);
            }
        }

        public ArrayList<T> getList()
        {
            return myList;
        }

        public bool contains(T t)
        {
            return myList.contains(t);
        }

        public void clear()
        {
            myList.clear();
        }

        public int size()
        {
            return myList.size();
        }

        public bool isEmpty()
        {
            return (this.size() == 0);
        }
    }

    class Queue<T> : AdsClass<T>
    {
        private ArrayList<T> myList;

        public Queue()
        {
            myList = new ArrayList<T>();
        }

        public Queue(T t) : this()
        {
            myList.add(t);
        }

        public void enqueue(T t)
        {
            myList.add(t);
        }

        public T dequeue()
        {
            if (myList.size() == 0) return default(T);
            T temp = myList[0];
            myList.remove(0);
            return temp;
        }

        public T peek()
        {
            if (myList.size() == 0) return default(T);
            return myList[0];
        }

        public void print()
        {
            foreach (var item in myList)
            {
                Console.WriteLine(item);
            }
        }

        public ArrayList<T> getList()
        {
            return myList;
        }

        public bool contains(T t)
        {
            return myList.contains(t);
        }

        public void clear()
        {
            myList.clear();
        }

        public int size()
        {
            return myList.size();
        }

        public bool isEmpty()
        {
            return (this.size() == 0);
        }
    }

    class SortedSet<T> : AdsClass<T> where T : IComparable
    {
        private ArrayList<T> myList;
        
        private void addSorted(T t)
        {
            for (int i = 0; i < myList.size(); i++)
            {
                if (t.CompareTo(myList[i]) == -1)
                {
                    myList.add(i, t);
                    return;
                }
            }
            myList.add(t);
        }

        public SortedSet()
        {
            myList = new ArrayList<T>();
        }

        public SortedSet(T t) : this()
        {
            myList.add(t);
        }

        public void add(T t)
        {
            if (!this.contains(t)) this.addSorted(t);
        }

        public void remove(int index)
        {
            myList.remove(index);
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

        public ArrayList<T> getList()
        {
            return myList;
        }

        public bool contains(T t)
        {
            return myList.contains(t);
        }

        public void clear()
        {
            myList.clear();
        }

        public int size()
        {
            return myList.size();
        }

        public bool isEmpty()
        {
            return (this.size() == 0);
        }

    }

    class Set<T> : AdsClass<T>
    {
        private ArrayList<T> myList;

        public Set()
        {
            myList = new ArrayList<T>();
        }

        public Set(T t) : this()
        {
            myList.add(t);
        }

        public void add(T t)
        {
            if (!this.contains(t)) myList.add(t);
        }

        public void remove(int index)
        {
            myList.remove(index);
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

        public ArrayList<T> getList()
        {
            return myList;
        }
        
        public bool contains(T t)
        {
            return myList.contains(t);
        }

        public void clear()
        {
            myList.clear();
        }

        public int size()
        {
            return myList.size();
        }

        public bool isEmpty()
        {
            return (this.size() == 0);
        }

    }

    class Multiset<T> : AdsClass<T> where T : IComparable 
    {
        private ArrayList<T> myList;

        private void addSorted(T t)
        {
            for (int i = 0; i < myList.size(); i++)
            {
                if (t.CompareTo(myList[i]) == -1)
                {
                    myList.add(i, t);
                    return;
                }
            }
            myList.add(t);
        }

        public Multiset()
        {
            myList = new ArrayList<T>();
        }

        public Multiset(T t) : this()
        {
            myList.add(t);
        }

        public void add(T t)
        {
            this.addSorted(t);
        }

        public void remove(int index)
        {
            myList.remove(index);
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

        public ArrayList<T> getList()
        {
            return myList;
        }

        public Adscol.Set<T> getSet()
        {
            var items = new Adscol.Set<T>();

            foreach (T item in myList)
            {
                items.add(item);
            }

            return items;
        }

        public bool contains(T t)
        {
            return myList.contains(t);
        }

        public void clear()
        {
            myList.clear();
        }

        public int size()
        {
            return myList.size();
        }

        public bool isEmpty()
        {
            return (this.size() == 0);
        }

    }

    class Bag<T> : AdsClass<T>
    {
        private ArrayList<T> myList;

        public Bag()
        {
            myList = new ArrayList<T>();
        }

        public Bag(T t) : this()
        {
            myList.add(t);
        }

        public void add(T t)
        {
            myList.add(t);
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

        public ArrayList<T> getList()
        {
            return myList;
        }

        public bool contains(T t)
        {
            return myList.contains(t);
        }

        public void clear()
        {
            myList.clear();
        }

        public int size()
        {
            return myList.size();
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
        private ArrayList<T> items;

        private void getListInOrderT(TreeNode<T> r)
        {
            if (r == null) return;
            getListInOrderT(r.myLeft);
            items.add(r.myObj);
            getListInOrderT(r.myRight);
        }

        private void getListPreOrderT(TreeNode<T> r)
        {
            if (r == null) { return; }
            items.add(r.myObj);
            getListPreOrderT(r.myLeft);
            getListPreOrderT(r.myRight);
        }

        private void getListPostOrderT(TreeNode<T> r)
        {
            if (r == null) { return; }
            getListPostOrderT(r.myLeft);
            getListPostOrderT(r.myRight);
            items.add(r.myObj);
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
            items = new ArrayList<T>();
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

        public ArrayList<T> getListPreOrder()
        {
            items.clear();
            getListPreOrderT(root);
            return items;
        }

        public ArrayList<T> getListInOrder()
        {
            items.clear();
            getListInOrderT(root);
            return items;
        }

        public ArrayList<T> getListPostOrder()
        {
            items.clear();
            getListPostOrderT(root);
            return items;
        }

        public bool contains(T t)
        {
            var items = this.getListInOrder();

            for (int i = 0; i < items.size(); i++)
            {
                if (items[i].Equals(t)) return true;
            }
            return false;
        }

        public void clear()
        {
            root = null;
            items.clear();
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

        public override string ToString()
        {
            return "Priority: " + this.priority + " Data: " + this.myObj;
        }
    }

    class PriorityQueue<T> : AdsClass<T>
    {
        private ArrayList<PQNode<T>> myList;

        public PriorityQueue()
        {
            myList = new ArrayList<PQNode<T>>();
        }

        public void enqueue(T t, int priority)
        {
            myList.add(new PQNode<T>(priority, t));

            myList.sort();
        }

        public T dequeue()
        {
            if (myList[0] == null) return default(T);
            T temp = myList[0].myObj;
            myList.remove(0);
            return temp;
        }

        public T peek()
        {
            if (myList[0] == null) return default(T);
            return myList[0].myObj;
        }

        public void print()
        {
            foreach (PQNode<T> item in myList)
            {
                Console.WriteLine(item.ToString());
            }
        }

        public ArrayList<T> getList()
        {
            var items = new ArrayList<T>();

            foreach (PQNode<T> item in myList)
            {
                items.add(item.myObj);
            }
            return items;
        }

        public bool contains(T t)
        {
            var items = this.getList();
            return items.contains(t);
        }

        public void clear()
        {
            myList.clear();
        }

        public int size()
        {
            return myList.size();
        }

        public bool isEmpty()
        {
            return (this.size() == 0);
        }

    }

    class ArrayList<T> : AdsClass<T>, System.Collections.IEnumerable
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

        public void remove(T t)
        {
            int indx = this.indexOf(t);
            this.remove(indx);
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

        public System.Collections.Generic.List<T> getCollectionsList()
        {
            var items = new System.Collections.Generic.List<T>();

            for (int i = 0; i < _size; i++)
            {
                items.Add(array[i]);
            }
            return items;
        }

        public ArrayList<T> getList()
        {
            return this;
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


        public int indexOf(T t)
        {
            for (int i = 0; i < _size; i++)
            {
                if (array[i].Equals(t)) return i;
            }
            return -1;
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

        public void sort()
        {
            array = array.OrderBy(i => i == null).ThenBy(i => i).ToArray();
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

        private System.Collections.Generic.IEnumerable<T> itemsEnumerable()
        {
            for (int i = 0; i < _size; i++)
            {
                if (array[i] != null) yield return array[i];
            }
        }

        private System.Collections.Generic.IEnumerator<T> getEnumerator()
        {
            return itemsEnumerable().GetEnumerator();
        }

        public System.Collections.IEnumerator GetEnumerator()
        {
            return getEnumerator();
        }

        public struct Enumerator : System.Collections.Generic.IEnumerator<T>
        {
            private ArrayList<T> list;
            private int index;
            private T current;

            internal Enumerator(ArrayList<T> list)
            {
                this.list = list;
                index = 0;
                current = default(T);
            }

            public void Dispose()
            {
            }

            public bool MoveNext()
            {

                ArrayList<T> localList = list;

                if (((uint)index < (uint)localList._size))
                {
                    current = localList.array[index];
                    index++;
                    return true;
                }
                return MoveNextRare();
            }

            private bool MoveNextRare()
            {
                index = list._size + 1;
                current = default(T);
                return false;
            }

            public T Current
            {
                get
                {
                    return current;
                }
            }

            Object System.Collections.IEnumerator.Current
            {
                get
                {
                    if (index == 0 || index == list._size + 1)
                    {
                        throw new Exception("Invalid Operation");
                    }
                    return Current;
                }
            }

            void System.Collections.IEnumerator.Reset()
            {
                index = 0;
                current = default(T);
            }

        }
    }

    class Deque<T> : AdsClass<T>
    {
        private ArrayList<T> myList;

        public Deque()
        {
            myList = new ArrayList<T>();
        }

        public void pushFront(T t)
        {
            myList.add(0, t);
        }

        public void pushBack(T t)
        {
            myList.add(t);
        }

        public T popFront()
        {
            T obj = myList[0];
            myList.remove(0);
            return obj;
        }

        public T popBack()
        {
            T obj = myList[myList.size() - 1];
            myList.remove(myList.size() - 1);
            return obj;
        }

        public T peekFront()
        {
            return myList[0];
        }

        public T peekBack()
        {
            return myList[myList.size() - 1];
        }

        public void print()
        {
            foreach (var item in myList)
            {
                Console.WriteLine(item);
            }
        }

        public ArrayList<T> getList()
        {
            return myList;
        }

        public bool contains(T t)
        {
            return myList.contains(t);
        }

        public void clear()
        {
            myList.clear();
        }

        public int size()
        {
            return myList.size();
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

        public ArrayList<T> getList()
        {
            var items = new ArrayList<T>();
            
            int tempLoc = 0;
            for (int i = 0; i < myCurrentSize; i++)
            {
                tempLoc = (tempLoc + 1) % myMaxSize;
                items.add(myBuffer[tempLoc]);
            }

            return items;
        }

        public bool contains(T t)
        {
            var items = this.getList();

            for (int i = 0; i < items.size(); i++)
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

        public ArrayList<T> getList()
        {
            var items = new ArrayList<T>();

            Node<T> myLast = myList;

            if (myList != null)
            {
                while (myLast.myNext != myList)
                {
                    items.add(myLast.myObj);
                    myLast = myLast.myNext;
                }
                items.add(myLast.myObj);
            }
            return items;
        }

        public bool contains(T t)
        {
            var items = this.getList();

            for (int i = 0; i < items.size(); i++)
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
        private ArrayList<Entry<K, V>> myMap;

        private int indexOf(K key)
        {
            for (int i = 0; i < myMap.size(); i++)
            {
                if (myMap[i].getKey().Equals(key)) return i;
            }
            return -1;
        }

        public SortedMap()
        {
            myMap = new ArrayList<Entry<K, V>>();
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
                myMap.add(temp);
                myMap.sort();
            }
        }

        public void remove(K key)
        {
            if (containsKey(key))
            {
                myMap.remove(this.indexOf(key));
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
            for (int i = 0; i < myMap.size(); i++)
            {
                Console.WriteLine("Key: " + myMap[i].getKey() + "\tValue: " + myMap[i].getValue());
            }
        }

        public ArrayList<K> getKeyList()
        {
            var keys = new ArrayList<K>();

            for (int i = 0; i < myMap.size(); i++)
            {
                keys.add(myMap[i].getKey());
            }
            return keys;
        }

        public ArrayList<V> getValueList()
        {
            var values = new ArrayList<V>();

            for (int i = 0; i < myMap.size(); i++)
            {
                values.add(myMap[i].getValue());
            }
            return values;
        }

        public bool containsKey(K key)
        {
            for (int i = 0; i < myMap.size(); i++)
            {
                if (myMap[i].getKey().Equals(key)) return true;
            }
            return false;
        }

        public bool containsValue(V value)
        {
            for (int i = 0; i < myMap.size(); i++)
            {
                if (myMap[i].getValue().Equals(value)) return true;
            }
            return false;
        }

        public void clear()
        {
            myMap.clear();
        }

        public int size()
        {
            return myMap.size();
        }

        public bool isEmpty()
        {
            return (this.size() == 0);
        }
    }
    
    class Map<K, V> : AdsClassMin where K : IComparable
    {
        private Set<Entry<K, V>> myMap;

        private int indexOf(K key)
        {
            for (int i = 0; i < myMap.size(); i++)
            {
                if (myMap.get(i).getKey().Equals(key)) return i;
            }
            return -1;
        }

        public Map()
        {
            myMap = new Set<Entry<K, V>>();
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
                myMap.add(temp);
            }
        }

        public void remove(K key)
        {
            if (containsKey(key))
            {
                myMap.remove(this.indexOf(key));
            }
        }

        public V get(K key)
        {
            if (containsKey(key))
            {
                return myMap.get(this.indexOf(key)).getValue();
            }
            return default(V);
        }

        public void print()
        {
            for (int i = 0; i < myMap.size(); i++)
            {
                Console.WriteLine("Key: " + myMap.get(i).getKey() + "\tValue: " + myMap.get(i).getValue());
            }
        }

        public Set<Entry<K, V>> entrySet()
        {
            return myMap;
        }

        public ArrayList<K> getKeyList()
        {
            var keys = new ArrayList<K>();

            for (int i = 0; i < myMap.size(); i++)
            {
                keys.add(myMap.get(i).getKey());
            }
            return keys;
        }

        public ArrayList<V> getValueList()
        {
            var values = new ArrayList<V>();

            for (int i = 0; i < myMap.size(); i++)
            {
                values.add(myMap.get(i).getValue());
            }
            return values;
        }

        public bool containsKey(K key)
        {
            for (int i = 0; i < myMap.size(); i++)
            {
                if (myMap.get(i).getKey().Equals(key)) return true;
            }
            return false;
        }

        public bool containsValue(V value)
        {
            for (int i = 0; i < myMap.size(); i++)
            {
                if (myMap.get(i).getValue().Equals(value)) return true;
            }
            return false;
        }

        public void clear()
        {
            myMap.clear();
        }

        public int size()
        {
            return myMap.size();
        }

        public bool isEmpty()
        {
            return (this.size() == 0);
        }
    }

    class HashMap<K, V> : AdsClassMin where K : IComparable
    {
        private ArrayList<Entry<K, V>> hashTable;

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
            hashTable = new ArrayList<Entry<K, V>>();
            for (int i = 0; i < tableSize; i++) hashTable.add(null);

            for (int i = 0; i < prevHashTable.size(); i++)
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
            hashTable = new ArrayList<Entry<K, V>>();
            for (int i = 0; i < tableSize; i++)
            {
                hashTable.add(null);
            }
        }
        
        public V this[K key]
        {
            get { 
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
            for (int i = 0; i < hashTable.size(); i++)
            {
                if (hashTable[i] != null && !hashTable[i].isCleared()) Console.WriteLine("Key: " + hashTable[i].getKey() + "\tValue: " + hashTable[i].getValue());
            }
        }

        public ArrayList<Entry<K, V>> getList()
        {
            var items = new ArrayList<Entry<K, V>>();

            for (int i = 0; i < hashTable.size(); i++)
            {
                if (hashTable[i] != null && !hashTable[i].isCleared()) items.add(hashTable[i]);
            }
            return items;
        }

        public ArrayList<K> getKeyList()
        {
            var keys = new ArrayList<K>();

            for (int i = 0; i < hashTable.size(); i++)
            {
                if (hashTable[i] != null && !hashTable[i].isCleared()) keys.add(hashTable[i].getKey());
            }
            return keys;
        }

        public ArrayList<V> getValueList()
        {
            var values = new ArrayList<V>();

            for (int i = 0; i < hashTable.size(); i++)
            {
                if (hashTable[i] != null && !hashTable[i].isCleared()) values.add(hashTable[i].getValue());
            }
            return values;
        }

        public bool containsKey(K key)
        {
            return (searchForEntry(key) != -1);
        }

        public bool containsValue(V value)
        {
            for (int i = 0; i < hashTable.size(); i++)
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
            hashTable = new ArrayList<Entry<K, V>>();
            for (int i = 0; i < tableSize; i++)
            {
                hashTable.add(null);
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

        private ArrayList<T> items;

        private void getListInOrderT(TreapNode<T> r)
        {
            if (r == null) return;
            getListInOrderT(r.myLeft);
            items.add(r.myObj);
            getListInOrderT(r.myRight);
        }

        private void getListPreOrderT(TreapNode<T> r)
        {
            if (r == null) { return; }
            items.add(r.myObj);
            getListPreOrderT(r.myLeft);
            getListPreOrderT(r.myRight);
        }

        private void getListPostOrderT(TreapNode<T> r)
        {
            if (r == null) { return; }
            getListPostOrderT(r.myLeft);
            getListPostOrderT(r.myRight);
            items.add(r.myObj);
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
            items = new ArrayList<T>();
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

        public ArrayList<T> getListPreOrder()
        {
            items.clear();
            getListPreOrderT(root);
            return items;
        }

        public ArrayList<T> getListInOrder()
        {
            items.clear();
            getListInOrderT(root);
            return items;
        }

        public ArrayList<T> getListPostOrder()
        {
            items.clear();
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
            items.clear();
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

        public ArrayList<T> getList()
        {
            var items = new ArrayList<T>();
            for (int i = 0; i < elements.Length; i++)
            {
                if (elements[i] != null && elements[i].isInUse())
                    items.add(elements[i].getElement());
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

    class TreeSet<T> : AdsClass<T> where T : IComparable
    {
        private BinaryTree<T> tree;

        public TreeSet()
        {
            tree = new BinaryTree<T>();
        }

        public TreeSet(T t) : this()
        {
            tree.add(t);
        }

        public void add(T t)
        {
            if (!tree.contains(t))
            {
                tree.add(t);
            }
        }

        public void remove(T t)
        {
            tree.remove(t);
        }

        public void print()
        {
            tree.printInOrder();
        }

        public ArrayList<T> getList()
        {
            return tree.getListInOrder();
        }

        public bool contains(T t)
        {
            return tree.contains(t);
        }

        public void clear()
        {
            tree.clear();
        }

        public int size()
        {
            return tree.size();
        }

        public bool isEmpty()
        {
            return (this.size() == 0);
        }
    }

    class GraphNode : IComparable<GraphNode>
    {
        private string id;
        private ArrayList<GraphNode> neighbors;

        public GraphNode(string id)
        {
            this.id = id;
            this.neighbors = new ArrayList<GraphNode>();
        }

        public string getId()
        {
            return this.id;
        }

        public void setId(string id)
        {
            this.id = id;
        }

        public bool hasNeighbor(GraphNode node)
        {
            return this.neighbors.contains(node);
        }

        public void addNeighbor(GraphNode node)
        {
            if (!this.neighbors.contains(node))
            {
                this.neighbors.add(node);
            }
        }

        public void removeNeighbor(GraphNode node)
        {
            this.neighbors.remove(node);
        }

        public void sortNeighbors()
        {
            this.neighbors.sort();
        }

        public ArrayList<GraphNode> getNeighbors()
        {
            return this.neighbors;
        }

        public override string ToString()
        {
            string neighborArray = "[ ";

            foreach (GraphNode x in neighbors)
            {
                neighborArray += x.id + " ";
            }
            neighborArray += "]";
            return "Id: " + this.id + "\tNeigbors: " + neighborArray;
        }

        public int CompareTo(GraphNode g)
        {
            return this.id.CompareTo(g.id);
        }
    }

    class Graph : AdsClassMin
    {
        private ArrayList<GraphNode> vertices;

        private GraphNode getVertex(string id)
        {
            foreach (GraphNode vertex in this.vertices)
            {
                if (vertex.getId() == id)
                {
                    return vertex;
                }
            }
            return null;
        }
        
        public Graph()
        {
            this.vertices = new ArrayList<GraphNode>();
        }

        public void addVertex(string id)
        {
            if (contains(id))
            {
                return;
            }

            this.vertices.add(new GraphNode(id));
        }

        public void addEdge(string idFrom, string idTo)
        {
            GraphNode vertexA = getVertex(idFrom);
            GraphNode vertexB = getVertex(idTo);

            if (vertexA == null || vertexB == null)
            {
                return;
            }

            vertexA.addNeighbor(vertexB);
            vertexB.addNeighbor(vertexA);
        }

        public void removeVertex(string id)
        {
            GraphNode vertex = getVertex(id);

            if (vertex == null)
            {
                return;
            }

            this.vertices.remove(this.vertices.indexOf(vertex));
        }
        
        public void removeEdge(string idFrom, string idTo)
        {
            GraphNode vertexA = getVertex(idFrom);
            GraphNode vertexB = getVertex(idTo);

            if (vertexA == null || vertexB == null)
            {
                return;
            }

            vertexA.removeNeighbor(vertexB);
            vertexB.removeNeighbor(vertexA);
        }

        public void print()
        {
            foreach (GraphNode x in vertices)
            {
                Console.WriteLine(x.ToString());
            }
        }
        
        public ArrayList<GraphNode> getList()
        {
            return vertices.getList();
        }

        public bool contains(string vertexId)
        {
            return getVertex(vertexId) != null;
        }

        public void clear()
        {
            vertices.clear();
        }

        public int size()
        {
            return vertices.size();
        }

        public bool isEmpty()
        {
            return (this.size() == 0);
        }

        public int distanceBetween(string idFrom, string idTo)
        {
            GraphNode vertexA = getVertex(idFrom);
            GraphNode vertexB = getVertex(idTo);

            if (vertexA == null || vertexB == null)
            {
                return 0;
            }

            ArrayList<GraphNode> visited = new ArrayList<GraphNode>();
            Queue<GraphNode> queue = new Queue<GraphNode>();

            int distance = 0;
            queue.enqueue(vertexA);

            while (!queue.isEmpty())
            {
                GraphNode current = queue.dequeue();
                visited.add(current);

                distance++;

                foreach (GraphNode currentNeighbor in current.getNeighbors())
                {
                    if (currentNeighbor == vertexB)
                    {
                        return distance;
                    }

                    if (!visited.contains(currentNeighbor))
                    {
                        queue.enqueue(currentNeighbor);
                    }
                }
            }

            return 0;
        }

        public bool pathExists(string idFrom, string idTo)
        {
            return distanceBetween(idFrom, idTo) > 0;
        }

        public void depthFirstSearch(string idFrom, string idTo)
        {
            GraphNode vertexA = getVertex(idFrom);
            GraphNode vertexB = getVertex(idTo);

            if (vertexA == null || vertexB == null)
            {
                return;
            }

            ArrayList<GraphNode> visited = new ArrayList<GraphNode>();
            Stack<GraphNode> stack = new Stack<GraphNode>();

            stack.push(vertexA);
            bool founder = false;

            while (!stack.isEmpty() && !founder)
            {
                GraphNode current = stack.pop();
                current.sortNeighbors();
                visited.add(current);

                if (current.getNeighbors().contains(vertexB))
                {
                    founder = true;
                }

                foreach (GraphNode currentNeighbor in current.getNeighbors())
                {
                    currentNeighbor.sortNeighbors();
                    if (currentNeighbor == vertexB)
                    {
                        founder = true;
                    }

                    foreach (GraphNode neighborFriends in currentNeighbor.getNeighbors()) {
                        if (!visited.contains(neighborFriends))
                        {
                            stack.push(neighborFriends);
                        }
                    }

                    if (!visited.contains(currentNeighbor))
                    {
                        stack.push(currentNeighbor);
                    }
                }
            }

            Console.Write("DFS: ");
            for (int i = 0; i < visited.size(); i++)
            {
                Console.Write(visited[i].getId() + "-->");
            }
            Console.WriteLine(idTo);
        }

        public void breadthFirstSearch(string idFrom, string idTo)
        {
            GraphNode vertexA = getVertex(idFrom);
            GraphNode vertexB = getVertex(idTo);

            if (vertexA == null || vertexB == null)
            {
                return;
            }

            ArrayList<GraphNode> visited = new ArrayList<GraphNode>();
            Queue<GraphNode> queue = new Queue<GraphNode>();

            queue.enqueue(vertexA);
            bool founder = false;

            while (!queue.isEmpty() && !founder)
            {
                GraphNode current = queue.dequeue();
                visited.add(current);

                foreach (GraphNode currentNeighbor in current.getNeighbors())
                {
                    if (currentNeighbor == vertexB)
                    {
                        founder = true;
                    }

                    if (!visited.contains(currentNeighbor))
                    {
                        queue.enqueue(currentNeighbor);
                    }
                }
            }

            Console.Write("BFS: ");
            for (int i = 0; i < visited.size(); i++)
            {
                Console.Write(visited[i].getId() + "-->");
            }
            Console.WriteLine(idTo);
        }
    }

    class FenwickTree : AdsClassMin
    {
        private int leastSignificantBit(int i)
        {
            return i & -i;
        }
        
        private long[] tree;
        private int originalSize;

        public FenwickTree(int size)
        {
            tree = new long[size + 1];
            originalSize = size;
        }
        
        public FenwickTree(long[] values)
        {

            if (values == null) throw new ArgumentNullException("Values array cannot be null!");

            this.tree = (long[])values.Clone();

            for (int i = 1; i < tree.Length; i++)
            {
                int j = i + leastSignificantBit(i);
                if (j < tree.Length) tree[j] += tree[i];
            }
            originalSize = values.Length;

        }
        
        public void add(int i, long k)
        {
            while (i < tree.Length)
            {
                tree[i] += k;
                i += leastSignificantBit(i);
            }
        }
        
        public void set(int i, long k)
        {
            long value = sum(i, i);
            add(i, k - value);
        }

        public void print()
        {
            foreach (long x in tree)
            {
                Console.WriteLine(x);
            }
        }

        public ArrayList<long> getList()
        {
            var items = new ArrayList<long>();

            foreach (long x in tree)
            {
                items.add(x);
            }

            return items;
        }

        public bool contains(long l)
        {
            return tree.Contains(l);
        }

        public void clear()
        {
            tree = new long[originalSize + 1];
        }

        public int size()
        {
            return tree.Length;
        }

        public bool isEmpty()
        {
            return (this.size() == 0);
        }

        public long prefixSum(int i)
        {
            long sum = 0L;
            while (i > 0)
            {
                sum += tree[i];
                i &= ~leastSignificantBit(i);
            }
            return sum;
        }

        public long sum(int i, int j)
        {
            if (j < i) throw new ArgumentOutOfRangeException("j must be greater than or equal to i");
            return prefixSum(j) - prefixSum(i - 1);
        }

    }

    class TrieNode
    {
        public char ch;
        public int count = 0;
        public bool isWordEnding = false;
        public HashMap<char, TrieNode> children = new HashMap<char, TrieNode>();

        public TrieNode(char ch)
        {
            this.ch = ch;
        }

        public void addChild(TrieNode node, char c)
        {
            children.add(c, node);
        }
    }

    class Trie
    {
        private void clear(TrieNode node)
        {

            if (node == null) return;

            foreach (char ch in node.children.getKeyList())
            {
                TrieNode nextNode = node.children.get(ch);
                clear(nextNode);
                nextNode = null;
            }

            node.children.clear();
            node.children = null;
        }
        
        private void findWordsThatStartWith(TrieNode node, string prefix, int currentLevel, string currentWord, ArrayList<string> lstResult)
        {
            if (currentLevel <= prefix.Length - 1)
            {
                TrieNode child = node.children.get(prefix[currentLevel]);
                if (child != null)
                {
                    findWordsThatStartWith(child, prefix, currentLevel + 1, currentWord + prefix[currentLevel], lstResult);
                }
            }
            else
            {
                var enumerator = node.children.getList().GetEnumerator();
                while (enumerator.MoveNext())
                {
                    string newWord = currentWord + ((Entry<char, TrieNode>)(enumerator.Current)).getKey();

                    if (((Entry<char, TrieNode>)(enumerator.Current)).getValue().isWordEnding)
                    {
                        lstResult.add(newWord);
                    }

                    findWordsThatStartWith(((Entry<char, TrieNode>)(enumerator.Current)).getValue(), prefix, currentLevel, newWord, lstResult);
                }
            }
        }

        private const char rootCharacter = '\0';
        private TrieNode root;

        public Trie()
        {
            root = new TrieNode(rootCharacter);

        }
        
        public void add(string key, int numInserts)
        {

            if (key == null) throw new ArgumentNullException();
            if (numInserts <= 0) throw new ArgumentOutOfRangeException("Number of inserts must be greater than zero");

            TrieNode node = root;
            
            for (int i = 0; i < key.Length; ++i)
            {
                char ch = key[i];
                TrieNode nextNode = node.children.get(ch);
                
                if (nextNode == null)
                {
                    nextNode = new TrieNode(ch);
                    node.addChild(nextNode, ch);
                }

                node = nextNode;
                node.count += numInserts;
            }

            if (node != root)
            {
                node.isWordEnding = true;
            }
        }
        
        public void add(string key)
        {
            add(key, 1);
        }
        
        public void remove(string key, int numDeletions)
        {
            if (!contains(key)) return;

            if (numDeletions <= 0) throw new ArgumentOutOfRangeException("Number of deletions must be positive");

            TrieNode node = root;
            for (int i = 0; i < key.Length; i++)
            {

                char ch = key[i];
                TrieNode curNode = node.children.get(ch);
                curNode.count -= numDeletions;
                
                if (curNode.count <= 0)
                {
                    node.children.remove(ch);
                    curNode.children = null;
                    curNode = null;
                    return;
                }

                node = curNode;
            }
        }

        public void remove(string key)
        {
            remove(key, 1);
        }
        
        public bool contains(string key)
        {
            return count(key) != 0;
        }
        
        public void clear()
        {

            root.children = null;
            root = new TrieNode(rootCharacter);

        }

        public int count(string key)
        {

            if (key == null) throw new ArgumentNullException();

            TrieNode node = root;

            for (int i = 0; i < key.Length; i++)
            {
                char ch = key[i];
                if (node == null) return 0;
                node = node.children.get(ch);
            }

            if (node != null) return node.count;
            return 0;
        }

        public ArrayList<string> findWordsThatStartWith(string prefix)
        {
            ArrayList<string> result = new ArrayList<string>();

            findWordsThatStartWith(root, prefix, 0, string.Empty, result);

            return result;
        }

    }

    class UnionFind
    {
        private int _size;
        private int[] sizers;

        private int[] id;
        
        private int numComponents;

        public UnionFind(int size)
        {

            if (size <= 0) throw new ArgumentOutOfRangeException("Size <= 0 is not allowed");

            this._size = numComponents = size;
            sizers = new int[size];
            id = new int[size];

            for (int i = 0; i < size; i++)
            {
                id[i] = i;
                sizers[i] = 1;
            }

        }
        
        public int find(int p)
        {
            int root = p;
            while (root != id[root])
                root = id[root];

            while (p != root)
            {
                int next = id[p];
                id[p] = root;
                p = next;
            }

            return root;

        }

        public bool connected(int p, int q)
        {
            return find(p) == find(q);
        }
        
        public int componentSize(int p)
        {
            return sizers[find(p)];
        }
        
        public int size()
        {
            return _size;
        }

        public bool isEmpty()
        {
            return (this.size() == 0);
        }
        
        public int components()
        {
            return numComponents;
        }
        
        public void unify(int p, int q)
        {

            int root1 = find(p);
            int root2 = find(q);
            
            if (root1 == root2) return;
            
            if (sizers[root1] < sizers[root2])
            {
                sizers[root2] += sizers[root1];
                id[root1] = root2;
            }
            else
            {
                sizers[root1] += sizers[root2];
                id[root2] = root1;
            }
            
            numComponents--;
        }

    }

}