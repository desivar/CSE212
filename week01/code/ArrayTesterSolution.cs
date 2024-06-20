using System;
//The function needs 2 parameters and return an array of double
//The function will return an array of double that contains the first numMultiples multiples of startNumber
public static class ArrayUtils
{
    public static double[] MultiplesOf(double startNumber, int numMultiples)
    {
        if (numMultiples <= 0)
        {
            throw new ArgumentException("Number of multiples must be positive.");
        }

        double[] multiples = new double[numMultiples];
        for (int i = 0; i < numMultiples; i++)
        {
            multiples[i] = startNumber * (i + 1);
        }

        return multiples;
    }

    // Other utility functions (like RotateListRight) can be defined here.
}

// Example usage:
public static class ArraysTesterSolution
{
    public static void Run()
    {
        double[] multiples = ArrayUtils.MultiplesOf(7, 5);
        Console.WriteLine($"Multiples of 7: {{ {string.Join(", ", multiples)} }}");

        multiples = ArrayUtils.MultiplesOf(1.5, 10);
        Console.WriteLine($"Multiples of 1.5: {{ {string.Join(", ", multiples)} }}");

        multiples = ArrayUtils.MultiplesOf(-2, 10);
        Console.WriteLine($"Multiples of -2: {{ {string.Join(", ", multiples)} }}");
    }
}
