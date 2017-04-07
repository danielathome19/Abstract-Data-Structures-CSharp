using System;

/*
 * Author:  Daniel Szelogowski (C) 2017
 * Created: 4/7/17
 * Purpose: A collection of data structures written in C# using generics.
 * 
 * 
 **************************************************************************/

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
            while (myList.myNext != null)
            {
                myLast = myLast.myNext;
            }
            Node<T> temp = new Node<T>(t);
            myLast.myNext = temp;
        }
    }
}
