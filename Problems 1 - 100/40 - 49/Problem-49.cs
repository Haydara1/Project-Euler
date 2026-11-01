// Problem 49:
// (i) each of the three terms are prime, and,
// (ii) each of the 4-digit numbers are permutations of one another.
// 
// There are no arithmetic sequences made up of three 1-, 2-, or 3-digit primes,
// exhibiting this property, but there is one other 4-digit increasing sequence.
// 
// What 12-digit number do you form by concatenating the three terms in this sequence?

// Start by finding all primes until 10000
long bound = 10000;
bool[] primes = new bool[bound];

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

// Define a function to check whether three numbers are permutations
bool Permuation(int a, int b, int c)
{
    char[] A = a.ToString().ToCharArray(),
        B = b.ToString().ToCharArray(),
        C = c.ToString().ToCharArray();
    
    Array.Sort(A);
    Array.Sort(B);
    Array.Sort(C);

    for (int i = 0; i < A.Length; i++)
    {
        if (A[i] != B[i] || A[i] != C[i])
        {
            return false;
        }
    }

    return true;
}

int l = 0, m = 0, n = 0; 

for (int i = 1000; i < bound; i++)
{
    if (primes[i]) // Check if i is prime
    {
        for (int j = i + 1; j < bound; j++)
        {
            if (primes[j]) // Check if j is prime
            {
                int c = 2 * j - i; // Check if j + difference is prime
                
                if(c < bound && primes[c])
                {
                    if (Permuation(i, j, c))
                    {
                        l = i;
                        m = j;
                        n = c;

                        break;
                    }
                }
            }
        }
    }
}

Console.WriteLine(l + "" + m + "" + n);

// Answer: 296962999629
