// Problem 43:
// Find the sum of all 0 to 9 pandigital numbers with this property.

// Since we have conditions on the numbers we can deduce that:
/*
 * The fourth digit is an even number.
 * The sixth digit is either 0 or 5.
 *
 * We only need to check the pandigital numbers = 3628800 = 10!
 * And since we only check for certain conditions, we can remove a good chunk of those.
 *
 */

// Define a function that checks whether a string has distinct chars:
bool DistinctChars(string s)
{
     char[] chars = s.ToCharArray();
     
     Array.Sort(chars); // Sort the array so identical elements are adjacent.

     for (int i = 0; i < chars.Length - 1; i++)
     {
          if (chars[i] == chars[i + 1])
          {
              return false;
          }
     }

     return true;
}
 
 // First we have to construct the 3 digits multiples of seventeen that have distinct digits:
 List<string> seventeenMultiple = new List<string>();

 for (int i = 102; i < 1000; i+=17)  // Loop over 17 multiples with 3 digits.
 {
      if (DistinctChars(i.ToString()))
      {
          seventeenMultiple.Add(i.ToString());
      }
 }
 
 // Up here we have the three digit multiples of seventeen that are distinct


 
// Construct a function to automate the process:
  List<string> DistinctMultipleList(List<string> list, int divisor)
  {
      List<string> output = new List<string>();
      
      foreach (string i in list)
      {
          for (int j = 0; j <= 9; j++) // Check all digits:
          {
              // Only check for distinct digits:
              if (i.Contains(j.ToString()))
              {
                  continue;
              }
            
              // Construct the multiple:
              int n = j * 100 + (i[0] - '0') * 10 +  (i[1] - '0');

              if (n % divisor == 0)
              {
                  string s = j.ToString() + i;
                  output.Add(s);
              }
            
          }
      }
      
      return output;
  }
  
  List<string> holder = DistinctMultipleList(seventeenMultiple, 13);
  holder = DistinctMultipleList(holder, 11);
  holder = DistinctMultipleList(holder, 7);
  holder = DistinctMultipleList(holder, 5);
  holder = DistinctMultipleList(holder, 3);
  holder = DistinctMultipleList(holder, 2);

// Add the last digit:
holder =  DistinctMultipleList(holder, 1);

// Find the sum:
long sum = 0;

foreach (var i in holder)
{
    sum += Convert.ToInt64(i);
}

Console.WriteLine(sum);

// Answer: 16695334890
