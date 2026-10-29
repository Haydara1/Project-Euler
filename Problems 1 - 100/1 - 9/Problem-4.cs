/* Problem 4:
 * A palindromic number reads the same both ways.
 * The largest palindrome made from the product of two 2-digit numbers is  9009 = 99 * 91.
 * Find the largest palindrome made from the product of two 3-digit numbers.
 */
 
// Create a function to check whether a number is a palindrome.
bool IsPalindrome(int n)
{
    string s = n.ToString();

    bool output = true;
    
    for (int i = 0; i < s.Length / 2; i++)
    {
        if (s[i] != s[s.Length - 1 - i])
        {
            output = false;
            break;
        }
    }

    return output;
}

int num1 = 999;
int num2 = 999;

int output = 0;

// Check for each combination, we start from the largest numbers since we search the largest palindrome.
for (int i = num1; i >= 1; i--)
{
    
    for (int j = num2; j >= 1; j--)
    {
        if (IsPalindrome(i * j))
        {
            // Check whether the found palindrome is larger than the previous found one.
            if (i * j > output)
            {
                output = i * j;
            }
        }
    }
}

Console.WriteLine(output);

// Answer: 906609
