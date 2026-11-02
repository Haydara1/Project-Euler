// Problem 76:
// How many different ways can one hundred be written as a sum of at least two positive integers?

long[] ways = new long[101]; // ways[i] represents the number of ways to get i.

ways[0] = 1;

for (int i = 1; i < 100; i++)
{
    for (int j = i; j <= 100; j++)
    {
        ways[j] +=  ways[j - i];
    }
}

Console.WriteLine(ways[100]);

// Answer: 190569291
