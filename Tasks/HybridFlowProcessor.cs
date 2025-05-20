using System;
using System.Collections.Generic;
using Tasks.DoNotChange;

namespace Tasks
{
    public class HybridFlowProcessor<T> : IHybridFlowProcessor<T>
    {
        private DoublyLinkedList<T> _storage = new DoublyLinkedList<T>();
        /// <summary>
        /// FILO behavior: Push adds an item to the top of the storage.
        /// </summary>
        public T Dequeue()
        {
            if (_storage.Length == 0)
                throw new InvalidOperationException("The processor is empty. There is no item to dequeue");

            return _storage.RemoveAt(0);
        }

        public void Enqueue(T item)
        {
            _storage.Add(item); // Agrega al final
        }

        /// <summary>
        /// FILO behavior: Pop retrieves the topmost item (from the beginning) and removes it.
        /// </summary>
        public T Pop()
        {
            if (_storage.Length == 0)
                throw new InvalidOperationException("The processor is empty. There is no item to pop");

            return _storage.RemoveAt(0);
        }

        public void Push(T item)
        {
            _storage.AddAt(0, item); // Insertar al inicio
        }
    }
}
