// Problem 97:
// Find the last ten digits of this prime number.

// C# has a built-in function:

using System.Numerics;

BigInteger result = BigInteger.ModPow(2, 7830457,
    BigInteger.Pow(10, 10));
    
result *= 28433;
result += 1;

result = BigInteger.ModPow(result, 1, BigInteger.Pow(10, 10));

Console.WriteLine(result);

// Answer: 8739992577
