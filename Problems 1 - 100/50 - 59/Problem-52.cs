// Problem 52:
// Find the smallest positive integer, x, such that 2x, 3x, 4x, 5x, and 6x, contain the same digits.

// Define a function to check whether two numbers have the same digits:
bool HasTheSameDigits(long a, long b)
{
    char[] s = a.ToString().ToCharArray();
    char[] t = b.ToString().ToCharArray();

    if (s.Length != t.Length)
    {
        return false;
    }
    
    Array.Sort(s);
    Array.Sort(t);

    for (int i = 0; i < s.Length; i++)
    {
        if (s[i] != t[i])
        {
            return false;
        }
    }

    return true;
}

int index = 1;

while (true)
{
    if (HasTheSameDigits(index, index * 2) &&
        HasTheSameDigits(index, index * 3) &&
        HasTheSameDigits(index, index * 4) &&
        HasTheSameDigits(index, index * 5) &&
        HasTheSameDigits(index, index * 6))

    {
        break;
    }
    
    index++;
}

Console.WriteLine(index);

// Answer: 142857
