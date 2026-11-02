// Problem 96:
// By solving all fifty puzzles find the sum of the 3-digit numbers found in the top left corner of each solution grid.

// Code a sudoku solver.
// The following solver uses bit-masking and backtracking.

// Define a function to check whether it is safe to put a number in a given position.
bool IsSafe(int[,] mat, int row, int col, int num)
{
    // Check if num exists in the row or the column:
    for (int i = 0; i < 9; i++)
    {
        if (mat[row, i] == num || mat[i, col] == num)
        {
            return false;
        }
    }
    
    // Check if num exist in the 3 by 3 box:
    int startRow = row - (row % 3);
    int startColumn = col - (col % 3);

    for (int i = 0; i < 3; i++)
    {
        for (int j = 0; j < 3; j++)
        {
            if (mat[startRow + i, startColumn + j] == num)
            {
                return false;
            }
        }
    }

    return true;
}

// Define a function to solve the sudoku:
bool SolveRec(int[,] mat, int i, int j,
    int[] row, int[] col, int[] box)
{
    int n = mat.GetLength(0);
    
    // Reached the end:
    if (i == n - 1 && j == n)
    {
        return true;
    }
    
    // If reached the last column of the row, move to next row
    if (j == n)
    {
        i++;
        j = 0;
    }
    
    // If cell already occupied move to next cell
    if (mat[i, j] != 0)
    {
        return SolveRec(mat, i, j + 1, row, col, box);
    }

    for (int num = 1; num <= n; num++)
    {

        // If it is safe to place num at current position
        if (IsSafe(mat, i, j, num))
        {
            mat[i, j] = num;

            // Update masks for the corresponding row, column, and box
            row[i] |= (1 << num);
            col[j] |= (1 << num);
            box[i / 3 * 3 + j / 3] |= (1 << num);

            if (SolveRec(mat, i, j + 1, row, col, box))
                return true;

            // Unmask the number num in the corresponding row, column and box masks
            mat[i, j] = 0;
            row[i] &= ~(1 << num);
            col[j] &= ~(1 << num);
            box[i / 3 * 3 + j / 3] &= ~(1 << num);
        }
    }

    return false;
}

void SolveSudoku(int[,] mat)
{
    int n = mat.GetLength(0);
    int[] row = new int[n];
    int[] col = new int[n];
    int[] box = new int[n];

    // Set the bits in bitmasks for values that are initially present
    for (int i = 0; i < n; i++) {
        for (int j = 0; j < n; j++) {
            if (mat[i, j] != 0) {
                row[i] |= (1 << mat[i, j]);
                col[j] |= (1 << mat[i, j]);
                box[(i / 3) * 3 + j / 3] |= (1 << mat[i, j]);
            }
        }
    }

    SolveRec(mat, 0, 0, row, col, box);
}

// Parse the sudokus
string[] lines = File.ReadAllLines("../../../sudoku.txt");

List<int[,]> grids = new List<int[,]>();

for (int i = 0; i < lines.Length; i++)
{
    // Skip grid title (Grid 01, Grid 02, etc.)
    if (lines[i].StartsWith("Grid"))
    {
        int[,] mat = new int[9, 9];

        for (int j = 0; j < 9; j++)
        {
            string line = lines[i + 1 + j];

            for (int k = 0; k < 9; k++)
            {
                mat[j, k] = line[k] - '0'; // Convert char to int
            }
        }

        grids.Add(mat);
    }
}

// Solve the grids and output the sum;

long sum = 0;

for(int i = 0; i < grids.Count; i++)
{
    SolveSudoku(grids[i]);
    
    sum += grids[i][0, 0] * 100 + grids[i][0, 1] * 10 +  grids[i][0, 2];
}

Console.WriteLine(sum);

// Answer: 24702
