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
 *
 * To do:  
 *  -Set
 *  -Multiset (Bag)
 *  -Binary (Search) Tree
 *  -Priority Queue
 *  -ArrayList
 *  -Double Ended Queue (Deque)
 *  -Circular Queue
 *  -Circular Linked List
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

    class LinkedList<T>
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

    class DoublyLinkedList<T>
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

    class LinkedListStack<T>
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

    class Stack<T>
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
            for (int i = myList.Count - 1; i >= 0; i--)
            {
                Console.WriteLine(myList[i]);
            }
        }

        public System.Collections.Generic.List<T> getList()
        {
            return myList;
        }

        public bool contains(T t)
        {
            for (int i = 0; i < myList.Count; i++)
            {
                if (myList[i].Equals(t)) return true;
            }
            return false;
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

    class LinkedListQueue<T>
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

    class Queue<T>
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
            for (int i = 0; i < myList.Count; i++)
            {
                Console.WriteLine(myList[i]);
            }
        }

        public System.Collections.Generic.List<T> getList()
        {
            return myList;
        }

        public bool contains(T t)
        {
            for (int i = 0; i < myList.Count; i++)
            {
                if (myList[i].Equals(t)) return true;
            }
            return false;
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
}
