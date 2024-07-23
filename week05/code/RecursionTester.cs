using System;

public static class RecursionTester
{
    /// <summary>
    /// Entry point for the Prove 8 tests
    /// </summary>
    public static void Run()
    {
        // Sample Test Cases (may not be comprehensive)
        Console.WriteLine("\n=========== PROBLEM 1 TESTS ===========");
        Console.WriteLine(SumSquaresRecursive(10)); // Expected output: 385
        Console.WriteLine(SumSquaresRecursive(100)); // Expected output: 338350
    }

    /// <summary>
    /// Recursive method to sum the squares of numbers from 1 to n
    /// </summary>
    /// <param name="n">The number up to which squares are summed</param>
    /// <returns>The sum of squares from 1 to n</returns>
    public static int SumSquaresRecursive(int n)
    {
        if (n <= 0)
            return 0;
        else
            return n * n + SumSquaresRecursive(n - 1);
    }
}

// To run the tests
RecursionTester.Run();

//
using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Console.WriteLine("\n=========== PROBLEM 3 TESTS ===========");
        Console.WriteLine(CountWaysToClimb(5)); // 13
        Console.WriteLine(CountWaysToClimb(20)); // 121415
        // Uncomment out the test below after implementing memoization. It won't work without it.
        Console.WriteLine(CountWaysToClimb(100));  // 180396380815100901214157639
    }

    static Dictionary<int, long> memo = new Dictionary<int, long>();

    static long CountWaysToClimb(int n)
    {
        if (n == 0) return 1;
        if (n < 0) return 0;
        if (memo.ContainsKey(n)) return memo[n];

        long ways = CountWaysToClimb(n - 1) + CountWaysToClimb(n - 2) + CountWaysToClimb(n - 3);
        memo[n] = ways;
        return ways;
    }
}

    





   
       

   

         

   
   
   
   
   
    



   
