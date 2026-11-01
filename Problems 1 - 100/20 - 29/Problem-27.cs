// Problem 27:
// Find the product of the coefficients, a and b,
// for the quadratic expression that produces the maximum number of primes for consecutive values of n, starting with n = 0.

/*
 * For n = 0; we have (0)^2 + a(0) + b = b thus b has to be prime.
 * For n = 1; we have a + b + 1 has to be a prime.
 * Also, we can notice that if a and b has different parities, then a + b + 1 is even thus not prime;
 * So both a and b have to be of the same parity.
 * If a = b = 2 we only get 2 primes so we can completely eliminate 2.
 */
 
 // Generate primes under 2 thousand:
 int bound = 2001; // We set the bound here since a + b + 1 < 2000
 bool[] primes = new bool[bound];

 for (int i = 0; i < bound; i++)
 {
     primes[i] = true;
 }

 primes[0] = false;
 primes[1] = false;
 
 // Use Sieve's algorithm:
 for (int i = 2; i < Math.Sqrt(bound); i++)
 {
     if (primes[i]) 
     {
         for (int j = (int)Math.Pow(i, 2); j < bound; j += i)
         {
             primes[j] = false;
         }
     } 
 }
 
 // Define a function to see whether a number is prime
 // This function will be used as the numbers from the quadratic formula can be very large:
 bool IsPrime(long number)
 {
     if (number < 2)
     {
         return false;
     }
     
     for (int i = 2; i <= Math.Sqrt(number); i++)
     {
         if (number % i == 0)
         {
             return false;
         }
     }

     return true;
 }
 
 // Define the quadratic:
 long Quadratic(int a, int b, int n)
 {
     return n * n + a * n + b;
 }
 
 // Define a function that calculates the number of consecutive primes
 long ChainCalculate(int a, int b)
 {
     long chain = 0;

     int index = 0;

     // Stop until you don't get a prime.
     while (true)
     {
         if (IsPrime(Quadratic(a, b, index)))
         {
             chain++;
         }
         else
         {
             return chain;
         }

         index++;
     }
 }

 long chain = 0;
 int index = 0;
 
 // Check the quadratic list:
 for (int b = 3; b < 1000; b++)
 {
     // Check if b is prime
     if (primes[b])
     {
         for (int a = -999; a < 1000; a++)
         {
             int n1 = a + b + 1; // The result for n = 1;

             if (n1 < 2)
             {
                 continue;
             }
             
             // Check if a + b + 1 is prime
             if (primes[n1])
             {
                 long supposedChain = ChainCalculate(a, b);
                 
                 if(supposedChain > chain)
                 {
                     chain = supposedChain;
                     index = a * b;
                 }
                 
             }
         }
     }
 }

 Console.WriteLine(index);

// Answer: -59231
 
