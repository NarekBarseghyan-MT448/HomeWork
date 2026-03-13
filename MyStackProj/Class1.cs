using ClassLibrary1;
using System.Collections;

namespace MyStackProj;

public class MyStack<T> : IEnumerable<T>
{
    public MyLinkedList<T> MyStackItems = new MyLinkedList<T>();
    public MyStack()
    {

    }

    /// <summary>
    /// To create a stack with default values
    /// </summary>
    /// <param name="collection"></param>
    public MyStack(ICollection<T> collection)
    {
        foreach (var item in collection)
        {
            Push(item);
        }
    }

    /// <summary>
    /// Adds a new value to the top of stack
    /// </summary>
    public void Push(T value)
    {
        MyStackItems.AddFirst(value);
    }

    /// <summary>
    /// Removes the top element and returns it
    /// </summary>
    /// <returns></returns>
    public T Pop()
    {
        var itemToRemove = MyStackItems.Head.Value;

        MyStackItems.RemoveFirst<T>();

        return itemToRemove;
    }

    /// <summary>
    /// Looks at the top element and returns it
    /// </summary>
    /// <returns></returns>
    public T Peek()
    {
        return MyStackItems.Head.Value;
    }

    public IEnumerator<T> GetEnumerator()
    {
        return MyStackItems.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}