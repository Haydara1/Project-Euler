// Problem 47:
// Find the first four consecutive integers to have four distinct prime factors each.
// What is the first of these numbers?

// Generate primes up until a certain bound
long bound = 150000;
bool[] primes = new bool[bound];

for (int i = 2; i < bound; i++)
{
    primes[i] = true;
}

primes[0] = false;
primes[1] = false;

for (int i = 2; i <= Math.Sqrt(bound); i++)
{
    if (primes[i])
    {
        for (int j = i * i; j < bound; j += i)
        {
            primes[j] = false;
        }
    }
}

// Define a function to check whether a number has for distinct prime factors:
// By using Euclid's Lemma, we only have to find the primes that divide the number
bool HasFourPrimes(long number)
{
    int output = 0;

    for (int i = 2; i * i <= number; i++)
    {
        if (primes[i] && number % i == 0)
        {
            output++;

            while (number % i == 0)
            {
                number /= i;
            }
        }
    }

    if (number > 1)
    {
        output++;
    }

    return output == 4;
}

int firstNumber = 1;

for (int i = 1; i <= bound - 4; i++)
{
    if (primes[i] || primes[i + 1] || primes[i + 2] || primes[i + 3]) // Primes only have one factor
    {
        continue;
    }

    if (HasFourPrimes(i) &&
        HasFourPrimes(i + 1) &&
        HasFourPrimes(i + 2) &&
        HasFourPrimes(i + 3))
    {
        firstNumber = i;
        break;
    }
}

Console.WriteLine(firstNumber);

// Answer: 134043
