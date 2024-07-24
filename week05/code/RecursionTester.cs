using System;
using System.Collections.Generic;

public static class RecursionTester {
    /// <summary>
    /// Entry point for the Prove 8 tests
    /// </summary>
    public static void Run() {
        // Sample Test Cases (may not be comprehensive) 
        Console.WriteLine("\n=========== PROBLEM 1 TESTS ===========");
        Console.WriteLine(SumSquaresRecursive(10)); // 385
        Console.WriteLine(SumSquaresRecursive(100)); // 338350

        // Sample Test Cases (may not be comprehensive) 
        Console.WriteLine("\n=========== PROBLEM 2 TESTS ===========");
        PermutationsChoose("ABCD", 3);
        Console.WriteLine("---------");
        PermutationsChoose("ABCD", 2);
        Console.WriteLine("---------");
        PermutationsChoose("ABCD", 1);

        // Sample Test Cases (may not be comprehensive) 
        Console.WriteLine("\n=========== PROBLEM 3 TESTS ===========");
        Console.WriteLine(CountWaysToClimb(5)); // 13
        Console.WriteLine(CountWaysToClimb(20)); // 121415
        // Uncomment out the test below after implementing memoization.  It won't work without it.
        // TODO Problem 3
        // Console.WriteLine(CountWaysToClimb(100));  // 180396380815100901214157639
    }

    /// <summary>
    /// Recursively calculates the sum of squares of numbers from 1 to n
    /// </summary>
    /// <param name="n">The upper limit of the range</param>
    /// <returns>The sum of squares from 1 to n</returns>
    public static int SumSquaresRecursive(int n) {
        if (n <= 0) {
            return 0;
        }
        return n * n + SumSquaresRecursive(n - 1);
    }

    /// <summary>
    /// Generates all permutations of the given string of length k
    /// </summary>
    /// <param name="str">The input string</param>
    /// <param name="k">The length of permutations</param>
    public static void PermutationsChoose(string str, int k) {
        PermutationsChooseHelper(str, "", k);
    }

    private static void PermutationsChooseHelper(string str, string prefix, int k) {
        if (k == 0) {
            Console.WriteLine(prefix);
            return;
        }
        for (int i = 0; i < str.Length; i++) {
            PermutationsChooseHelper(str.Substring(0, i) + str.Substring(i + 1), prefix + str[i], k - 1);
        }
    }

    /// <summary>
    /// Calculates the number of ways to climb a staircase with n steps, 
    /// where you can take 1, 2, or 3 steps at a time
    /// </summary>
    /// <param name="n">The number of steps</param>
    /// <returns>The number of ways to climb the staircase</returns>
    public static int CountWaysToClimb(int n) {
        int[] memo = new int[n + 1];
        return CountWaysToClimbHelper(n, memo);
    }

    private static int CountWaysToClimbHelper(int n, int[] memo) {
        if (n < 0) {
            return 0;
        }
        if (n == 0) {
            return 1;
        }
        if (memo[n] == 0) {
            memo[n] = CountWaysToClimbHelper(n - 1, memo) + CountWaysToClimbHelper(n - 2, memo) + CountWaysToClimbHelper(n - 3, memo);
        }
        return memo[n];
    }
}

class Program {
    static void Main() {
        RecursionTester.Run();
    }
}



    





   
       

   

         

   
   
   
   
   
    



   
