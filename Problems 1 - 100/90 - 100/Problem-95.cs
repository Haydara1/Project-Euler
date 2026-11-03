// Problem 95:
// Find the smallest member of the longest amicable chain with no element exceeding one million.

long bound = 1000001;

// Generate a sieve:
long[] sumDivisors = new long[bound];

for (int i = 1; i < bound; i++)
{
    for (int j = 2 * i; j < bound; j += i)
    {
        sumDivisors[j] += i;
    }
}

// Define a function that calculates chains:
(int, long) Chain(long number)
{
    List<long> chain = new List<long>();

    while (true)
    {
        long nextNumber = sumDivisors[number];

        if (nextNumber >= bound) // We don't want the cycle.
        {
            return (0, 0);
        }

        if (chain.Contains(nextNumber)) // We have reached the end of the cycle.
        {
            number = nextNumber;
            break;
        }
        

        chain.Add(nextNumber);
        number = nextNumber;
    }

    int cycleStart = chain.IndexOf(number);

    List<long> cycle = chain.GetRange(
        cycleStart,
        chain.Count - cycleStart
    );

    return (cycle.Count, cycle.Min());
}


long output = 0;
long chainSize = 0;

// Check all numbers:
for (int i = 1; i < bound; i++)
{
    (int tempSize, long tempNumber) = Chain(i);
    
    if(tempSize > chainSize)
    {
        chainSize = tempSize;
        output = tempNumber;
    }
}


Console.WriteLine(output);

// Answer: 14316
