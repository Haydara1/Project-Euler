// Problem 42:
// Using words.txt, how many are triangle words?

string text = File.ReadAllText("../../../0042_words.txt");

string[] words = text.Split(',')
    .Select(word => word.Trim('"'))
    .ToArray();
    
// Generate triangular numbers up until 100
long[] triangular =  new long[100];

for (int i = 0; i < 100; i++)
{
    triangular[i] = i * (i + 1) / 2;
}

// Define a function to get numerical value from a string:
long Numerical(string s)
{
    long output = 0;

    foreach (char c in s)
    {
        output += c - 'A' + 1;
    }

    return output;
}

int numWords = 0;

foreach (string word in words)
{
    if (triangular.Contains(Numerical(word)))
    {
        numWords++;
    }
}

Console.WriteLine(numWords);

// Answer: 162
