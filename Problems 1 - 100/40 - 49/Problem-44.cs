// Problem 44:
// Find the pair of pentagonal numbers, P_i and P_j,
// for which their sum and difference are pentagonal and D = |P_i - P_j|  is minimised;
// what is the value of D.

// Define a function to generate the nth pentagonal number
long Pentagonal(long n)
{
    return n * (3 * n - 1) / 2;
}

// Define a function to check whether a number is pentagonal
bool IsPentagonal(long number)
{
    long discriminant = 1 + 24 * number;
    long root = (long)Math.Sqrt(discriminant);

    return root * root == discriminant &&
           (1 + root) % 6 == 0;
}

long minDifference = long.MaxValue;

for (long j = 2; ; j++)
{
    long pj = Pentagonal(j);

    for (long k = j - 1; k >= 1; k--)
    {
        long pk = Pentagonal(k);
        long difference = pj - pk;

        // Smaller k means a larger difference.
        if (difference >= minDifference)
            break;

        long sum = pj + pk;

        if (IsPentagonal(sum) && IsPentagonal(difference))
        {
            minDifference = difference;
        }
    }

    // The gap between consecutive pentagonal numbers is 3j - 2.
    // If even this gap cannot improve the answer, we can stop.
    if (3 * j - 2 >= minDifference)
        break;
}


Console.WriteLine(minDifference);

// Answer: 5482660
