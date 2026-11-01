// Problem 32:
// Find the sum of all products whose multiplicand/multiplier/product identity can be written as a 1 through 9 pandigital.

/*
 * We are searching for a * b = c, such that digits(a) + digits(b) + digits(c) = 9
 */

// Define a function that checks if three numbers are pandigital:
bool Pandigital(long a, long b, long c)
{
    string s = a.ToString() + b.ToString() + c.ToString();

    if (s.Contains('0') || s.Length != 9) // We don't want the 0 digit.
    {
        return false;
    }

    char[] array = s.ToCharArray();
    
    Array.Sort(array);

    for (int i = 0; i < array.Length - 1; i++)
    {
        if (array[i] == array[i + 1])
        {
            return false;
        }
    }

    return true;
}

// Since we don't want the duplicate operations, we can impose that a ≤ b.

/*
 * Let's try reducing the search number:
 * 9 * 9 = 81
 * 9 * 99 = 891
 * 9 * 999 = 8991
 *
 * In the same way, we conclude that we only have to search through 1-digit * 4-digits and 2-digits*3-digits; 
 */

HashSet<long> products = new HashSet<long>(); // Since some products can be the same:

// 1-digit * 4-digits.
for (long a = 1; a < 10; a++)
{
    for (long b = 1000; b < 9999; b++)
    {
        var c = a * b;

        if (Pandigital(a, b, c))
        {
            products.Add(c);
        }
    }
}

// 2-digits * 3-digits.
for (long a = 10; a < 100; a++)
{
    for (long b = 100; b < 1000; b++)
    {
        var c = a * b;
        
        if (Pandigital(a, b, c))
        {
            products.Add(c);
        }
    }
}

long sum = 0;

foreach (long a in products)
{
    sum += a;
}

Console.WriteLine(sum);

// Answer: 45228
