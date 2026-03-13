using ClassLibrary1;
using MyStackProj;

public class Program
{
    private static void Main()
    {
        Console.WriteLine("=======Hello Void=======");

        var linkedList = new MyLinkedList<string>();
        linkedList.AddLast("5");
        linkedList.AddLast("6");
        linkedList.AddLast("7");
        linkedList.AddLast("*");
        linkedList.AddLast("+");
        linkedList.AddLast("1");
        linkedList.AddLast("-");

        var math = new List<string> { "+", "-", "/", "*" };
        MyStack<int> stack = new MyStack<int>();

        foreach (var item in linkedList)
        {
            string token = item.ToString();
            if (math.Contains(token))
            {
                int val2 = stack.Pop();
                int val1 = stack.Pop();

                switch (token)
                {
                    case "+": stack.Push(val1 + val2); break;
                    case "-": stack.Push(val1 - val2); break;
                    case "*": stack.Push(val1 * val2); break;
                    case "/": stack.Push(val1 / val2); break;
                }
            }
            else if (int.TryParse(token, out int num))
            {
                stack.Push(num);
            }
        }

        Console.WriteLine($"Result: {stack.Pop()}"); // Output: 46
    }
}