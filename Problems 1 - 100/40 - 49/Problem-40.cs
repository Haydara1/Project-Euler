// Problem 40:
// If d_n represents the nth digit of the fractional part, find the value of the following expression.
// d_1 * d_10 * d_100 * d_1000 * d_10000 * d_100000 * d_1000000

// Define a function that gets the digit at the nth position:
int GetDigit(int number)
{
    int digits = 1;       // Number of digits per integer
    int numbers = 9;      // Number of digits in the current group
    int start = 1;        // First integer in the current group

    // Find the group containing the target position
    while (number > numbers * digits)
    {
        number -= numbers * digits;
        digits++;
        start *= 10;
        numbers *= 10;
    }

    // Find the integer containing the target digit
    int numberIndex = (number - 1) / digits;
    int digitIndex = (number - 1) % digits;

    int targetNumber = start + numberIndex;

    // Extract the desired digit
    return (targetNumber / (int)Math.Pow(10, digits - 1 - digitIndex)) % 10;
}

int output = 1;

for(int i = 0; i <= 6; i++)
{
    output *= GetDigit((int)Math.Pow(10, i));
}
Console.WriteLine(output);

// Answer: 210
