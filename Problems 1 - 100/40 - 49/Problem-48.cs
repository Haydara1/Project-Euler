// Problem 48:
// Find the last ten digits of the series, 1 + 2^2 + ... + 1000^1000


// We can use c# built in function.
using System.Numerics;

BigInteger number = BigInteger.Zero;

for (int i = 1; i <= 1000; i++)
{
    number += BigInteger.ModPow(i, i, BigInteger.Pow(10, 10));
}

Console.WriteLine(BigInteger.ModPow(number, 1, BigInteger.Pow(10, 10)));

// Answer: 9110846700
