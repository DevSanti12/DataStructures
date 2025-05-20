using System;
using System.Collections.Generic;
using Tasks.DoNotChange;

namespace Tasks
{
    public class HybridFlowProcessor<T> : IHybridFlowProcessor<T>
    {
        private LinkedList<T> _storage = new LinkedList<T>();

        /// <summary>
        /// FILO behavior: Push adds an item to the top of the storage.
        /// </summary>
        public T Dequeue()
        {
            if (_storage.Count == 0)
            {
                throw new InvalidOperationException("The proccesor is empty. There is not item to dequeue. ");
            }
            T value = _storage.First.Value; //get the value from the first node
            _storage.RemoveFirst();
            return value;
        }

        public void Enqueue(T item)
        {
            _storage.AddLast(item); // Add to the end of the doubly linked list.
        }

        /// <summary>
        /// FILO behavior: Pop retrieves the topmost item (from the beginning) and removes it.
        /// </summary>
        public T Pop()
        {
            if(_storage.Count == 0)
            {
                throw new InvalidOperationException("The processor is empty. There is no item to pop");
            }

            T value = _storage.First.Value;
            _storage.RemoveFirst(); //Removes the first node
            return value;
        }

        public void Push(T item)
        {
            _storage.AddFirst(item); //Add to the beginning of the doubly linked list.
        }
    }
}
