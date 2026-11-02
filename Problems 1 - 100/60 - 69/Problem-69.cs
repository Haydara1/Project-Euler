// Problem 69:
// Find the value of n ≤ 1000000 for which n/phi(n) is a maximum.

// We have the formula that phi(n) = n * product of (1 - 1/p) where p is a prime number that divides n
// Thus we have n/phi(n) = product of (p / p - 1)
// We want to maximize this product, so we just multiply the smallest distinct prime numbers before exceding one million

int bound = 1000000;

// Generate primes:
bool[] primes = new bool[bound];

primes[0] = false;
primes[1] = false;

for (int i = 2; i < bound; i++)
{
    primes[i] = true;
}

for (int i = 2; i < Math.Sqrt(bound); i++)
{
    if (primes[i])
    {
        for (int j = i * i; j < bound; j += i)
        {
            primes[j] = false;
        }
    }
}

// Multiply primes until they exceed the bound
int product = 1;

for(int i = 1; i < bound; i++)
{
    if (primes[i] && product * i <= bound)
    {
        product *= i;
    }

    if (product * i > bound)
    {
        break;
    }
}

Console.WriteLine(product);

// Answer: 510510
