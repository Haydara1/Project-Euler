// Problem 30:
// Find the sum of all the numbers that can be written as the sum of fifth powers of their digits.

/*
 * We notice that for eight digits, the maximum possible sum 8*9^5 is smaller than the smallest 8-digit number.
 * So we found our upper bound: at 7*9^5 = 413343
 * 
 */
 
 // Create a function that calculate the sum of fifth powers:
 long Power(long n)
 {
     string s = n.ToString();

     long sum = 0;

     foreach (char c in s)
     {
         sum += (int)Math.Pow(c - '0', 5);
     }
     
     return sum;
 }
 
 long bound = 413343;

 long output = 0;
 
 for (long i = 2; i <= bound; i += 1)
 {
     if (i == Power(i))
     {
         output += i;
     }
     
 }

 Console.WriteLine(output);
 
 // Answer: 443839
