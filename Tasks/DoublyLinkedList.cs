using System;
using System.Collections;
using System.Collections.Generic;
using Tasks.DoNotChange;

namespace Tasks
{
    public class DoublyLinkedList<T> : IDoublyLinkedList<T>
    {
        private Node<T> head;  // Points to the first node
        private Node<T> tail;  // Points to the last node
        private int length;     // Tracks the length of the list
        public int Length => length;

        public DoublyLinkedList()
        {
            head = null;
            tail = null;
            length = 0;
        }

        public void Add(T e)
        {
            var newNode = new Node<T>(e);

            if (head == null) 
            {
                head = newNode;
                tail = newNode;
            }
            else
            {
                tail!.Next = newNode;
                newNode.Prev = tail;
                tail = newNode;
            }
            length++; //list increments
        }

        public void AddAt(int index, T e)
        {
            if (index < 0 || index > length) throw new IndexOutOfRangeException();

            var newNode = new Node<T>(e);

            if (index == 0)
            {
                if (head == null)
                {
                    head = tail = newNode;
                }
                else
                {
                    newNode.Next = head;
                    head.Prev = newNode;
                    head = newNode;
                }
            }
            else if (index == length)
            {
                Add(e); // Adding at the end
                return;
            }
            else
            {
                var currentNode = head;
                for (int i = 0; i < index; i++)
                {
                    currentNode = currentNode.Next;
                }

                newNode.Prev = currentNode.Prev;
                newNode.Next = currentNode;

                if (currentNode.Prev != null) currentNode.Prev.Next = newNode;
                currentNode.Prev = newNode;
            }

            length++;
        }

        public T ElementAt(int index)
        {
            if (index < 0 || index >= length) throw new IndexOutOfRangeException();

            var currentNode = head;
            for (int i = 0; i < index; i++)
            {
                currentNode = currentNode.Next;
            }
            return currentNode.Data;
        }

        public void Remove(T item)
        {
            var currentNode = head;

            while (currentNode != null)
            {
                if (EqualityComparer<T>.Default.Equals(currentNode.Data, item))
                {
                    if (currentNode.Prev != null)
                    {
                        currentNode.Prev.Next = currentNode.Next;
                    }
                    else
                    {
                        head = currentNode.Next; // Removing the head
                    }

                    if (currentNode.Next != null)
                    {
                        currentNode.Next.Prev = currentNode.Prev;
                    }
                    else
                    {
                        tail = currentNode.Prev; // Removing the tail
                    }

                    length--;
                    return;
                }

                currentNode = currentNode.Next;
            }
        }

        public T RemoveAt(int index)
        {
            if (index < 0 || index >= length) throw new IndexOutOfRangeException();

            Node<T> currentNode;

            if (index == 0)
            {
                currentNode = head;
                head = head.Next;
                if (head != null) head.Prev = null;
                if (currentNode == tail) tail = null; // List becomes empty
            }
            else if (index == length - 1)
            {
                currentNode = tail;
                tail = tail.Prev;
                if (tail != null) tail.Next = null;
            }
            else
            {
                currentNode = head;
                for (int i = 0; i < index; i++)
                {
                    currentNode = currentNode.Next;
                }

                currentNode.Prev.Next = currentNode.Next;
                currentNode.Next.Prev = currentNode.Prev;
            }

            length--;
            return currentNode.Data;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new DoublyLinkedListEnumerator<T>(head);
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        private class DoublyLinkedListEnumerator<U> : IEnumerator<U>
        {
            private Node<U> currentNode;
            private readonly Node<U> head;

            public DoublyLinkedListEnumerator(Node<U> head)
            {
                this.head = head;
                currentNode = null;
            }

            public U Current => currentNode.Data;

            object IEnumerator.Current => Current;

            public bool MoveNext()
            {
                if (currentNode == null)
                {
                    currentNode = head;
                    return currentNode != null;
                }

                currentNode = currentNode.Next;
                return currentNode != null;
            }

            public void Reset()
            {
                currentNode = null;
            }

            public void Dispose() { }
        }
    }
}
