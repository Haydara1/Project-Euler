// Problem 16:
// What is the sum of the digits of the number 2^1000?

// 2^1000 contains 301 digits, it can be contained in a BigInteger.

using System.Numerics;

BigInteger output= 1;

int bound = 1000;

for (int i = 1; i <= bound; i++)
{
    output *= 2;
}

// Convert the output to string:
string s = output.ToString();

int sum = 0;

foreach (char c in s)
{
    sum += c - '0'; // Convert char to integer.
}

Console.WriteLine(sum);

// Answer: 1366
