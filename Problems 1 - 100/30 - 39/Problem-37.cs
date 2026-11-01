// Problem 37:
// Find the sum of the only eleven primes that are both truncatable from left to right and right to left.

// Generate primes from 1 to 1 million:
long bound = 1000000;

bool[] primes = new bool[bound];

for (int i = 2; i < bound; i++)
{
    primes[i] = true;
}

for(int i = 2; i <= Math.Sqrt(bound); i++)
{
    if (primes[i])
    {
        for (int j = i * i; j < bound; j += i)
        {
            primes[j] = false;
        }
    }
}

// Define a function to check whether a number is truncatable
bool IsRightTruncatable(string number)
{
    
    if(number.Length == 1)
    {
        return primes[Convert.ToInt32(number)];
    }
    
    return IsRightTruncatable(number.Substring(0, number.Length - 1)) 
           && primes[Convert.ToInt32(number)];
}

bool IsLeftTruncatable(string number)
{
    
    if(number.Length == 1)
    {
        return primes[Convert.ToInt32(number)];
    }
    
    return IsLeftTruncatable(number.Substring(1, number.Length - 1)) 
           && primes[Convert.ToInt32(number)];
}


// We are looking for 11 numbers
int numTruncatable = 11;
int sum = 0;

for (int i = 10; i <= bound; i++) // We start from 10 since digits don't count.
{
    if (primes[i])
    {
        if (IsLeftTruncatable(i.ToString()) 
            && IsRightTruncatable(i.ToString()))
        {
            sum += i;
            numTruncatable--;

            if (numTruncatable == 0)
            {
                break;
            }
        }
    }
}

Console.WriteLine(sum);

// Answer: 748317
