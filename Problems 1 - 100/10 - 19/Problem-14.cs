// Problem 14:
// The following iterative sequence is defined for the set of positive integers:
//
// n -> n / 2 (n is even)
// n -> 3 * n + 1 (n is odd)
//
// Although it has not been proved yet (Collatz Problem), it is thought that all starting numbers finish at .
//
// Which starting number, under one million, produces the longest chain?
//
// NOTE: Once the chain starts the terms are allowed to go above one million.

// Define a function that returns the collatz sequence chain size:
long Collatz(long input)
{
    long index = 1; // the first number is counted.

    while (input != 1)
    {
        if (input % 2 == 0)
        {
            input /= 2;
        }
        else
        {
            input = 3 * input + 1;
        }

        index++;
    }

    return index;
}

long chain = 0;
long output = 0;

long bound = 1000000;

// Calculate chain sizes for numbers going from one to two millions.
for (int i = 2; i <= bound; i++)
{
    long collatz = Collatz(i);
    if(collatz > chain)
    {
        chain = collatz;
        output = i;
    }
}

Console.WriteLine(output);

// Answer: 837799
