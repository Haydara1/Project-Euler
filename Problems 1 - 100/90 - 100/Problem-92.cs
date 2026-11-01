// Problem 92:
// A number chain is created by continuously adding the square of the digits
// in a number to form a new number until it has been seen before.
// How many starting numbers below ten million will arrive at 89?

long bound = 10000000;

// Define a function to check whether a number arrives to 89
bool Chain(long number)
{
    if (number == 1)
    {
        return false;
    }

    if (number == 89)
    {
        return true;
    }

    return Chain(DigitsSum(number));
}

// Define a function to sum the square of its digits:
long DigitsSum(long number)
{
    string s = number.ToString();

    long output = 0;

    foreach (char c in s)
    {
        output += (c - '0') * (c - '0');
    }
    
    return output;
}

// The largest number sum is equal to 7 * 9 ^ 2 = 567
// So we can store those values to access them rapidly:

bool[] preDefinedChain = new bool[568];

long chainNum = 0;

for (int i = 1; i < 568; i++)
{
    if (Chain(i))
    {
        preDefinedChain[i] = true;
        chainNum++;
    }
    else
    {
        preDefinedChain[i] = false;
    }
}


for (long i = 568; i < bound; i++)
{
    if (preDefinedChain[DigitsSum(i)])
    {
        chainNum++;
    }
}

Console.WriteLine(chainNum);

// Answer: 
