// Problem 9:
// A Pythagorean triplet is a set of three natural numbers, a < b < c, for which,
//  a^2 + b^2 = c^2
//
// There exists exactly one Pythagorean triplet for which a + b + c = 1000.
// Find the product abc.

/*
 * From the question we can deduce that c = 1000 - a - b;
 * Putting in the formula we get:
 * 10^6 - 2000*(a + b) + 2ab = 0
 *
 * So we only have to check for couples less than a thousand that satisfy the above equation.
 */
 
 // Create a function that checks if a couple of integer satisfy the equation.
 bool Satisfy(int a, int b)
 {
     int check = 1000000 - 2000 * (a + b) + 2 * a * b;
     
     return check == 0;
 }

 int A = 0, B = 0;
 
 // Check all the couples.
 for (int b = 1; b <= 1000; b++)
 {
     for (int a = 1; a < b; a++)
     {
         if (Satisfy(a, b))
         {
             A = a;
             B = b;
         }
     }
 }
 
 int C = 1000 - A - B;

 Console.WriteLine(A * B * C);
 
 // Answer: 31875000
