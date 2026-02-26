using System;
using System.Collections;
using System.Collections.Generic;
namespace ClassLibrary1
{
    class MyLinkedList<T> : ICollection<T>
    {
        public MyLinkedListNode<T> Head { get; private set; }
        public MyLinkedListNode<T> Tail { get; private set; }

        #region ICollection
        public int Count { get; private set; }
        public bool IsReadOnly { get => false; }

        public void Add(T item)
        {
            throw new NotImplementedException();
        }

        public void Clear()
        {
            Head = null;
            Tail = null;
            Count = 0;
        }

        public bool Contains(T item)
        {
            MyLinkedListNode<T> current = Head;
            while (current != null)
            {
                if (current.value.Equals(item)) return true;
                current = current.Next;
            }
            return false;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            MyLinkedListNode<T> current = Head;
            while (current != null)
            {
                array[arrayIndex++] = current.value;
                current = current.Next;
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            MyLinkedListNode<T> current = Head;
            while (current != null)
            {
                yield return current.value;
                current = current.Next;
            }
        }

        public bool Remove(T item)
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<T>)this).GetEnumerator();
        }
        #endregion

        #region Add
        public void AddFirst(T item)
        {
            AddFirst(new MyLinkedListNode<T>(item));
        }
        private void AddFirst(MyLinkedListNode<T> node)
        {
            MyLinkedListNode<T> temp = Head;
            if (Count == 0) Head = node;
            else Tail.Next = node;
            Tail = node;
            Count++;
        }
        #endregion
        #region Add
        public void AddLast(T item)
        {
            AddLast(new MyLinkedListNode<T>(item));
        }
        private void AddLast(MyLinkedListNode<T> node)
        {
            if (Count == 0) Head = node;
            else Tail.Next = node;
            Tail = node;
            Count++;
        }
        #endregion
        #region Add
        public void RemoveLast()
        {
            if (Head == null) return; 

            if (Head == Tail)
            {
                Head = null;
                Tail = null;
            }
            else
            {
                MyLinkedListNode<T> current = Head;
                while (current.Next != Tail)
                {
                    current = current.Next;
                }
                current.Next = null; 
                Tail = current;      
            }

            Count--;
        }
        #endregion
        #region Add
        public void RemoveFirst()
        {
            if (Head == null) return;
            Head = Head.Next;
            Count--;
            if (Count == 0) Tail = null;
        }
        #endregion
        #region Stack Methods

        public void Push(T item)
        {
            // Adding to the front is O(1)
            AddFirst(item);
        }

        public T Pop()
        {
            if (Head == null)
            {
                throw new InvalidOperationException("Stack is empty.");
            }

            T value = Head.value;
            RemoveFirst();
            return value;
        }

        public T Peek()
        {
            if (Head == null)
            {
                throw new InvalidOperationException("Stack is empty.");
            }

            return Head.value;
        }

        #endregion
    }
}