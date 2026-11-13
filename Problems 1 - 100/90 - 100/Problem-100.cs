// Problem 100:
// The next such arrangement,
// for which there is exactly  50% chance of taking two blue discs at random,
// is a box containing eighty-five blue discs and thirty-five red discs.
// By finding the first arrangement to contain over 10^{12} discs in total,
// determine the number of blue discs that the box would contain.

using System.Numerics;

BigInteger bound = BigInteger.Pow(10, 12);

// We want that, for b blue discs, r red discs, and s all the discs, to have:
// (b / s) * ((b - 1) / (s - 1)) = 1 / 2
// Thus: 2 b * (b - 1) = s (s - 1)
// Finally: (2s - 1)^2 - 2(2b - 1)^2 = -1
// If we put x = 2s - 1 and y = 2b - 1
// We obtain the Pell equation: x^2 - 2y^2 = -1
// So the solution is the recurrence: x_{n + 1} = 3x_n + 4y_n and y_{n + 1} = 2x_n + 3y_n 

BigInteger x = 1, y = 1;

while (x + 1 < bound * 2)
{
    BigInteger tempx = x, tempy = y;
    
    x = 3 * tempx + 4 * tempy;
    y = 2 * tempx + 3 * tempy;
}

Console.WriteLine((y + 1) / 2);

// Answer: 756872327473
