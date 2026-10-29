// Problem 10:
// The sum of the primes below 10 is 2 + 3 + 5 + 7 = 17.
//
// Find the sum of all the primes below two million.

List<long> primes = new List<long>(); // Store prime
primes.Add(2);

long sum = 2;

int index = 3;

while (index < 2000000)
{
    if (IsPrime(index))
    {
        primes.Add(index);
        sum += index;
    }
    
    index++;
}

// Create a function to check if a number is prime.
bool IsPrime(long number)
{
    int sqrt = (int)Math.Sqrt(number);
    
    foreach (long i in primes)
    {
        if (i > sqrt)
        {
            return true; // No need to check more than the square root.
        }
        
        if (number % i == 0)
        {
            return false;
        }
    }
    
    return true;
}

Console.WriteLine(sum);

// Answer: 142913828922
