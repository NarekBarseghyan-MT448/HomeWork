namespace ClassLibrary1
{
    class MyLinkedListNode <T> 
    {
        public T value { get; set; }
        public MyLinkedListNode<T> Next { get; set; }
        public MyLinkedListNode(T value)
        {
            value = value;
        }
    }
}
