// If we list all the natural numbers below 10 that are multiples of  3 or 5, we get 3, 5, 6 and 9.
// The sum of these multiples is 23.
// Find the sum of all the multiples of 3 or 5 below 1000.

long sum = 0;

int bound = 1000; // fix upper bound.

// Find the sum of multiples of three
for(int i = 3; i < bound; i += 3)
{
    sum += i;
}

// Find the sum of multiples of five
for(int i = 5; i < bound; i += 5)
{
    sum += i;
}

// Notice how we added common multiples of 3 and 5 twice, so we have to remove them once.
for(int i = 15; i < bound; i += 15)
{
    sum -= i;
}

Console.WriteLine(sum);

// Answer: 233168
