// Problem 24:
// What is the millionth lexicographic permutation of the digits 0, 1, 2, 3, 4, 5, 6, 7, 8 and 9?

// The first permutation is 0123456789
// If the first digit is 0 then we have 9! permutations = 362880
// If the first digit is 1 then we also have another 362880 permutations.
// If the first digit is 2, we have more than a million so the first digit must be two.
// We can implement the continuity of this algorithm


// Initialize array.
bool[] availableDigits = new bool[10];
int availableDigitsNum = 10;

for (int i = 0; i < 10; i++)
{
    availableDigits[i] = true;
}

// Define factorial function:
long Factorial(int number)
{
    long product = 1;
    
    for (int i = 1; i <= number; i++)
    {
        product *= i;
    }
    
    return product;
}

string output = "";
long objectif = 999999; 

while (availableDigitsNum > 0)
{
    // Calculate factorial just once by iteration
    long blockSize = Factorial(availableDigitsNum - 1);

    long index = objectif / blockSize;
    objectif %= blockSize;

    int counter = 0;

    for (int j = 0; j < 10; j++)
    {
        if (availableDigits[j])
        {
            if (counter == index)
            {
                output += j.ToString();
                availableDigits[j] = false;
                break;
            }

            counter++;
        }
    }

    availableDigitsNum--;
}

Console.WriteLine(output);

// Answer: 2783915460
