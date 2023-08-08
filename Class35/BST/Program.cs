BinarySearchTree bst = new BinarySearchTree();

bst.Insert(5);
bst.Insert(3);
bst.Insert(7);
bst.Insert(1);
bst.Insert(4);
bst.Insert(6);
bst.Insert(8);
//     5
//    / \
//   3   7
//  / \ / \
// 1  4 6  8
// insert some nodes into the tree
Console.WriteLine("InOrderTraversal");
bst.InOrderTraversal(bst.root); // prints the nodes in ascending order
Console.WriteLine("\nPreOrderTraversal");
bst.PreOrderTraversal(bst.root); // prints the nodes in pre-order
Console.WriteLine("\nPostOrderTraversal");
bst.PostOrderTraversal(bst.root); // prints the nodes in post-order
Console.WriteLine("\nSearch");
Console.WriteLine(bst.Search(6)); // true

public class Node
{
    public int value;
    public Node left;
    public Node right;

    public Node(int value)
    {
        this.value = value;
        left = null;
        right = null;
    }
}

public class BinarySearchTree
{
    public Node root;

    public BinarySearchTree()
    {
        root = null;
    }

    public void Insert(int value)
    {
        Node newNode = new Node(value);

        if (root == null)
        {
            root = newNode;
            return;
        }

        Node current = root;
        while (true)
        {
            if (value < current.value)
            {
                if (current.left == null)
                {
                    current.left = newNode;
                    return;
                }
                current = current.left;
            }
            else
            {
                if (current.right == null)
                {
                    current.right = newNode;
                    return;
                }
                current = current.right;
            }
        }
    }

    public bool Search(int value)
    {
        if (root == null)
        {
            return false;
        }

        Node current = root;
        while (current != null)
        {
            if (value == current.value)
            {
                return true;
            }
            else if (value < current.value)
            {
                current = current.left;
            }
            else
            {
                current = current.right;
            }
        }

        return false;
    }

    public void InOrderTraversal(Node node)
    {
        if (node != null)
        {
            InOrderTraversal(node.left);
            Console.Write(node.value + " ");
            InOrderTraversal(node.right);
        }
    }

    public void PreOrderTraversal(Node node)
    {
        if (node != null)
        {
            Console.Write(node.value + " ");
            PreOrderTraversal(node.left);
            PreOrderTraversal(node.right);
        }
    }

    public void PostOrderTraversal(Node node)
    {
        if (node != null)
        {
            PostOrderTraversal(node.left);
            PostOrderTraversal(node.right);
            Console.Write(node.value + " ");
        }
    }
}