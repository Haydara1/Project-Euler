// Problem 74:
// How many chains, with a starting number below one million, contain exactly sixty non-repeating terms?

// Define bound:
int bound = 1000000;

// Define a factorial:
long Factorial(int n)
{
    if (n == 0)
    {
        return 1;
    }
    
    long output = 1;

    for (int i = 1; i <= n; i++)
    {
        output *= i;
    }
    
    return output;
}

// Since we will only take the factorial of digits, we can store them in an array:
long[] factorials = new long[10];

for (int i = 0; i < factorials.Length; i++)
{
    factorials[i] = Factorial(i);
}

// Define a function to take the factorial of the digits
long DigitSum(long number)
{
    string s = number.ToString();

    long output = 0;

    for (int i = 0; i < s.Length; i++)
    {
        output += factorials[s[i] - '0'];
    }

    return output;
}

// Define a function to count the number of distinct numbers in a chain:
int Chain(long number)
{
    List<long> chain = new List<long>();
    
    chain.Add(number);

    while (true)
    {
        long newNumber = DigitSum(number);

        if (chain.Contains(newNumber))
        {
            break;
        }
        
        chain.Add(newNumber);
        
        number = newNumber;
    }
    
    return chain.Count;
}

int output = 0;

for (int i = 0; i <= bound; i++)
{
    if (Chain(i) == 60)
    {
        output++;
    }
}


Console.WriteLine(output);

// Answer: 402
