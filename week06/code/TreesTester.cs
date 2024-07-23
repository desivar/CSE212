using System;
using System.Collections.Generic;

public static class TreesTester
{
    /// <summary>
    /// Entry point for the Prove 9 tests
    /// </summary>
    public static void Run()
    {
        // Sample Test Cases (may not be comprehensive)
        Console.WriteLine("\n=========== PROBLEM 1 TESTS ===========");
        BinarySearchTree tree = new BinarySearchTree();
        tree.Insert(5);
        tree.Insert(3);
        tree.Insert(7);
        // After implementing 'no duplicates' rule,
        // this next insert will have no effect on the tree.
        tree.Insert(7);
        tree.Insert(4);
        tree.Insert(10);
        tree.Insert(1);
        tree.Insert(6);
        Console.WriteLine(tree.ToString()); // 1, 3, 4, 5, 6, 7, 10

        Console.WriteLine("\n=========== PROBLEM 2 TESTS ===========");
        Console.WriteLine(tree.Contains(3)); // True
        Console.WriteLine(tree.Contains(2)); // False
        Console.WriteLine(tree.Contains(7)); // True
        Console.WriteLine(tree.Contains(6)); // True
        Console.WriteLine(tree.Contains(9)); // False

        Console.WriteLine("\n=========== PROBLEM 3 TESTS ===========");
        foreach (var value in tree.Reverse())
        {
            Console.WriteLine(value); // 10, 7, 6, 5, 4, 3, 1
        }
    }
}

public class BinarySearchTree
{
    private class Node
    {
        public int Value;
        public Node Left;
        public Node Right;

        public Node(int value)
        {
            Value = value;
        }
    }

    private Node root;

    public void Insert(int value)
    {
        root = Insert(root, value);
    }

    private Node Insert(Node node, int value)
    {
        if (node == null)
        {
            return new Node(value);
        }

        if (value < node.Value)
        {
            node.Left = Insert(node.Left, value);
        }
        else if (value > node.Value)
        {
            node.Right = Insert(node.Right, value);
        }

        // If value == node.Value, do nothing (no duplicates)
        return node;
    }

    public bool Contains(int value)
    {
        return Contains(root, value);
    }

    private bool Contains(Node node, int value)
    {
        if (node == null)
        {
            return false;
        }

        if (value < node.Value)
        {
            return Contains(node.Left, value);
        }
        else if (value > node.Value)
        {
            return Contains(node.Right, value);
        }
        else
        {
            return true;
        }
    }

    public override string ToString()
    {
        var values = new List<int>();
        InOrderTraversal(root, values);
        return string.Join(", ", values);
    }

    private void InOrderTraversal(Node node, List<int> values)
    {
        if (node == null)
        {
            return;
        }

        InOrderTraversal(node.Left, values);
        values.Add(node.Value);
        InOrderTraversal(node.Right, values);
    }

    public IEnumerable<int> Reverse()
    {
        var values = new List<int>();
        ReverseInOrderTraversal(root, values);
        return values;
    }

    private void ReverseInOrderTraversal(Node node, List<int> values)
    {
        if (node == null)
        {
            return;
        }

        ReverseInOrderTraversal(node.Right, values);
        values.Add(node.Value);
        ReverseInOrderTraversal(node.Left, values);
    }
}
