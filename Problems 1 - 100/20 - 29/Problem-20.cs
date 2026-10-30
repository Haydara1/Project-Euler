// Problem 20:
// Find the sum of the digits in the number 100!.

// We will use BigInteger:

using System.Numerics;

// Define factorial:
BigInteger Factorial(int number)
{
    BigInteger output = 1;

    for (int i = 1; i <= number; i++)
    {
        output *= i;
    }
    
    return output;
}

BigInteger factorial = Factorial(100);

string s = factorial.ToString(); // Convert to String

int sum = 0;

// Calculate the sum of the digits:
foreach (char c in s)
{
    sum += c - '0';
}

Console.WriteLine(sum);

// Answer: 648
