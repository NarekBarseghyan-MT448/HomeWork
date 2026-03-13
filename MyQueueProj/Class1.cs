using LinkedListProj;
using System.Collections;

namespace MyQueueProj;

public class MyQueue<T> : IEnumerable<T>
{
    MyLinkedList<T> items = new MyLinkedList<T>();

    public void Enqueue(T item)
    {
        items.AddLast(item);
    }

    public T Dequeue()
    {
        if (items.Count == 0)
            throw new InvalidOperationException("Queue is empty");
        T value = items.Head.Value;
        items.RemoveFirst();
        return value;
    }

    public T peek()
    {
        if (items.Count == 0)
            throw new InvalidOperationException("Queue is empty ");
        return items.Head.Value;
    }

    public int Count
    {
        get { return items.Count; }
    }

    public void Clear()
    {
        items.Clear();
        Console.WriteLine("Հերթը դատարկվեց:");
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