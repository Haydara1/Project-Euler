// Problem 18:
// Find the maximum total from top to bottom of the triangle below:

string input = @"
75
95 64
17 47 82
18 35 87 10
20 04 82 47 65
19 01 23 75 03 34
88 02 77 73 07 63 67
99 65 04 28 06 16 70 92
41 41 26 56 83 40 80 70 33
41 48 72 33 47 32 37 16 94 29
53 71 44 65 25 43 91 52 97 51 14
70 11 33 28 77 73 17 78 39 68 17 57
91 71 52 38 17 14 91 43 58 50 27 29 48
63 66 04 68 89 53 67 30 73 16 69 87 40 31
04 62 98 27 23 09 70 98 73 93 38 53 60 04 23";

// Parse the string into an array:
string[] rows = input.Trim().Split('\n');

int[][] triangle = new int[rows.Length][];

for (int i = 0; i < rows.Length; i++)
{
    triangle[i] = rows[i]
        .Split(' ', StringSplitOptions.RemoveEmptyEntries)
        .Select(int.Parse)
        .ToArray();
}

/* The main idea is to start from the bottom, 
 * for each row, change the number to the maximum of its two children.
 */

for (int i = triangle.Length - 2; i >= 0; i--) // We subtract 2 since the maximum of the bottom row is itself.
{
    for (int j = 0; j < triangle[i].Length; j++)
    {
        triangle[i][j] += Math.Max(triangle[i + 1][j], triangle[i + 1][j + 1]);
    }
}

Console.WriteLine(triangle[0][0]);

// Answer: 1074
