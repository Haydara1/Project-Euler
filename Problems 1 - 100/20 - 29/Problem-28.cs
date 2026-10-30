// Problem 28:
// What is the sum of the numbers on the diagonals in a  1001 by 1001 spiral formed in the same way?

/*
 * We can notice that the top right corner is always the square of an odd number;
 * and for each square, the corners are distanced at an equal distance equal to the square root of the top right corner.
 * If the number in the top right corner is (2n + 1)^2;
 * then we can obtain the three other by successively subtracting 2n.
 * From here we can deduce that the formula for a given square is 4*(2n+1)^2 - 12n
 */
    
long sum = 1;

for (int i = 1; i <= 500; i++)
{
    sum += 4 * (2 * i + 1) * (2 * i + 1) - 12 * i;
}

Console.WriteLine(sum);

// Answer: 669171001
