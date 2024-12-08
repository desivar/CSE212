using System.Collections.Generic;

public static class Recursion
{
    // 1. SumSquaresRecursive
    public static int SumSquaresRecursive(int n)
    {
        if (n <= 1)
            return n * n; // Base case: square of 1 or 0
        return n * n + SumSquaresRecursive(n - 1); // Recursive case
    }

    // 2. PermutationsChoose
    public static void PermutationsChoose(List<string> results, string str, int length, string prefix = "")
    {
        if (prefix.Length == length)
        {
            results.Add(prefix); // Add valid permutation to results
            return;
        }

        for (int i = 0; i < str.Length; i++)
        {
            string newPrefix = prefix + str[i]; // Add current character to the prefix
            string remaining = str.Remove(i, 1); // Remove the used character
            PermutationsChoose(results, remaining, length, newPrefix); // Recurse with updated values
        }
    }

    // 3. CountWaysToClimb
    public static decimal CountWaysToClimb(int steps, Dictionary<int, decimal> memo = null)
    {
        if (memo == null)
            memo = new Dictionary<int, decimal>(); // Initialize memoization dictionary

        if (steps == 0)
            return 1; // Base case: one way to stay at the ground
        if (steps < 0)
            return 0; // Base case: no way to climb negative steps
        if (memo.ContainsKey(steps))
            return memo[steps]; // Return cached result if available

        // Recursively calculate the number of ways
        memo[steps] = CountWaysToClimb(steps - 1, memo) +
                      CountWaysToClimb(steps - 2, memo) +
                      CountWaysToClimb(steps - 3, memo);
        return memo[steps];
    }

    // 4. WildcardBinary
    public static void WildcardBinary(string str, List<string> results, int index = 0)
    {
        if (index == str.Length)
        {
            results.Add(str); // Add completed string to results
            return;
        }

        if (str[index] == '*') // If wildcard found
        {
            // Replace wildcard with '0' and '1' and recurse
            WildcardBinary(str.Substring(0, index) + "0" + str.Substring(index + 1), results, index + 1);
            WildcardBinary(str.Substring(0, index) + "1" + str.Substring(index + 1), results, index + 1);
        }
        else
        {
            WildcardBinary(str, results, index + 1); // Continue with non-wildcard character
        }
    }

    // 5. SolveMaze
    public static void SolveMaze(List<string> results, Maze maze, List<(int, int)> path = null, (int, int)? current = null)
    {
        if (path == null)
            path = new List<(int, int)>();

        if (current == null)
            current = (0, 0); // Start from the top-left corner

        (int row, int col) = current.Value;

        // Bounds check
        if (row < 0 || col < 0 || row >= maze.Rows || col >= maze.Cols || maze.Grid[row, col] == 0)
            return;

        // Goal check
        if (maze.Grid[row, col] == 2)
        {
            path.Add(current.Value);
            results.Add(path.AsString()); // Add path as string representation
            path.RemoveAt(path.Count - 1);
            return;
        }

        // Mark cell as visited
        maze.Grid[row, col] = 0;
        path.Add(current.Value);

        // Explore neighbors
        SolveMaze(results, maze, path, (row + 1, col)); // Down
        SolveMaze(results, maze, path, (row - 1, col)); // Up
        SolveMaze(results, maze, path, (row, col + 1)); // Right
        SolveMaze(results, maze, path, (row, col - 1)); // Left

        // Backtrack: unmark visited cell
        path.RemoveAt(path.Count - 1);
        maze.Grid[row, col] = 1;
    }
}


    
       

      

       
       
