StackUsingLinkedList stack = new StackUsingLinkedList();

stack.Push(10);
stack.Push(20);
stack.Push(30);

Console.WriteLine("Stack contents:");
stack.PrintStack();
Console.WriteLine();
int poppedItem = stack.Pop();
Console.WriteLine($"Popped item: {poppedItem}");
stack.PrintStack();
Console.WriteLine();

int peekedItem = stack.Peek();
Console.WriteLine($"Peeked item: {peekedItem}");
stack.PrintStack();


public class StackUsingLinkedList
{
    private Node top;

    public StackUsingLinkedList()
    {
        top = null;
    }


    public void Push(int data)
    {
        Node newNode = new Node(data);
        newNode.Next = top;
        top = newNode;
    }

    public int Pop()
    {
        if (IsEmpty())
        {
            Console.WriteLine("Stack is empty");
            return 0;
        }

        var data = top.Data;
        top = top.Next;

        return data;
    }

    public int Peek()
    {
        if (IsEmpty())
        {
            Console.WriteLine("Stack is empty");
            return 0;
        }

        return top.Data;
    }

    public bool IsEmpty()
    {
        return top == null;
    }

    public void PrintStack()
    {
        if (IsEmpty())
        {
            Console.WriteLine("Stack is empty");
            return;
        }

        var current = top;
        while (current != null)
        {
            Console.Write(current.Data + " -> ");
            current = current.Next;
        }
    }
}

public class Node
{
    public int Data;
    public Node Next;

    public Node(int data)
    {
        Data = data;
        Next = null;
    }
}
