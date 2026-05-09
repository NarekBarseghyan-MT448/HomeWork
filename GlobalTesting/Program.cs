using LinkedListLibrary;
using StackLibrary;
using MyQueueProj;
using BinaryTreeLibrary;
using MyBubbleSortProj;
using MyInsertionSortProj;
using MySelectionSortProj;
using MyQuickSortProj;
using MyMergeSortProj;
using HashTablesProj;
using SetLib;

namespace GlobalTesting;

internal class Program
{
    static void Main()
    {
        TestLinkedList();
        TestStack();
        TestQueue();
        TestBinaryTree();
        TestBubbleSort();
        TestInsertionSort();
        TestSelectionSort();
        TestQuickSort();
        TestMergeSort();
        TestHashtable();
        TestSet();


        Console.WriteLine("\n--- All tests completed ---");
    }

    static void TestLinkedList()
    {
        Console.WriteLine("### Testing Linked List ###");
        var list = new MyLinkedList<int>();
        list.AddLast(10);
        list.AddLast(20);
        list.AddFirst(5);

        Console.WriteLine($"List items: {string.Join(", ", list)}"); // 5, 10, 20
        Console.WriteLine($"Count: {list.Count}");

        list.Remove(10);
        Console.WriteLine($"After removing 10: {string.Join(", ", list)}");
        Console.WriteLine();
    }

    static void TestStack()
    {
        Console.WriteLine("### Testing Stack (LIFO) ###");
        var stack = new MyStack<string>();
        stack.Push("First");
        stack.Push("Second");
        stack.Push("Third");

        Console.WriteLine($"Popped: {stack.Pop()}"); // Should be Third
        Console.WriteLine($"Popped: {stack.Pop()}"); // Should be Second
        Console.WriteLine($"Remaining count: {stack.Count}");
        Console.WriteLine();
    }

    static void TestQueue()
    {
        Console.WriteLine("### Testing Queue (FIFO) ###");
        var queue = new MyQueue<int>();
        queue.Enqueue(1);
        queue.Enqueue(2);
        queue.Enqueue(3);

        Console.WriteLine($"Dequeued: {queue.Dequeue()}"); // Should be 1
        Console.WriteLine($"Dequeued: {queue.Dequeue()}"); // Should be 2
        Console.WriteLine($"Remaining count: {queue.Count()}");
        Console.WriteLine();
    }

    static void TestBinaryTree()
    {
        Console.WriteLine("### Testing Binary Search Tree ###");
        var bst = new MyBinaryTree<int>();

        // Adding elements in unsorted order
        bst.Add(50);
        bst.Add(30);
        bst.Add(70);
        bst.Add(20);
        bst.Add(40);
        bst.Add(90);

        // In-Order Traversal should result in sorted output
        Console.WriteLine("In-Order (Sorted): " + string.Join(", ", bst));

        // Pre-Order Traversal
        Console.WriteLine("Pre-Order: " + string.Join(", ", bst.PreOrder()));

        Console.WriteLine($"Contains 40? {bst.Any(x => x == 40)}");

        bst.Remove(30);
        Console.WriteLine("After removing 30 (In-Order): " + string.Join(", ", bst));
        Console.WriteLine();
    }
    static void TestBubbleSort()
    {
        Console.WriteLine("### Testing Bubble Sort ###");

        var sorter = new MyBubbleSort<int>();
        int[] numbers = { 52, 10, 8, 25, 40, 2 };

        Console.WriteLine($"Original array: {string.Join(", ", numbers)}");

        // Կանչում ենք տեսակավորման մեթոդը
        sorter.BubbleSort(numbers);

        Console.WriteLine($"Sorted array:   {string.Join(", ", numbers)}");

        // Թեստավորում տեքստային (string) տիպի համար
        var stringSorter = new MyBubbleSort<string>();
        string[] names = { "Banana", "Apple", "Cherry", "Date" };

        Console.WriteLine($"\nOriginal names: {string.Join(", ", names)}");
        stringSorter.BubbleSort(names);
        Console.WriteLine($"Sorted names:   {string.Join(", ", names)}");

        Console.WriteLine();
    }

    static void TestInsertionSort()
    {
        Console.WriteLine("### Testing Insertion Sort ###");

        var sorter = new MyBubbleSort<int>();
        int[] numbers = { 15, 3, 8, 1, 20, 5, 12 };

        Console.WriteLine($"Original array: {string.Join(", ", numbers)}");

        // Կանչում ենք InsertionSort մեթոդը
        sorter.InsertionSort(numbers);

        Console.WriteLine($"Sorted array:   {string.Join(", ", numbers)}");

        // Թեստավորում string-ների համար
        var stringSorter = new MyBubbleSort<string>();
        string[] fruits = { "Orange", "Apple", "Mango", "Banana" };

        Console.WriteLine($"\nOriginal fruits: {string.Join(", ", fruits)}");
        stringSorter.InsertionSort(fruits);
        Console.WriteLine($"Sorted fruits:   {string.Join(", ", fruits)}");

        Console.WriteLine();
    }

