// Problem 31:
// How many different ways can £2 be made using any number of coins?

// Initialize an array that will contain the number of ways to get a certain amount 1 ≤ i ≤ 200.
long[] ways = new long[201];
ways[0] = 1;

int[] coins = { 1, 2, 5, 10, 20, 50, 100, 200 }; // possible coins

foreach (int coin in coins)
{
    for (int amount = coin; amount <= 200; amount++)
    {
        ways[amount] += ways[amount - coin];
    }
}

Console.WriteLine(ways[200]);

// Answer: 73682
