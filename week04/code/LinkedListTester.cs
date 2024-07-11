public static class LinkedListTester {
    public static void Run() {
        // Sample Test Cases (may not be comprehensive) 
        Console.WriteLine("\n=========== PROBLEM 1 TESTS ===========");
        var ll = new LinkedList();
        ll.InsertTail(1);
        ll.InsertHead(2);
        ll.InsertHead(2);
        ll.InsertHead(2);
        ll.InsertHead(3);
        ll.InsertHead(4);
        ll.InsertHead(5);

        Console.WriteLine(ll.ToString()); // <LinkedList>{5, 4, 3, 2, 2, 2, 1};
        ll.InsertTail(0);
        ll.InsertTail(-1);
        Console.WriteLine(ll.ToString()); // <LinkedList>{5, 4, 3, 2, 2, 2, 1, 0, -1};

        var ll2 = new LinkedList();
        ll2.InsertTail(1);
        Console.WriteLine(ll2.HeadAndTailAreNotNull()); // True
        ///public class LinkedList
{
    private class Node
    {
        public int Value { get; set; }
        public Node Next { get; set; }

        public Node(int value)
        {
            Value = value;
            Next = null;
        }
    }

    private Node head;
    private Node tail;

    public void InsertHead(int value)
    {
        var newNode = new Node(value);
        newNode.Next = head;
        head = newNode;
        if (tail == null)
            tail = head;
    }

    public void InsertTail(int value)
    {
        var newNode = new Node(value);
        if (tail == null)
            head = tail = newNode;
        else
        {
            tail.Next = newNode;
            tail = newNode;
        }
    }

    public bool HeadAndTailAreNotNull()
    {
        return head != null && tail != null;
    }

    public override string ToString()
    {
        var result = new StringBuilder();
        var current = head;
        while (current != null)
        {
            result.Append(current.Value);
            if (current.Next != null)
                result.Append(", ");
            current = current.Next;
        }
        return $"<LinkedList>{{{result}}}";
    }
}
///

        Console.WriteLine("\n=========== PROBLEM 2 TESTS ===========");
        ll.RemoveTail();
        Console.WriteLine(ll.ToString()); // <LinkedList>{5, 4, 3, 2, 2, 2, 1, 0}
        ll.RemoveTail();
        Console.WriteLine(ll.ToString()); // <LinkedList>{5, 4, 3, 2, 2, 2, 1}

        var ll3 = new LinkedList();
        ll3.RemoveTail();
        Console.WriteLine(ll3.ToString()); // <LinkedList>{}
        ll3.InsertHead(2);
        ll3.RemoveTail();
        Console.WriteLine(ll3.ToString()); // <LinkedList>{}
        Console.WriteLine(ll3.HeadAndTailAreNull()); // True
        ///
        public class LinkedList
{
    private class Node
    {
        public int Value { get; set; }
        public Node Next { get; set; }

        public Node(int value)
        {
            Value = value;
            Next = null;
        }
    }

    private Node head;
    private Node tail;

    // Other methods (InsertHead, InsertTail, HeadAndTailAreNotNull) remain unchanged.

    public void RemoveTail()
    {
        if (head == null)
            return; // Empty list, nothing to remove

        if (head == tail)
        {
            // Only one node in the list
            head = tail = null;
            return;
        }

        // Find the second-to-last node
        Node current = head;
        while (current.Next != tail)
            current = current.Next;

        // Update tail and remove the last node
        tail = current;
        tail.Next = null;
    }

    public bool HeadAndTailAreNull()
    {
        return head == null && tail == null;
    }

    // Other methods (ToString, etc.) remain unchanged.
}
//

        Console.WriteLine("\n=========== PROBLEM 3 TESTS ===========");
        ll.InsertAfter(3, 35);
        ll.InsertAfter(5, 6);
        Console.WriteLine(ll.ToString()); // <LinkedList>{5, 6, 4, 3, 35, 2, 2, 2, 1}
        ll.Remove(-1);
        Console.WriteLine(ll.ToString()); // <LinkedList>{5, 6, 4, 3, 35, 2, 2, 2, 1}
        ll.Remove(3);
        Console.WriteLine(ll.ToString()); // <LinkedList>{5, 6, 4, 35, 2, 2, 2, 1}
        ll.Remove(6);
        Console.WriteLine(ll.ToString()); // <LinkedList>{5, 4, 35, 2, 2, 2, 1}
        ll.Remove(1);
        Console.WriteLine(ll.ToString()); // <LinkedList>{5, 4, 35, 2, 2, 2}
        ll.Remove(7);
        Console.WriteLine(ll.ToString()); // <LinkedList>{5, 4, 35, 2, 2, 2}
        ll.Remove(5);
        Console.WriteLine(ll.ToString()); // <LinkedList>{4, 35, 2, 2, 2}
        ll.Remove(2);
        Console.WriteLine(ll.ToString()); // <LinkedList>{4, 35, 2, 2}

        var ll4 = new LinkedList();
        ll4.Remove(0);
        Console.WriteLine(ll4.ToString()); // <LinkedList>{}
        ll4.InsertHead(2);
        ll4.Remove(2);
        Console.WriteLine(ll4.ToString()); // <LinkedList>{}
        Console.WriteLine(ll4.HeadAndTailAreNull()); // True
        //
        public class LinkedList
{
    private class Node
    {
        public int Value { get; set; }
        public Node Next { get; set; }

        public Node(int value)
        {
            Value = value;
            Next = null;
        }
    }

    private Node head;
    private Node tail;

    // Other methods (InsertHead, InsertTail, HeadAndTailAreNotNull) remain unchanged.

    public void InsertAfter(int targetValue, int newValue)
    {
        Node current = head;
        while (current != null)
        {
            if (current.Value == targetValue)
            {
                Node newNode = new Node(newValue);
                newNode.Next = current.Next;
                current.Next = newNode;
                if (current == tail)
                    tail = newNode;
                break;
            }
            current = current.Next;
        }
    }

    public void Remove(int value)
    {
        if (head == null)
            return; // Empty list, nothing to remove

        if (head.Value == value)
        {
            head = head.Next;
            if (head == null)
                tail = null;
            return;
        }

        Node current = head;
        while (current.Next != null)
        {
            if (current.Next.Value == value)
            {
                current.Next = current.Next.Next;
                if (current.Next == null)
                    tail = current;
                return;
            }
            current = current.Next;
        }
    }

    public bool HeadAndTailAreNull()
    {
        return head == null && tail == null;
    }

    // Other methods (ToString, etc.) remain unchanged.
}
//

       public class LinkedList
{
    private class Node
    {
        public int Value { get; set; }
        public Node Next { get; set; }

        public Node(int value)
        {
            Value = value;
            Next = null;
        }
    }

    private Node head;
    private Node tail;

    // Other methods (InsertHead, InsertTail, HeadAndTailAreNotNull) remain unchanged.

    public void InsertAfter(int targetValue, int newValue)
    {
        Node current = head;
        while (current != null)
        {
            if (current.Value == targetValue)
            {
                Node newNode = new Node(newValue);
                newNode.Next = current.Next;
                current.Next = newNode;
                if (current == tail)
                    tail = newNode;
                break;
            }
            current = current.Next;
        }
    }

    public void Remove(int value)
    {
        if (head == null)
            return; // Empty list, nothing to remove

        if (head.Value == value)
        {
            head = head.Next;
            if (head == null)
                tail = null;
            return;
        }

        Node current = head;
        while (current.Next != null)
        {
            if (current.Next.Value == value)
            {
                current.Next = current.Next.Next;
                if (current.Next == null)
                    tail = current;
                return;
            }
            current = current.Next;
        }
    }

    public bool HeadAndTailAreNull()
    {
        return head == null && tail == null;
    }

    // Other methods (ToString, etc.) remain unchanged.
}
