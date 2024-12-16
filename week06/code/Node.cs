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

       

   
      
