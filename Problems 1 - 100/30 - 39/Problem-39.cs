// Problem 39:
// If p is the perimeter of a right angle triangle with integral length sides a, b, c,
// there are exactly three solutions for p = 120.
//
//  For which value of  , is the number of solutions maximized?

// Store the values of perimeters in an array (array[120] = 3)
int[] array = new int[1001];

// Check all phythagorian triples
for (int a = 0; a < 1000; a++)
{
    for (int b = 0; b < 1000; b++)
    {
        // Continue if it exceeds perimeter:
        if (a + b > 1000)
        {
            continue;
        }

        // Check if they form a Pythagorean triple:
        double d = Math.Sqrt(a * a + b * b);

        if (d % 1 == 0) // Checks if the double number has a decimal.
        {
            int perimeter = (int)d + a + b;

            if (perimeter > 1000)
            {
                continue;
            }

            array[perimeter] += 1;
        }
    }
}

// Get the largest perimeter
int maxValue = array.Max();
int index = array.ToList().IndexOf(maxValue);

Console.WriteLine(index);

// Answer: 

