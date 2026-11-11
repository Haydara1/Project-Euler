// Problem 23:
// Find the sum of all the positive integers which cannot be written as the sum of two abundant numbers.

// Define a function to check whether a number is abundant or not:
bool IsAbundant(int number)
{
    int output = 0;

    for (int i = 1; i < number; i++)
    {
        if(number % i == 0) output += i;
    }
    
    return output > number;
}

// Define an array that stores abundant number;
int bound = 28123;
bool[] isAbundant = new bool[bound + 1];

for (int i = 0; i < isAbundant.Length; i++)
{
    if(IsAbundant(i)) isAbundant[i] = true;
    else isAbundant[i] = false;
}

// We can start from 24 as the question said:
int output = 0;

for (int i = 1; i <= 23; i++) output += i;


// Check all natural numbers:
for (int i = 24; i <= bound; i++)
{
    bool abundant = false;
    
    for (int j = 1; j < i; j++)
    {
        if(isAbundant[j] && isAbundant[i - j])
        {
            abundant = true;
            break;
        }
    }

    if (!abundant) output += i;
}

Console.WriteLine(output);

// Answer: 4179871
