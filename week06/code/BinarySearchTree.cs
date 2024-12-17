using System.Collections;
using System.Collections.Generic;

public class BinarySearchTree : IEnumerable<int>
{
    private Node? _root;

    /// <summary>
    /// Insert a new node in the BST.
    /// </summary>
    public void Insert(int value)
    {
        if (_root is null)
            _root = new Node(value);
        else
            _root.Insert(value);
    }

    /// <summary>
    /// Check to see if the tree contains a certain value.
    /// </summary>
    public bool Contains(int value)
    {
        return _root?.Contains(value) ?? false;
    }

    /// <summary>
    /// GetEnumerator implementation for in-order traversal.
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
    /// Iterate backward through the BST (reverse in-order).
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
    /// Get the height of the tree.
    /// </summary>
    public int GetHeight()
    {
        return _root?.GetHeight() ?? 0;
    }

    /// <summary>
    /// Override ToString to display BST contents in order.
    /// </summary>
    public override string ToString()
    {
        return "<Bst>{" + string.Join(", ", this) + "}";
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}


    
    
