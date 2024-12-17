public static class Trees
{
    /// <summary>
    /// Given a sorted list, create a balanced Binary Search Tree (BST).
    /// If the values in the sorted list were inserted sequentially into the BST,
    /// it would resemble a linked list (unbalanced). To get a balanced BST, 
    /// the InsertMiddle function is used to add the middle element first,
    /// and then recursively add elements from the left and right halves of the list.
    /// </summary>
    /// <param name="sortedNumbers">A sorted array of integers.</param>
    /// <returns>A balanced Binary Search Tree (BST).</returns>
    public static BinarySearchTree CreateTreeFromSortedList(int[] sortedNumbers)
    {
        // Handle edge case: empty or null array
        if (sortedNumbers == null || sortedNumbers.Length == 0)
            return new BinarySearchTree();

        var bst = new BinarySearchTree(); // Create an empty BST
        InsertMiddle(sortedNumbers, 0, sortedNumbers.Length - 1, bst);
        return bst;
    }

    /// <summary>
    /// Recursively inserts the middle element of the given range of the sorted array
    /// into the BST, ensuring the tree remains balanced.
    /// </summary>
    /// <param name="sortedNumbers">The sorted array of integers.</param>
    /// <param name="first">The starting index of the range.</param>
    /// <param name="last">The ending index of the range.</param>
    /// <param name="bst">The Binary Search Tree (BST) to populate.</param>
    private static void InsertMiddle(int[] sortedNumbers, int first, int last, BinarySearchTree bst)
    {
        // Base case: No more elements to process
        if (first > last)
            return;

        // Calculate the middle index safely to avoid overflow
        int middle = first + (last - first) / 2;

        // Insert the middle element into the BST
        bst.Insert(sortedNumbers[middle]);

        // Recursively insert elements from the left and right halves
        InsertMiddle(sortedNumbers, first, middle - 1, bst);
        InsertMiddle(sortedNumbers, middle + 1, last, bst);
    }
}

   
