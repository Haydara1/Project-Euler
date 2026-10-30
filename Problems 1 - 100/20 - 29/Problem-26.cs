// Problem 26:
// Find the value of d < 1000 for which 1/d contains the longest recurring cycle in its decimal fraction part.

/*
 * We should notice that numbers that have factors of 2 or 5 don't result in a cycle, since they can divide 10^k.
 * We will consider other numbers and calculate the the lowest k such that 10^k mod d = 1.
 */
 
 // Create a function that calculates the lowest k;
 long CalculateCycleSize(int n)
 {
     long remainder = 1;
     long index = 0;

     while (true)
     {
         remainder = (remainder * 10) % n;
         index++;

         if (remainder == 1)
             return index;

         if (remainder == 0) // If it divides 10^k then no cycle is produced.
             return 0;
     }
 }
 
 long lowestK = 0;
 int index = 0;

 for (int i = 1; i < 1000; i++)
 {
     if (i % 2 == 0 || i % 5 == 0)
     {
         continue;
     }

     long j = CalculateCycleSize(i);
     
     if (j > lowestK)
     {
         index = i;
         lowestK = j;
     }
 }

 Console.WriteLine(index);
 
 // Answer: 983
