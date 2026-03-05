using LinkedListProj;
using System.Collections;

namespace ClassLibrary1;

public class MyLinkedList<T> : ICollection<T>
{
    public MyLinkedList()
    {

    }

    public MyLinkedListNode<T> Head { get; private set; }
    public MyLinkedListNode<T> Tail { get; private set; }

    #region ICollection
    public int Count { get; private set; }
    public bool IsReadOnly { get => false; }

    public void Add(T item)
    {
        AddFirst(item);
    }

    public void Clear()
    {
        Head = null;
        Tail = null;
        Count = 0;
    }

    public bool Contains(T item)
    {
        var current = Head;

        while (current != null)
        {
            if (current.Value.Equals(item))
                return true;

            current = current.Next;
        }

        return false;
    }

    public void CopyTo(T[] array, int arrayIndex)
    {
        var current = Head;

        while (current != null)
        {
            array[arrayIndex++] = current.Value;
            current = current.Next;
        }
    }
    public bool Remove(T item)
    {
        throw new NotImplementedException();
    }

    public IEnumerator<T> GetEnumerator()
    {
        var current = Head;

        while (current != null)
        {
            yield return current.Value;

            current = current.Next;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    #endregion ICollection
    #region Add
    public void AddFirst(T value)
    {
        AddFirst(new MyLinkedListNode<T>(value));
    }
    private void AddFirst(MyLinkedListNode<T> node)
    {
        MyLinkedListNode<T> temp = Head;

        Head = node;
        Head.Next = temp;
        Count++;

        if (Count == 1)
        {
            Tail = Head;
        }
    }

    public void AddLast(T value)
    {
        AddLast(new MyLinkedListNode<T>(value));
    }
    private void AddLast(MyLinkedListNode<T> node)
    {
        if (Count == 0)
        {
            Head = node;
            Tail = node;
        }
        else
        {
            Tail.Next = node;
            Tail = node;
        }
        Count++;
    }
    #endregion Add
    #region Remove
    /// <summary>
    /// Removes the first node from the list
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public void RemoveFirst<T>()
    {
        //Check if the list is empty
        if (Head == null)
            throw new InvalidOperationException("Cannot remove from empty list");

        //Move Head to the next node
        Head = Head.Next;
        Count--;

        //If list is now empty, Tail should also be null
        if (Count == 0)
            Tail = null;
    }

    /// <summary>
    /// Removes the last node from the list
    /// </summary>
    /// <param name="value"></param>

    public void RemoveLast()
    {
        //Check if list is empty
        if (Count == 0)
            throw new InvalidOperationException("Cannot remove from empty list");

        //Special case;only one node
        if (Count == 1)
        {
            Head = null;
            Tail = null;
        }
        else
        {
            //Find the node Before the tail
            MyLinkedListNode<T> current = Head;

            //Stop when current.Next is the Tail
            while (current.Next != Tail)
            {
                current = current.Next;
            }

            //Disconnect the tail
            current.Next = null;
            Tail = current;
        }

        Count--;
    }
    #endregion Remove
}