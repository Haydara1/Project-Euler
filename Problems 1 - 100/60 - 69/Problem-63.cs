// Problem 63:
// How many n-digit positive integers exist which are also an nth power?

/*
 * This solution is based on two mathematical observations;
 * The first is that n^k is smaller having k digits means n^k < 10^k
 * thus, n < 10.
 * The second observation is that since 10^{k-1} <= n^k
 * we have k <= 1 / (1 - Log_10(n))
 */
int output = 0;

for (int number = 1; number <= 9; number++)
{
    for (int power = 1; ; power++)
    {
        double digits = power * Math.Log10(number);

        if (digits >= power - 1)
            output++;
        else
            break;
    }
}

Console.WriteLine(output);

// Answer: 49
