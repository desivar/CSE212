using System.Collections.Generic;

public static class Recursion
{
    // 1. SumSquaresRecursive
    public static int SumSquaresRecursive(int n)
    {
        if (n <= 1)
            return n * n;
        return n * n + SumSquaresRecursive(n - 1);
    }

    // 2. PermutationsChoose
    public static void PermutationsChoose(List<string> results, string str, int length, string prefix = "")
    {
        if (prefix.Length == length)
        {
            results.Add(prefix);
            return;
        }

        for (int i = 0; i < str.Length; i++)
        {
            string newPrefix = prefix + str[i];
            string remaining = str.Remove(i, 1);
            PermutationsChoose(results, remaining, length, newPrefix);
        }
    }

    // 3. CountWaysToClimb
    public static decimal CountWaysToClimb(int steps, Dictionary<int, decimal> memo = null)
    {
        if (memo == null)
            memo = new Dictionary<int, decimal>();

        if (steps == 0)
            return 1;
        if (steps < 0)
            return 0;
        if (memo.ContainsKey(steps))
            return memo[steps];

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
            results.Add(str);
            return;
        }

        if (str[index] == '*')
        {
            WildcardBinary(str.Substring(0, index) + "0" + str.Substring(index + 1), results, index + 1);
            WildcardBinary(str.Substring(0, index) + "1" + str.Substring(index + 1), results, index + 1);
        }
        else
        {
            WildcardBinary(str, results, index + 1);
        }
    }

    // 5. SolveMaze
    public static void SolveMaze(List<string> results, Maze maze, List<(int, int)> path = null, (int, int)? current = null)
    {
        if (path == null)
            path = new List<(int, int)>();

        if (current == null)
            current = (0, 0);

        (int row, int col) = current.Value;

        // Bounds check
        if (row < 0 || col < 0 || row >= maze.Rows || col >= maze.Cols || maze.Grid[row, col] == 0)
            return;

        // Goal reached
        if (maze.Grid[row, col] == 2)
        {
            path.Add(current.Value);
            results.Add(path.AsString());
            path.RemoveAt(path.Count - 1);
            return;
        }

        // Mark as visited
        maze.Grid[row, col] = 0;
        path.Add(current.Value);

        // Explore neighbors
        SolveMaze(results, maze, path, (row + 1, col)); // Down
        SolveMaze(results, maze, path, (row - 1, col)); // Up
        SolveMaze(results, maze, path, (row, col + 1)); // Right
        SolveMaze(results, maze, path, (row, col - 1)); // Left

        // Backtrack
        path.RemoveAt(path.Count - 1);
        maze.Grid[row, col] = 1;
    }
}

   
   
       
    
       
