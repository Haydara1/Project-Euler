// Problem 80:
// For the first one hundred natural numbers,
// find the total of the digital sums of the first one hundred decimal digits for all the irrational square roots.

using System.Numerics;

BigInteger sum = BigInteger.Zero;

int[] squares = { 4, 9, 16, 25, 36, 49, 64, 81 };

/*
 * For n = 2: we are searching for the first 100 digits of sqrt(2)
 * which is the same as floor(sqrt(2) * 10^100) = floor(sqrt(2 * 10^200))
 */

// We don't take a hundred since it is a square
for (int i = 2; i < 100; i++)
{
    if (squares.Contains(i))
    {
        continue;
    }
    
    BigInteger x = BigInteger.Pow(10, 200) * i;

    BigInteger root = Newton(x);
    
    string s = root.ToString();
    
    // Get the sum of the decimal digits:
    sum += SumDigits(s.Substring(0, 100));
}

// Define newtons method to find the square root:
BigInteger Newton(BigInteger n)
{
    BigInteger x = n;
    BigInteger y = (x + 1) / 2;

    while (y < x)
    {
        x = y;
        y = (x + n / x) / 2;
    }

    return x;
}

// Define a function to return the sum of the digits
int SumDigits(string s)
{
    int sum = 0;
    
    foreach(char c in s)
    {
        sum += c - '0';
    }
    
    return sum;
}

Console.WriteLine(sum);

// Answer: 40886
