public class Node
{
    public int Data { get; set; }
    public Node? Right { get; private set; }
    public Node? Left { get; private set; }

    public Node(int data)
    {
        this.Data = data;
    }

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
        else
        {
            return;
        }
    }

    public bool Contains(int value)
    {
        if (value == Data)
        {
            return true;
        }
        else if (value < Data)
        {
            if (Left is null)
                return false;
            else
                return Left.Contains(value);
        }
        else if (value > Data)
        {
            if (Right is null)
                return false;
            else
                return Right.Contains(value);
        }
        return false;
    }

    public int GetHeight()
    {
        // TODO Start Problem 4
        var left = 1;
        var right = 1;
        var Left_aux = Left;
        var Right_aux = Right;

        while (Left_aux != null)
        {
            Left_aux = Left_aux.Left;
            left += 1;
        }
        while (Right_aux != null)
        {
            Right_aux = Right_aux.Right;
            right += 1;
        }

        if (left > right)
            return left;
        else if (right > left)
            return right;
        else
            return left;
    }
}
           
