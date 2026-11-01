// Problem 53:
// How many, not necessarily distinct, values of  r choose n for 1 ≤ n ≤ 100 , are greater than one-million?

using System.Numerics;

long bound = 1000000;

// Define factorial function
BigInteger Factorial(long number)
{
    if (number == 0)
    {
        return 1;
    }
    
    BigInteger output = 1;
    
    for(int i = 1; i <= number; i++)
    {
        output *= i;
    }
    return output;
}

// Define choose function:
BigInteger Choose(long n, long r)
{
    return Factorial(n) / (Factorial(r) * Factorial(n - r));
}

int output = 0;

for (int n = 1; n <= 100; n++)
{
    for (int r = 0; r < n; r++)
    {
        if (Choose(n, r) >= bound)
        {
            output++;
        }
    }
}

Console.WriteLine(output);

// Answer: 4075
