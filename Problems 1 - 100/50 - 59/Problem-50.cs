// Problem 50:
// Which prime, below one-million, can be written as the sum of the most consecutive primes? 

// Generate primes less than one million:
int bound = 1000000;
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

// Generate a prefix sequence to check sum of primes
List<int> sum = new List<int>();
sum.Add(0);

for (int i = 2; i < bound; i++)
{
    if (sum.Last() >= bound)
    {
        sum.RemoveAt(sum.Count - 1);
        break;
    }
    
    if(primes[i])
    {
        sum.Add(i + sum.Last());
    }
}

int output = 0;
bool breakLoop = false;

// Try largest sums to smallest:
for(int i = sum.Count - 1; i >= 0; i--)
{
    
    for(int j = 0; j < i; j++)
    {
        if (primes[sum[i] - sum[j]])
        {
            output = sum[i] - sum[j];
            breakLoop = true;
            break;
        }
    }

    if (breakLoop)
    {
        break;
    }
}

Console.WriteLine(output);

// Answer: 997651
