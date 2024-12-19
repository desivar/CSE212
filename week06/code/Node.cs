public class Node {
    public int Data { get; set; }
    public Node? Right { get; private set; }
    public Node? Left { get; private set; }

    public Node(int data) {
        this.Data = data;
    }

    public void Insert(int value) {
        // if value already exists the skip it
        if (value == Data)
            return;

        if (value < Data) {
            // Insert to the left
            if (Left is null)
                Left = new Node(value);
            else
                Left.Insert(value);
        }
        else {
            // Insert to the right
            if (Right is null)
                Right = new Node(value);
            else
                Right.Insert(value);
        }
    }

    public bool Contains(int value) {
        // TODO Start Problem 2
        
        // if value matches current node's return true
        if (value == Data) 
            return true;

        if (value < Data) {
            // Check value on the left
            return Left is null ? false : Left.Contains(value);
            
        }
        else {
            // Check value ion the right
            return Right is null ? false : Right.Contains(value);
        }
    }

    public int GetHeight(int size = 0) {
        // TODO Start Problem 4
        
        // Increase size by one
        size++;

        // variables to store size of subtree
        int leftHeigh = 0, rightHeigh = 0;

        // if no more leaves or children return current value
        if(Left == null && Right == null)
        {
            return size;
        }
       
        // get size of left subtree
        if(Left is not null) {
            leftHeigh = Left.GetHeight(size);
        }

        // get size of right subtree
        if(Right is not null) {
            rightHeigh = Right.GetHeight(size);
        }

        // return value of tallest branch
        if(leftHeigh > rightHeigh) 
            return leftHeigh;
        else 
            return rightHeigh;
       
    }
}
