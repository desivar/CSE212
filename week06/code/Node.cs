using System.Collections;
using System.Collections.Generic;

public class BinarySearchTree : IEnumerable<int>
{
    private Node? _root;

    /// <summary>
    /// Inserts a new node into the BST.
    /// </summary>
    public void Insert(int value)
    {
        if (_root is null)
            _root = new Node(value);
        else
            _root.Insert(value);
    }

    /// <summary>
    /// Checks whether the BST contains a specific value.
    /// </summary>
    public bool Contains(int value)
    {
        return _root?.Contains(value) ?? false;
    }

    /// <summary>
    /// Yields all values in the BST in in-order traversal.
    /// </summary>
    public IEnumerator<int> GetEnumerator()
    {
        return TraverseForward(_root).GetEnumerator();
    }

    private IEnumerable<int> TraverseForward(Node? node)
    {
        if (node is not null)
        {
            foreach (var val in TraverseForward(node.Left)) yield return val;
            yield return node.Data;
            foreach (var val in TraverseForward(node.Right)) yield return val;
        }
    }

    /// <summary>
    /// Iterates over the values in reverse in-order traversal.
    /// </summary>
    public IEnumerable<int> Reverse()
    {
        return TraverseBackward(_root);
    }

    private IEnumerable<int> TraverseBackward(Node? node)
    {
        if (node is not null)
        {
            foreach (var val in TraverseBackward(node.Right)) yield return val;
            yield return node.Data;
            foreach (var val in TraverseBackward(node.Left)) yield return val;
        }
    }

    /// <summary>
    /// Returns the height of the BST.
    /// </summary>
    public int GetHeight()
    {
        return _root?.GetHeight() ?? 0;
    }

    /// <summary>
    /// Overrides ToString to display the BST contents in order.
    /// </summary>
    public override string ToString()
    {
        return "<Bst>{" + string.Join(", ", this) + "}";
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}

public class Node
{
    public int Data { get; set; }
    public Node? Right { get; private set; }
    public Node? Left { get; private set; }

    // Constructor to initialize the node
    public Node(int data)
    {
        this.Data = data;
        this.Right = null;
        this.Left = null;
    }

    /// <summary>
    /// Inserts a value into the binary search tree.
    /// </summary>
    /// <param name="value">The value to insert.</param>
    public void Insert(int value)
    {
        if (value < Data)
        {
            // Insert to the left
            if (Left is null)
                Left = new Node(value);
            else
                Left.Insert(value);
        }
        else if (value > Data)
        {
            // Insert to the right
            if (Right is null)
                Right = new Node(value);
            else
                Right.Insert(value);
        }
        // Duplicates are ignored
    }

    /// <summary>
    /// Checks whether the tree contains a specific value.
    /// </summary>
    /// <param name="value">The value to check for.</param>
    /// <returns>True if the value exists in the tree, false otherwise.</returns>
    public bool Contains(int value)
    {
        if (value == Data)
        {
            return true;
        }
        else if (value < Data)
        {
            return Left != null && Left.Contains(value);
        }
        else // value > Data
        {
            return Right != null && Right.Contains(value);
        }
    }

    /// <summary>
    /// Gets the height of the binary search tree.
    /// </summary>
    /// <returns>The height of the tree.</returns>
    public int GetHeight()
    {
        int leftHeight = Left?.GetHeight() ?? 0; // Recursively get left subtree height
        int rightHeight = Right?.GetHeight() ?? 0; // Recursively get right subtree height

        return Math.Max(leftHeight, rightHeight) + 1; // Height is the maximum of both subtrees plus 1
    }
}
