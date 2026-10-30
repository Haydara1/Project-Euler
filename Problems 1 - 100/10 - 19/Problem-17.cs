// Problem 17:
//
// If the numbers 1 to 5 are written out in words: one, two, three, four, five, then there are 19 letters used in total.
//
//  If all the numbers from  1 to one thousand inclusive were written out in words, how many letters would be used?

// Define functions that count numbers depending on its size:

// Returns the number of letter in each unit.
int Units(int n)
{
    switch (n)
    {
        case 1:
            return 3;
        case 2:
            return 3;
        case 3:
            return 5;
        case 4:
            return 4;
        case 5:
            return 4;
        case 6:
            return 3;
        case 7:
            return 5;
        case 8:
            return 5;
        case 9:
            return 4;
        
        default:
            return 0;
    }
}

int Tens(int n)
{
    if (n < 10)
    {
        return Units(n);
    }
    
    if (n < 20)
    {
        switch (n)
        {
            case 10:
                return 3;
            case 11:
                return 6;
            case 12:
                return 6;
            case 13: // thirteen
                return 8;
            case 14:
                return 8;
            case 15: // fifteen
                return 7;
            case 16:
                return 7;
            case 17:
                return 9;
            case 18: // eighteen
                return 8;
            case 19: // nineteen
                return 8;
        }
    }
    
    /*
     * We can notice that tens above twenty are just the tens plus units
     * Also 20, 30, 80, 90 have the same letters count.
     * Seventy has 7.
     * 40, 50 and 60 have 5
     */

    if (n >= 40 && n <= 69)
    {
        return 5 + Units(n % 10);
    }
    else if (n <= 79 && n >= 70)
    {
        return 7 + Units(n % 10);
    }
    
    return 6 +  Units(n % 10);
}

int Hundreds(int n)
{
    int output = 7; // Hundred has 7.
    
    // Determine which hundred is it:
    output += Units(n / 100);
    
    // Determine if there is an "and":
    if (n % 100 != 0)
    {
        output += 3;
    }

    // Add the tens and units:

    output += Tens(n % 100);
    
    return output;
}

int sum = 0;

// Calculate the sum of units and tens:
for (int i = 1; i < 100; i++)
{
    sum += Tens(i);
}

// Calculate the sum of hundreds:
for (int i = 100; i < 1000; i++)
{
    sum += Hundreds(i);
}

// Add one thousand:
sum += 3 + 8;

Console.WriteLine(sum);

// Answer: 21124
