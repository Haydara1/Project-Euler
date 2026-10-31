// Problem 41
// What is the largest n-digit pandigital prime that exists?

/*
 * We can notice that there can't exist a 10-digit pandigital number,
 * since the sum of the digits is 45, thus it will be divisible by 3.
 *
 * The same goes for 9 digits and eight digits.
 * So we only need to check up until 7 digits.
 */

 long bound = 7654321; // Largest seven-digits pandigital number.

 // Since we are looking only for the largest prime,
 // we can check by descending order if a number is pandigital then if it is prime.

 string digits = "1234567890";
 
 // Define a function to check whether a number is pandigital.
 bool IsPandigital(long number)
 {
     char[] array = number.ToString().ToCharArray();

     // We have to check if we have digits superior to n.
     string substring = digits.Substring(array.Length);
     
     Array.Sort(array);

     for (int i = 0; i < array.Length - 1; i++)
     {
         if (array[i] == array[i + 1] || substring.Contains(array[i].ToString()))
         {
             return false;
         }
     }

     if (substring.Contains(array[array.Length - 1].ToString())) // Check the last digit.
     {
         return false;
     }

     return true;
 }
 
 // Define a function to tell whether a number is prime:
 bool IsPrime(long number)
 {
     for (int i = 2; i <= Math.Sqrt(number); i++)
     {
         if (number % i == 0)
         {
             return false;
         }
     }
     
     return true;
 }

 long output = 0;
 
 // Loop
 for (long i = bound; i > 2; i-=2) // We don't have to check even numbers.
 {
     if (IsPandigital(i))
     {
         if (IsPrime(i))
         {
             output = i;
             break;
         }
     }
     
 }

 Console.WriteLine(output);

// Answer: 7652413
 
