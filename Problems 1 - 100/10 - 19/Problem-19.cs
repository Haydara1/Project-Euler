// Problem 19:
// How many Sundays fell on the first of the month during the twentieth century.

// We can brute force this:

int sundays = 0;
// 1 jan 1901 was a Tuesday
int firstDayOfTheMonth = 1; // 0 for monday, 6 for sunday.

int[] months = [31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31];

for (int year = 1901; year <= 2000; year++)
{
    bool leap = false || ((year % 4 == 0 && year % 100 != 0) || year % 400 == 0); // Check if the year is a leap year or not.

    // Months
    for (int i = 0; i < 12; i++)
    {
        if (firstDayOfTheMonth == 6) sundays++;
        
        if (i == 1 && leap)
        {
            firstDayOfTheMonth = (firstDayOfTheMonth +  months[i] + 1) % 7;
            continue;
        }
        
        firstDayOfTheMonth = (firstDayOfTheMonth +  months[i]) % 7;
        
    }
}

Console.WriteLine(sundays);

// Answer: 171
