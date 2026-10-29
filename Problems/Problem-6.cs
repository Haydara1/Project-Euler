/* Problem 6:
 * The sum of the squares of the first ten natural numbers is,
 * 1^2 + 2^2 + ... + 10^2 = 385
 * The square of the sum of the first ten natural numbers is,
 * (1 + ... + 10)^2 = 3025
 * 
 * Hence the difference between the sum of the squares of the first ten natural numbers and the square of the sum is
 * 3025 - 385 = 2640.
 * Find the difference between the sum of the squares of the first one hundred natural numbers and the square of the sum.
 */
 
 long sum = 0;
 
 // Get the sum of the squares:
 for (int i = 1; i <= 100; i++)
 {
     sum += i * i;
 }
 
 // The sum of the first hundred numbers is 5050
 
 long squaredSum = 5050 * 5050;

 Console.WriteLine(squaredSum - sum);
 
 // Answer: 25164150
