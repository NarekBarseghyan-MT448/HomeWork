using System.Collections;
using MyLinkedListProj;
namespace MyPriortyQueueProj;

public class MyPriortyQueue<T> : IEnumerable<T>
    where T : IComparable<T>
{
    MyLinkedList<T> _items = new MyLinkedList<T>();


    public void Enqueue(T item)
    {
        if (_items.Count == 0) _items.AddLast(item);
        else
        {
            var current = _items.Head;
            while (current != null && current.Value.CompareTo(item) > 0) current = current.Next;
            if (current == null) _items.AddLast(item);
            else _items.AddBefore(current, item);
        }
    }
    public T Dequeue()
    {
        if (_items.Count == 0)
        {
            throw new InvalidOperationException("The queue is empty");
        }

        T value = _items.Head.Value;
        _items.RemoveFirst();
        return value;

    }

    public T Peek()
    {
        if (_items.Count == 0)
            throw new InvalidOperationException("The queue is empty");

        return _items.Head.Value;
    }
    public int Count()
    {
        return (_items.Count);
    }

    public IEnumerator<T> GetEnumerator()
    {
        throw new NotImplementedException();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}