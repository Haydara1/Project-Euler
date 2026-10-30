// Problem 15:
// Starting in the top left corner of a 2*2 grid,
// and only being able to move to the right and down,
// there are exactly 6 routes to the bottom right corner.
//
// How many such routes are there through a 20 * 20 grid?

/*
 * We can notice that all the routes have the same size.
 * Also, all the routes have the same number of down and right movements.
 * So for a 20*20 grid, we should have 20 downs and 20 rights.
 *
 * Thus, the total number of routes is the number of combinations of these movements.
 * Which is given by the formula: 40! / (20! * 20!)
 */
 
 using System.Numerics; // Since we are dealing with very large numbers.

 // Define factorial:
 BigInteger Factorial(long input)
 {
     BigInteger output = 1;
     
     for(long i = 2; i <= input; i++)
     {
         output *= i;
     }
     return output;
 }
 
 BigInteger output = Factorial(40) / (Factorial(20) *  Factorial(20));

 Console.WriteLine(output);
 
 // Answer: 137846528820
 
