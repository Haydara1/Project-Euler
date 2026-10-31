// Problem 34:
// Find the sum of all numbers which are equal to the sum of the factorial of their digits.

/* Similar to a previous problem, we should find an upper bound
 * Since the maximum number for a k-digit is k*9!, and the lowest k-digit number is 10^(k-1).
 * We find that 8 digit numbers are always more than the largest factorial sum.
 * So our upper bound is 7 * 9!
 */
 
// Define the factorial function:
long Factorial(long number)
{
    long output = 1;

    for (long i = 1; i <= number; i++)
    {
        output *= i;
    }
    
    return output;
}

// Define digit factorials so we don't have to calculate them a lot of times:
long[] factorials = new[]
{
    1, 1, 2, 6, 24, 120,
    Factorial(6), Factorial(7),
    Factorial(8), Factorial(9)
};
   
long bound = 7 * factorials[9];

// Define a function to check the sum of the factorials:
long SumFactorial(long number)
{
    string s = number.ToString();

    long output = 0;
    
    foreach (char c in s)
    {
        output += factorials[c - '0'];
    }

    return output;
}

long sum = 0;

// Check every number:
for (long i = 3; i <= bound; i++)
{
    if (i == SumFactorial(i))
    {
        sum += i;
    }
}

Console.WriteLine(sum);

// Answer: 40730
