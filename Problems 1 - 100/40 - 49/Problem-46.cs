// Problem 46:
// What is the smallest odd composite that cannot be written as the sum of a prime and twice a square?

/*
 * We are searching for n = p + 2*k^2 where p is prime
 * We can rewrite as p = n - 2*k^2, and test all values of odd n until we don't find a prime.
 */
 
// Generate all primes up until 10000:
long bound = 10000;
bool[] primes = new bool[bound + 1];

// Set all numbers to be true
for (int i = 0; i < primes.Length; i++) {
    primes[i] = true;
}
		
// Loop through a portion of the array (up to the square root of bound).
// If it's a prime, ensure all multiples of it are set to false.
for (int i = 2; i < Math.Sqrt(bound) + 1; i++)
{
    if (primes[i]) 
    {
        for (int j = (int)Math.Pow(i, 2); j <= bound; j += i)
        {
            primes[j] = false;
        }
    } 
}


// Define a function to check whether it can generate a prime:
bool Goldbachs(long number)
{
    for (int i = 0; i <= number; i++)
    {
        long p = number - 2 * i * i;
        
        if(p < 2) // If p is negative, we surpassed the bound.
        {
            return true;
        }

        if (primes[p]) // If it gives at least one prime, then the conjecture is true for n.
        {
            return false;
        }
    }

    return true;
}

long index = 5;

while (true)
{
    index += 2;
        
    if (primes[index])
    {
        continue;
    }

    if (Goldbachs(index))
    {
        break;
    }
    
}

Console.WriteLine(index);

// Answer: 5777
