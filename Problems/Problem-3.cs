/*
 * Problem 3:
 * The prime factors of  13195 are 5, 7, 13 and 19.
 * What is the largest prime factor of the number 600851475143 ?
 */
 
long number = 600851475143;
long largestPrimeFactor = 1;

// Search for the largest prime number that divides the prime number.
for (long i = 2; i <= number / i; i++) // We divide by i since we only have to check up until sqrt(n).
{
    while (number % i == 0) 
    {
        largestPrimeFactor = i;
        number /= i;
    }
}

if (number > 1)
{
    largestPrimeFactor = number;
}

Console.WriteLine(largestPrimeFactor);

 // Answer: 6857
