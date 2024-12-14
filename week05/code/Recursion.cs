using System;
using System.Collections.Generic;
using System.Linq;

public static class Recursion
{
    /// <summary>
    /// Finds all paths from the start (0, 0) to the end (2) in the given maze.
    /// </summary>
    /// <param name="results">List of all valid paths as strings.</param>
    /// <param name="maze">The maze object containing grid and dimensions.</param>
    /// <param name="currPath">The current path being traversed.</param>
    /// <param name="current">The current position in the maze.</param>
    public static void SolveMaze(List<string> results, Maze maze, List<(int, int)> currPath = null, (int, int)? current = null)
    {
        // Initialize path and starting position if not provided
        if (currPath == null)
            currPath = new List<(int, int)>();
        if (current == null)
            current = (0, 0);

        (int x, int y) = current.Value;

        // Check if we reached the end
        if (maze.IsEnd(x, y))
        {
            currPath.Add((x, y)); // Add the end point to the path
            results.Add(string.Join(" -> ", currPath.Select(pos => $"({pos.Item1}, {pos.Item2})")));
            currPath.RemoveAt(currPath.Count - 1); // Backtrack
            return;
        }

        // Add the current position to the path
        currPath.Add((x, y));

        // Try all four possible moves (right, down, left, up)
        (int dx, int dy)[] moves = { (1, 0), (0, 1), (-1, 0), (0, -1) };
        foreach ((int dx, int dy) in moves)
        {
            int newX = x + dx, newY = y + dy;
            if (maze.IsValidMove(currPath, newX, newY))
            {
                SolveMaze(results, maze, currPath, (newX, newY));
            }
        }

        // Backtrack: remove the current position from the path
        currPath.RemoveAt(currPath.Count - 1);
    }
}

public class Maze
{
    public int Width { get; }
    public int Height { get; }

    public readonly int[] Data;

    public Maze(int width, int height, int[] data)
    {
        this.Width = width;
        this.Height = height;
        this.Data = data;
    }

    /// <summary>
    /// Helper function to determine if the (x, y) position is at the end of the maze.
    /// </summary>
    public bool IsEnd(int x, int y)
    {
        return Data[y * Width + x] == 2;
    }

    /// <summary>
    /// Helper function to determine if the (x, y) position is a valid move.
    /// </summary>
    public bool IsValidMove(List<(int, int)> currPath, int x, int y)
    {
        // Can't go outside of the maze boundary (assume maze is a rectangle)
        if (x < 0 || x >= Width || y < 0 || y >= Height)
            return false;

        // Can't go through a wall
        if (Data[y * Width + x] == 0)
            return false;

        // Can't revisit a position in the same path
        if (currPath.Contains((x, y)))
            return false;

        return true;
    }
}

public static class Program
{
    public static void Main(string[] args)
    {
        // Define a sample maze
        int[] mazeData = {
            1, 1, 0, 0, 0,
            0, 1, 1, 0, 0,
            0, 0, 1, 1, 0,
            0, 0, 0, 1, 2,
        };

        // Create a Maze object with given dimensions and data
        Maze maze = new Maze(5, 4, mazeData);

        // List to hold all paths to the end
        List<string> results = new List<string>();

        // Solve the maze and print the results
        Recursion.SolveMaze(results, maze);

        Console.WriteLine("All paths to the end:");
        foreach (string path in results)
        {
            Console.WriteLine(path);
        }
    }
}
