// Problem 85:
// Although there exists no rectangular grid that contains exactly two million rectangles,
// find the area of the grid with the nearest solution.

// In an n * m grid, we can choose 2 choose n + 1 and 2 choose m + 1 points to form rectangles
// So in an n * m grid we have: n * (n+1) * m *(m+1) / 4
// We can also impose n <= m

// Define the function:
long Function(long n, long m)
{
    return n * (n + 1) * m * (m + 1) / 4;
}

long nRecord = 0, mRecord = 0;
long numberRecord = 0;

long bound = 2000000;

for (long n = 1; n <= bound; n++)
{
    if (n * (n + 1) > bound) break;

    for (long m = n; m <= bound; m++)
    {
        long answer = Function(n, m);

        if (answer > bound * bound) break;

        if (Math.Abs(bound - answer) < Math.Abs(numberRecord - bound))
        {
            nRecord = n;
            mRecord = m;
            numberRecord = answer;
        }
    }
}

Console.WriteLine(nRecord * mRecord);

// Answer: 2772
