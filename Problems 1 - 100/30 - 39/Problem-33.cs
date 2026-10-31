// Problem 33:
// There are exactly four non-trivial examples of this type of fraction,
// less than one in value, and containing two digits in the numerator and denominator.
//
//  If the product of these four fractions is given in its lowest common terms, find the value of the denominator.


// We initiate with one since we are going to multiply.
long outputNumerator = 1;
long outputDenominator = 1;

// The fractions can be written like this:
// 10a + b / (10c + d)

for (int ab = 10; ab <= 99; ab++)
{
    for (int cd = 10; cd < ab; cd++)
    {
        string numerator = ab.ToString();
        string denominator = cd.ToString();

        if (numerator[1] == '0' && denominator[1] == '0') // Remove trivial case
        {
            continue;
        }
        
        // We have to check the four cases of equality:

        if (numerator[0] == denominator[0]) // We simplify by a and c
        {
            // We want to check here if ab/cd = b/d
            if (ab * (denominator[1] - '0') == cd * (numerator[1] - '0'))
            {
                outputNumerator *= ab;
                outputDenominator *= cd;
                
            }
        }
        if (numerator[0] == denominator[1]) // We simplify by a and d
        {
            // We want to check here if ab/cd = b/c
            if (ab * (denominator[0] - '0') == cd * (numerator[1] - '0'))
            {
                outputNumerator *= ab;
                outputDenominator *= cd;
            }
        }
        if (numerator[1] == denominator[1]) // We simplify by b and d
        {
            // We want to check here if ab/cd = a/c
            if (ab * (denominator[0] - '0') == cd * (numerator[0] - '0'))
            {
                outputNumerator *= ab;
                outputDenominator *= cd;
            }
        }
        if (numerator[1] == denominator[0]) // We simplify by b and c
        {
            // We want to check here if ab/cd = a/d
            if (ab * (denominator[1] - '0') == cd * (numerator[0] - '0'))
            {
                outputNumerator *= ab;
                outputDenominator *= cd;
            }
        }
    }
}

// Define GCD to simplify the fraction
long GCD(long a, long b)
{
    while (a != 0 && b != 0)
    {
        if (a > b)
            a %= b;
        else
            b %= a;
    }

    return a + b;
}

// I have inversed numerator and denominator in the loop, so I can simply invert them here.

// Here we have our fraction, now we have to simplify it:
long output = outputNumerator / GCD(outputNumerator, outputDenominator);

Console.WriteLine(output);

// Answer: 100
