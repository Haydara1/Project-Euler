/* Problem 7:
 * By listing the first six prime numbers: 2, 3, 5, 7, 11 and 13, we can see that the 6th prime is 13.
 * What is the  10 001st prime number?
 */
 
long number = 3;
int index = 2; // we have already assigned 2, and 3

int bound = 10001;

List<long> primes = new List<long>(); // Store a list of primes.
primes.Add(2);
 
 while (index <= bound)
 {
     if (IsPrime(number))
     {
         primes.Add(number);
         index++;
     }

     number++;
 }

 Console.WriteLine(primes.Last());
 
 // Create a function to check if a number is prime
 bool IsPrime(long n)
 {
     foreach(long i in primes) // We only have to check whether it is divisible by primes.
     {
         if (n % i == 0)
         {
             return false;
         }
     }
     
     return true;
 }
 
 // Answer: 104743
