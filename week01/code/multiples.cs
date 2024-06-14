static int[] MultiplesOf(int startingNumber, int count)
{
    int[] multiples = new int[count];
    for (int i = 0; i < count; i++)
    {
        multiples[i] = startingNumber * (i + 1);
    }
    return multiples;
}
// The 'MultiplesOf' method returns an array of 'count' multiples of 'startingNumber'.
int startingNumber = 5;
int count = 5;
int[] result = MultiplesOf(startingNumber, count);
// The 'result' array will contain [5, 10, 15, 20, 25]

