// Problem 21:
//
// Let d(n) be defined as the sum of proper divisors of n (numbers less than n which divide evenly into n).
//
//  If d(a) = b and d(b) = a, where a ≠ b,
// then a and b are an amicable pair and each of a and b are called amicable numbers.
//
//  For example, the proper divisors of 220 are 1, 2, 4, 5, 10, 11, 20, 22, 44, 55 and 110;
// therefore d(220) = 284. The proper divisors of $284$ are $1, 2, 4, 71$ and 142; so d(284) = 220.
//
//  Evaluate the sum of all the amicable numbers under 10000.

int bound = 10000;


// Define a function that gets the sum of the divisors:
int SumDivisors(int n)
{
    int sum = 1; // Since one divides all numbers:

    for (int i = 2; i < n; i++)
    {
        if (n % i == 0)
        {
            sum += i;
        }
    }
    
    return sum;
}

long sum = 0;

for (int n = 2; n < bound; n++)
{
    int b = SumDivisors(n); // Get divisors

    if (b != n && b > 0 && b < bound) // Check hypothesis
    {
        if (SumDivisors(b) == n) // Check the pair.
        {
            sum += n;
        }
    }
}

Console.WriteLine(sum);

// Answer: 31626
