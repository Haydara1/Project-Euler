// Problem 56:
// Considering natural numbers of the form a^b, where a, b < 100 what is the maximum digital sum?

 // Define a function to calculate the sum of digits:

 using System.Numerics;

 long SumDigits(BigInteger number)
 {
     string s = number.ToString();

     long sum = 0;
     
     foreach (char c in s)
     {
         sum += c - '0';
     }

     return sum;
 }

 long output = 0;
 
 for (int a = 11; a < 100; a++)
 {
     for (int b = 11; b < 100; b++)
     {
         BigInteger number = BigInteger.Pow(a, b);
         
         long sum = SumDigits(number);
         
         output = sum > output ? sum : output;
         
     }
 }

 Console.WriteLine(output);
 
 // Answer: 972
