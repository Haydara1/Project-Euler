// Problem 25:
// What is the index of the first term in the Fibonacci sequence to contain 1000 digits?

using System.Numerics;

BigInteger A = BigInteger.One;
BigInteger B = BigInteger.One;

// Define a function to return whether a number has more than a 1000 digits.
bool HasDigits(BigInteger n)
{
    return n.ToString().Length >= 1000;
}

int index = 2; // Since we already have the first two:

while (true)
{
    if (HasDigits(A))
    {
        break;
    }

    A += B;
    B = A - B;
    index++;

}

Console.WriteLine(index);

// Answer: 4782
