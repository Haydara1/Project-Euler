// Problem 35:
// How many circular primes are there below one million?

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

// Since we are checking circular digits, we may notice that we can't have a single even digit.
// Otherwise, one of the permutations will be divisible by 2.
// The same goes for the digit five.

// Define a function to check whether a number contains an even number:
bool ContainsEven(long number)
{
    string s = number.ToString();

    string evenDigits = "024568";

    foreach (char c in evenDigits)
    {
        if (s.Contains(c))
        {
            return true;
        }
    }

    return false;
}

// Define a function to check whether a number is circular:
bool IsCircular(long number)
{
    string s = number.ToString();

    for (int i = 0; i < s.Length - 1; i++)
    {
        s = s.Substring(1, s.Length - 1) + s[0]; // We only need to move the first character to the last position.

        if (!primes[Convert.ToInt32(s)])
        {
            return false;
        }
    }

    return true;
}

int output = 2; // Since we removed 2 and 5 in our earlier function.

for (int i = 0; i < bound; i++)
{
    if (primes[i] && !ContainsEven(i) && IsCircular(i))
    {
        output++;
    }
}

Console.WriteLine(output);

// Answer: 
