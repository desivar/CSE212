public class Node
{
    public int Data { get; set; }
    public Node? Right { get; private set; }
    public Node? Left { get; private set; }

    public Node(int data)
    {
        Data = data;
    }

    public void Insert(int value)
    {
        // if value already exists then skip it
        if (value == Data)
            return;

        if (value < Data)
        {
            // Insert to the left
            if (Left is null)
                Left = new Node(value);
            else
                Left.Insert(value);
        }
        else
        {
            // Insert to the right
            if (Right is null)
                Right = new Node(value);
            else
                Right.Insert(value);
        }
    }

    public bool Contains(int value)
    {
        // if value matches current node's return true
        if (value == Data)
            return true;

        if (value < Data)
        {
            // Check value on the left
            return Left is null ? false : Left.Contains(value);
        }
        else
        {
            // Check value on the right
            return Right is null ? false : Right.Contains(value);
        }
    }

    public int GetHeight(int size = 0)
    {
        // Increase size by one
        size++;

        // variables to store size of subtree
        int leftHeight = 0, rightHeight = 0;

        // if no more leaves or children return current value
        if (Left == null && Right == null)
        {
            return size;
        }

        // get size of left subtree
        if (Left is not null)
        {
            leftHeight = Left.GetHeight(size);
        }

        // get size of right subtree
        if (Right is not null)
        {
            rightHeight = Right.GetHeight(size);
        }

        // return value of tallest branch
        return leftHeight > rightHeight ? leftHeight : rightHeight;
    }
}


    
        
