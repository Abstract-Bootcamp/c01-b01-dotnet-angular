QueueUsingLinkedList queue = new QueueUsingLinkedList();

queue.Enqueue(10);
queue.Enqueue(20);
queue.Enqueue(30);

Console.WriteLine("Queue contents:");
queue.PrintQueue();

int dequeuedItem = queue.Dequeue();
Console.WriteLine($"Dequeued item: {dequeuedItem}");

int peekedItem = queue.Peek();
Console.WriteLine($"Peeked item: {peekedItem}");

Console.WriteLine("Queue contents after dequeue and peek:");
queue.PrintQueue();

public class QueueUsingLinkedList
{
    private Node front;
    private Node back;

    public QueueUsingLinkedList()
    {
        front = null;
        back = null;
    }

    public bool IsEmpty()
    {
        return front == null;
    }

    public void Enqueue(int data)
    {
        var newNode = new Node(data);
        if (IsEmpty())
        {
            front = newNode;
        }
        else
        {
            back.Next = newNode;
        }

        back = newNode;
    }

    public int Dequeue()
    {
        if (IsEmpty())
        {
            Console.WriteLine("Queue is empty");
            return 0;
        }

        var data = front.Data;
        front = front.Next;

        if (front == null)
        {
            back = null;
        }

        return data;
    }


    public int Peek()
    {
        if (IsEmpty())
        {
            Console.WriteLine("Stack is empty");
            return 0;
        }

        return front.Data;
    }



    public void PrintQueue()
    {
        if (IsEmpty())
        {
            Console.WriteLine("Queue is empty");
            return;
        }

        var current = front;
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
