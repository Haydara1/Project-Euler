// Problem 81:
// Find the minimal path sum from the top left to the bottom right by only moving right and down in matrix.txt.

// Parse the matrix:
string[] lines = File.ReadAllLines("../../../matrix.txt");

int[,] matrix = new int[lines.Length, lines[0].Split(',').Length];

for (int i = 0; i < lines.Length; i++)
{
    string[] numbers = lines[i].Split(',');

    for (int j = 0; j < numbers.Length; j++)
    {
        matrix[i, j] = int.Parse(numbers[j]);
    }
}

int rows = matrix.GetLength(0);
int cols = matrix.GetLength(1);

// Last row: can only move right
for (int j = cols - 2; j >= 0; j--)
    matrix[rows - 1, j] += matrix[rows - 1, j + 1];

// Last column: can only move down
for (int i = rows - 2; i >= 0; i--)
    matrix[i, cols - 1] += matrix[i + 1, cols - 1];

// Replace each number by the minimal value:
for (int i = rows - 2; i >= 0; i--)
{
    for (int j = cols - 2; j >= 0; j--)
    {
        matrix[i, j] += Math.Min(matrix[i + 1, j], matrix[i, j + 1]);
    }
}

Console.WriteLine(matrix[0, 0]);

// Answer: 427337
