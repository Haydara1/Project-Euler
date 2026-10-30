// Problem 67:
// Find the maximum total from top to bottom in triangle.txt,
// a 15K text file containing a triangle with one-hundred rows.

// Parse the string into an array:
string path = Path.Combine(AppContext.BaseDirectory, "../../../triangle.txt");

string[] rows = File.ReadAllLines(path);

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

// Answer: 7273
