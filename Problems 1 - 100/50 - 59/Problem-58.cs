// Problem 58:
// If one complete new layer is wrapped around the spiral above,
// a square spiral with side length  will be formed. If this process is continued,
// what is the side length of the square spiral for which the ratio of primes along both diagonals first falls below ?

// Start by generating primes:

long bound = 1000000000;

bool[] primes = new bool[bound];

for (int i = 2; i < primes.Length; i++)
{
    primes[i] = true;
}

for (int i = 2; i <= Math.Sqrt(bound); i++)
{
    if(primes[i])
    {
        for(int j = i * i; j  < bound; j += i)
        {
            primes[j] = false;
        }
    }
}

// Store the primes and non primes on the diagonals
long primesCount = 0;
long nonPrimesCount = 1; // We suppose that we start at one.

// Since we are sure that all odd squares lie on the botton right corner, we can start by generating those:
int index = 1;

do
{
    index += 2;

    nonPrimesCount += 4;

    long bottomRight = index * index;

    if (primes[bottomRight - index + 1]) primesCount++;
    if (primes[bottomRight - 2 * (index - 1)]) primesCount++;
    if (primes[bottomRight - 3 * (index - 1)]) primesCount++;
    
} while (10 * primesCount >= nonPrimesCount);

Console.WriteLine(index);

// Answer: 26241
