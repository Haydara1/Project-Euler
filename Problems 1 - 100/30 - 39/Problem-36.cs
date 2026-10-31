// Problem 36
// Find the sum of all numbers, less than one million, which are palindromic in base 10 and base 2.

/*
 * One million isn't that big of a number for a computer, so we can brute force this:
 */
 
 long sum = 0;
 
 // Define a function to check if a number is palindromic in base 10:
 bool PalindromicBaseTen(long number)
 {
     string s = number.ToString();

     for (int i = 0; i < s.Length/ 2; i++)
     {
         if (s[i] != s[s.Length - 1 - i])
         {
             return false;
         }
     }

     return true;
 }
 
 // Define a function to check if a number is palindromic in base 2:
 bool PalindromicBaseTwo(long number)
 {
     string s = Convert.ToString(number, 2);
     
     for (int i = 0; i < s.Length / 2; i++)
     {
         if (s[i] != s[s.Length - 1 - i])
         {
             return false;
         }
     }

     return true;
 }

 long bound = 1000000;
 
 // Check all numbers from 1 to a million:
 for (long i = 0; i < bound; i++)
 {
     if (PalindromicBaseTen(i) && PalindromicBaseTwo(i))
     {
         sum += i;
     }
 }

 Console.WriteLine(sum);
 
 // Answer: 872187
