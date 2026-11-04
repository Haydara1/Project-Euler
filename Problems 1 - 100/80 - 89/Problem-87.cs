// Problem 87:
// How many numbers below fifty million can be expressed as the sum of a prime square, prime cube, and prime fourth power?

long bound = 50000000;

// Generate primes such that p^2 < bound:

long primeBound = (int)Math.Sqrt(bound);

bool[] primes = new bool[primeBound];

for (int i = 2; i < primeBound; i++)
{
    primes[i] = true;
}

for (int i = 2; i <= Math.Sqrt(primeBound); i++)
{
    if (primes[i])
    {
        for (int j = i * i; j < primeBound; j += i)
        {
            primes[j] = false;
        }
    }
}

// Generate squares, cubes, and fourth powers:

List<long> squares = new List<long>();
List<long> cubes = new List<long>();
List<long> fourth = new List<long>();

for (int i = 0; i < primes.Length; i++)
{
    if (i * i > bound)
    {
        break;
    }
    
    if (primes[i])
    {
        squares.Add((long)i * i);

        if (i * i * i <= bound)
        {
            cubes.Add((long)i * i * i);
        }

        if (i * i * i * i <= bound)
        {
            fourth.Add((long)i * i * i * i);
        }
    }
}

// Use a hash set, so we don't have duplicates:
HashSet<long> numbers = new HashSet<long>();

foreach (long square in squares)
{
    foreach (long cube in cubes)
    {
        if (cube + square >= bound)
        {
            break;
        }
        
        foreach (long number in fourth)
        {
            if (cube + square + number >= bound)
            {
                break;
            }
            
            numbers.Add(number + square + cube);
        }
    }
}

Console.WriteLine(numbers.Count);

// Answer: 1097343
