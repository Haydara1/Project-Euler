// Problem 99:
// Determine which line number has the greatest numerical value.

// We want to compare a^b and c^d, 
// Which is the same as comparing b*log(a) and d*log(c)

// Define a function that compares the two values:
int[] Larger(int a, int b, int c, int d)
{
    int[] output = new int[2];

    double e = b * Math.Log(a);
    double f = d * Math.Log(c);
    
    if (e >= f)
    {
        output[0] = a;
        output[1] = b;
    }
    else
    {
        output[0] = c;
        output[1] = d;
    }
    
    return output;
}

// Parse the text file:
string[] lines = File.ReadAllLines("../../../base_exp.txt");

string[] values = lines[0].Split(',');
int[] output = new int[] {Convert.ToInt32(values[0]),
    Convert.ToInt32(values[1])};

for (int i = 1; i < lines.Length; i++)
{
    values = lines[i].Split(',');
    int a = Convert.ToInt32(values[0]);
    int b = Convert.ToInt32(values[1]);

    output = Larger(a, b, output[0], output[1]);
}

string answer = string.Join(",", output);
int lineIndex = Array.IndexOf(lines, answer) + 1;

Console.WriteLine(lineIndex);

// Answer: 709