    static void TestSelectionSort()
    {
        Console.WriteLine("### Testing Selection Sort ###");

        // Ստեղծում ենք սորտավորող օբյեկտը int-երի համար
        var sorter = new MySelectionSort<int>();
        int[] numbers = { 64, 25, 12, 22, 11 };

        Console.WriteLine($"Original array: {string.Join(", ", numbers)}");

        // Կանչում ենք Sort մեթոդը
        sorter.SelectionSort(numbers);

        Console.WriteLine($"Sorted array:   {string.Join(", ", numbers)}");

        // Թեստավորում string-ների համար
        var stringSorter = new MySelectionSort<string>();
        string[] cities = { "Yerevan", "London", "Paris", "Berlin" };

        Console.WriteLine($"\nOriginal cities: {string.Join(", ", cities)}");
        stringSorter.SelectionSort(cities);
        Console.WriteLine($"Sorted cities:   {string.Join(", ", cities)}");

        Console.WriteLine();
    }

    static void TestQuickSort()
    {
        Console.WriteLine("### Testing Quick Sort ###");

        var sorter = new MyQuickSort<int>();
        int[] numbers = { 80, 10, 30, 90, 40, 50, 70 };

        Console.WriteLine($"Original array: {string.Join(", ", numbers)}");
        sorter.QuickSort(numbers);
        Console.WriteLine($"Sorted array:   {string.Join(", ", numbers)}");

        var stringSorter = new MyQuickSort<string>();
        string[] languages = { "C#", "Python", "Java", "C++", "JavaScript" };

        Console.WriteLine($"\nOriginal languages: {string.Join(", ", languages)}");
        stringSorter.QuickSort(languages);
        Console.WriteLine($"Sorted languages:   {string.Join(", ", languages)}");

        Console.WriteLine();
    }

    static void TestMergeSort()
    {
        Console.WriteLine("### Testing Merge Sort ###");

        var sorter = new MyMergeSort<int>();
        int[] numbers = { 38, 27, 43, 3, 9, 82, 10 };

        Console.WriteLine($"Original array: {string.Join(", ", numbers)}");
        sorter.MergeSort(numbers);
        Console.WriteLine($"Sorted array:   {string.Join(", ", numbers)}");

        var stringSorter = new MyMergeSort<string>();
        string[] animals = { "Zebra", "Elephant", "Cat", "Dog", "Bear" };

        Console.WriteLine($"\nOriginal animals: {string.Join(", ", animals)}");
        stringSorter.MergeSort(animals);
        Console.WriteLine($"Sorted animals:   {string.Join(", ", animals)}");

        Console.WriteLine();
    }

    static void TestHashtable()
    {
        Console.WriteLine("### Testing Custom Hashtable (Folding Hash) ###");

        var table = new MyHashTable<string, string>();

        table.Add("User1", "Admin");
        table.Add("User2", "Editor");
        table.Add("User3", "Guest");

        Console.WriteLine($"User1 role: {table.Get("User1")}");
        Console.WriteLine($"Contains 'User3'? {table.ContainsKey("User3")}");
        Console.WriteLine($"Total elements: {table.Count}");

        Console.WriteLine();
    }

    static void TestSet()
    {
        Console.WriteLine("### Testing Custom Set (SetLib) ###");

        var setA = new MySet<int>();
        setA.AddRange(new[] { 1, 2, 3, 4, 5 });

        var setB = new MySet<int>();
        setB.AddRange(new[] { 4, 5, 6, 7, 8 });

        Console.WriteLine($"Set A: {{{string.Join(", ", setA)}}}");
        Console.WriteLine($"Set B: {{{string.Join(", ", setB)}}}");

        // Միավորում (Union): 1, 2, 3, 4, 5, 6, 7, 8
        var union = setA.Union(setB);
        Console.WriteLine($"Union: {{{string.Join(", ", union)}}}");

        // Հատում (Intersection): 4, 5
        var intersection = setA.Intersection(setB);
        Console.WriteLine($"Intersection: {{{string.Join(", ", intersection)}}}");

        // Տարբերություն (Difference A - B): 1, 2, 3
        var difference = setA.Difference(setB);
        Console.WriteLine($"Difference (A - B): {{{string.Join(", ", difference)}}}");

        // Սիմետրիկ տարբերություն: 1, 2, 3, 6, 7, 8
        var symDifference = setA.SymmetricDifference(setB);
        Console.WriteLine($"Symmetric Difference: {{{string.Join(", ", symDifference)}}}");

        Console.WriteLine($"Set A contains 3? {setA.Contains(3)}");
        Console.WriteLine($"Set A count: {setA.Count}");

        Console.WriteLine();
    }
}
