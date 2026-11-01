// Problem 45: 
// Find the next triangle number that is also pentagonal and hexagonal.

// Define a function to check whether a number is triangular:
bool IsTriangular(long number)
{
    long discriminant = 8 * number + 1;
    long root = (long)Math.Sqrt(discriminant);

    return root * root == discriminant;
}

// Define a function to check whether a number is pentagonal:
bool IsPentagonal(long number)
{
    long discriminant = 24 * number + 1;
    long root = (long)Math.Sqrt(discriminant);
    
    return root * root == discriminant && (1 + root) % 6 == 0;
}

// Generate hexagonal numbers, and check whether they are triangular and pentagonal.
// We want the next number after 143, so we can start at 144.

long index = 144;

long output = 0;

while (true)
{
    // Generate hexagonal number
    long hexagonal = index * (2 * index - 1);

    if (IsTriangular(hexagonal) && IsPentagonal(hexagonal))
    {
        output = hexagonal;
        break;
    }

    index++;
}

Console.WriteLine(output);
