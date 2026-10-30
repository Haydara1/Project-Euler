// Problem 22:
// Using names.txt, a 46K text file containing over five-thousand first names,
// begin by sorting it into alphabetical order.
// Then working out the alphabetical value for each name,
// multiply this value by its alphabetical position in the list to obtain a name score.
//
// What is the total of all the name scores in the file?

string content = File.ReadAllText("../../../names.txt"); // Read the content

// Parse into an array:
string[] array =  content.Split(',')
    .Select(name => name.Trim('"'))
    .ToArray();;

Array.Sort(array); // Sort the array.

// Define a function to calculate the alphabetical value of a name:
int Value(string s)
{
    int sum = 0;

    foreach (char c in s)
    {
        sum += c - 'A' + 1; // since all names are in caps we can get the value like this.
    }
    
    return sum;
}

long output = 0;

for (int i = 0; i < array.Length; i++)
{
    output += Value(array[i]) * (i + 1);
}

Console.WriteLine(output);

// Answer: 871198282

