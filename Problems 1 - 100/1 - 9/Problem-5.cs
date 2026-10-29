/* Problem 5:
 * 2520 is the smallest number that can be divided by each of the numbers from 1 to 10 without any remainder.
 * What is the smallest positive number that is evenly divisible by all of the numbers from 1 to 20?
 */
 
long output = 0;

// Prime numbers from 1 to 20 have to divide ouput,
// A propriety of prime numbers is that their lcm is equal to their product.

long start = 2 * 3 * 5 * 7 * 11 * 13 * 17 * 19;
long end = start * 4 * 6 * 8 * 9 * 10 * 12 * 14 * 15 * 16 * 18 * 20;

for (long i = start; i <= end; i++)
{
    if (IsDivisable(i))
    {
        output = i;
        break;
    }
}

Console.WriteLine(output);


// Create a function to check whether a number is divisible by all numbers from 1 to 20.
bool IsDivisable(long num)
{

    for (int j = 2; j <= 20; j++)
    {
        if (num % j != 0)
        {
            return false;
        }
    }
    
    return true;
}

// Answer: 232792560
