// Problem 77:
// What is the first value which can be written as the sum of primes in over five thousand different ways?

long bound = 100000;

// Get primes:
bool[] primes = new bool[bound];

for(int i = 2; i < bound; i++) primes[i] = true;

for (int i = 2; i < Math.Sqrt(bound); i++)
{
    if (primes[i])
    {
        for(int j = i * i; j < bound; j += i) primes[j] = false;
    }
}

// Put the primes in a list for easier access:
List<int> primesList =new List<int>();

for (int j = 0; j < bound; j++)
{
    if(primes[j]) primesList.Add(j);
}

// We don't know the answer beforehand.
for (int target = 2; ; target++)
{
    int[] ways = new int[target + 1];
    ways[0] = 1;

    foreach (int prime in primesList)
    {
        if (prime > target) break;

        for (int i = prime; i <= target; i++)
        {
            ways[i] += ways[i - prime];
        }
    }

    if (ways[target] > 5000)
    {
        Console.WriteLine(target);
        break;
    }
}

// Answer: 71
