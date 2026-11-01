// Problem 55:
// How many Lychrel numbers are there below ten-thousand?

using System.Numerics;

int bound = 10000;

// Define a function to check whether a number is Lychrel
bool Lychrel(BigInteger number)
{
    for (int i = 0; i < 50; i++)
    {
        number += BigInteger.Parse(Inverse(number.ToString()));
        
        if (IsPalindrome(number))
        {
            return false;
        }
        
    }

    return true;
}

// Define a function to inverse a string:
string Inverse(string s)
{
    string output = "";

    for (int i = s.Length - 1; i >= 0; i--)
    {
        output += s[i];
    }
    
    return output;
}

// Define a function to check if a number is a palindrome:
bool IsPalindrome(BigInteger number)
{
    string s = number.ToString();

    for (int i = 0; i <= s.Length / 2; i++)
    {
        if (s[i] != s[s.Length - 1 - i])
        {
            return false;
        }
    }
    
    return true;
}



int output = 0;

for (int i = 0; i < bound; i++)
{
    if (Lychrel(i))
    {
        output += 1;
    }
}

Console.WriteLine(output);

// Answer: 249
