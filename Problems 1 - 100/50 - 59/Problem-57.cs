// Problem 57:
// In the first one-thousand expansions, how many fractions contain a numerator with more digits than the denominator?

// Define a function to count the number of digits in a number:

using System.Numerics;

int DigitCount(BigInteger number)
{
    string s = number.ToString();
    return s.Length;
}

// It can be proved that for a fraction n / d we have n <- n + 2d and d <- n + d
BigInteger numerator = 3;
BigInteger denominator = 2;

int output = 0;

for (int i = 0; i < 1000; i++)
{
    BigInteger tem = numerator;

    numerator += denominator * 2;
    denominator += tem;

    if (DigitCount(numerator) > DigitCount(denominator))
    {
        output++;
    }
}

Console.WriteLine(output);

// Answer: 153
