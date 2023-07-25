
LinkedList linkedList = new LinkedList();

linkedList.Add(10);
linkedList.Add(20);
linkedList.Add(30);
linkedList.Add(5);
linkedList.Add(25);

linkedList.Print();

Console.WriteLine();

linkedList.Remove(30);
linkedList.Remove(5);

linkedList.Print();


class Node
{
    public int Value { get; set; }
    public Node Next { get; set; }
    // public Node Previous { get; set; }
}

class LinkedList
{
    private Node _head;

    public void Add(int value)
    {
        var newNode = new Node { Value = value };
        if (_head == null)
        {
            _head = newNode;
        }
        else
        {
            var current = _head;
            while (current.Next != null)
            {
                current = current.Next;
            }

            current.Next = newNode;
        }
    }

    public void Remove(int value)
    {
        if (_head == null)
        {
            return;
        }

        if (_head.Value == value)
        {
            _head = _head.Next;
            return;
        }

        // 1 -> 2 -> 4 -> 5
        // x 3

        var current = _head;
        while (current.Next != null)
        {
            if (current.Next.Value == value)
            {
                current.Next = current.Next.Next;
                return;
            }
            current = current.Next;
        }
    }

    public void Print()
    {
        if (_head == null)
        {
            Console.WriteLine("List is empty");
            return;
        }

        var current = _head;
        while (current != null)
        {
            Console.Write($"{current.Value} => ");
            current = current.Next;
        }
    }

}