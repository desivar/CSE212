using System;
using System.Collections.Generic;

partial class Program
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


    





   
       

   

         

   
   
   
   
   
    



   
