// Problem 54:
// How many hands does Player 1 win?

// Assign values to each hand
enum Hands
{
    HighCard,
    OnePair,
    TwoPair,
    ThreeOfAKind,
    Straight,
    Flush,
    FullHouse,
    FourOfAKind,
    StraightFlush,
    RoyalFlush,
}

public class Program
{
    public static void Main()
    {
        // Parse the file:
        string[] lines = File.ReadAllLines("../../../poker.txt");

        int output = 0;

        foreach (string line in lines)
        {
            string playerOneValue = "";
            string playerTwoValue = "";
            
            string playerOneSuit = "";
            string playerTwoSuit = "";
            
            for (int i = 0; i < 15; i += 3)
            {
                playerOneValue += line[i];
                playerOneSuit += line[i + 1];
            }
            
            for (int i = 15; i < 28; i += 3)
            {
                playerTwoValue += line[i];
                playerTwoSuit += line[i + 1];
            }
            
            
            Hands playerOneHand = GetPokerHand(playerOneValue,  playerOneSuit);
            Hands playerTwoHand = GetPokerHand(playerTwoValue, playerTwoSuit);

            if (playerOneHand > playerTwoHand)
            {
                output++;
            }
            else if (playerOneHand == playerTwoHand)
            {
                if (IsGreater(playerOneValue, playerTwoValue, playerOneHand))
                {
                    output++;
                }
            }
            
        }

        Console.WriteLine(output);
        
        // Answer: 376
        
    }
    
    // Define a function returning the value of a hand:
    static Hands GetPokerHand(string values, string suit)
    {
        
        // Get distinct numbers:
        int distinctValuesNum = values.Distinct().Count();
        int distinctSuitNum = suit.Distinct().Count();
        
        // Check for a royal flush
        if (distinctSuitNum == 1 && values.All(Char.IsDigit) == false)
        {
            return Hands.RoyalFlush;
        }
        
        // Check for a straight flush
        if (distinctSuitNum == 1 && IsStraight(values)) 
        {
            return Hands.StraightFlush;
        }
        
        // Check for four of a kind or full house:
        if (distinctValuesNum == 2)
        {
            char[] sortedValues = values.ToCharArray();
            
            Array.Sort(sortedValues);

            if (sortedValues[0] != sortedValues[1]) // Then we only have one distinct card from the others
            {
                return Hands.FourOfAKind;
            }
            else
            {
                return Hands.FullHouse;
            }
        }
        
        // Check for flush
        if (distinctSuitNum == 1)
        {
            return Hands.Flush;
        }
        
        // Check for straight
        if (IsStraight(values))
        {
            return Hands.Straight;
        }
        
        // Check for a three of a kind or two pair
        if (distinctValuesNum == 3)
        {
            char[] sortedValues = values.ToCharArray();
            
            Array.Sort(sortedValues);

            if ((sortedValues[0] == sortedValues[1] && sortedValues[1] == sortedValues[2]) ||
                (sortedValues[1] == sortedValues[2] && sortedValues[2] == sortedValues[3]) ||
                (sortedValues[2] == sortedValues[3] && sortedValues[3] == sortedValues[4]))
            {
                return Hands.ThreeOfAKind;
            }
            else
            {
                return Hands.TwoPair;
            }
        }

        if (distinctValuesNum == 4)
        {
            return Hands.OnePair;
        }

        return Hands.HighCard;
    }
    
    // Define a function to check if values are straight
    static bool IsStraight(string values)
    {
        int[] straight = ValuesToArray(values);
            
        Array.Sort(straight);

        for (int i = 0; i < 4; i++)
        {
            if (straight[i + 1] - straight[i] != 1)
            {
                return false;
            }
        }
        
        return true;
    }
    
    // Define a function to compare values of two hands
    static bool IsGreater(string values1, string values2, Hands hand)
    {
        int[] valuesArray1 = ValuesToArray(values1);
        int[] valuesArray2 = ValuesToArray(values2);
        
        Array.Sort(valuesArray1);
        Array.Sort(valuesArray2);


        if (hand == Hands.StraightFlush || hand == Hands.Straight ||
            hand == Hands.Flush || hand == Hands.HighCard)
        {
            return valuesArray1[4] > valuesArray2[4];
        }

        if (hand == Hands.OnePair || hand == Hands.FourOfAKind)
        {
            // Get the pair from each hand:

            int playerOnePair = 0;
            int playerTwoPair = 0;

            for (int i = 0; i < 4; i++)
            {
                if (valuesArray1[i] == valuesArray1[i + 1])
                {
                    playerOnePair = valuesArray1[i];
                }

                if (valuesArray2[i] == valuesArray2[i + 1])
                {
                    playerTwoPair = valuesArray2[i];
                }
            }
            
            return playerOnePair > playerTwoPair;

        }

        if (hand == Hands.TwoPair)
        {
            int playerOnePair = 0;
            int playerTwoPair = 0;

            for (int i = 0; i < 4; i++)
            {
                // Check for the highest pair
                if (valuesArray1[i] == valuesArray1[i + 1] &&
                    valuesArray1[i] > playerOnePair)
                {
                    playerOnePair = valuesArray1[i];
                }

                //
                if (valuesArray2[i] == valuesArray2[i + 1] &&
                    valuesArray2[i] > playerTwoPair)
                {
                    playerTwoPair = valuesArray2[i];
                }
            }
            
            return playerOnePair > playerTwoPair;
        }

        if (hand == Hands.ThreeOfAKind || hand == Hands.FullHouse)
        {
            int playerOnePair = 0;
            int playerTwoPair = 0;

            for (int i = 0; i < 3; i++)
            {
                if (valuesArray1[i] == valuesArray1[i + 1] &&
                    valuesArray1[i + 1] == valuesArray1[i + 2])
                {
                    playerOnePair = valuesArray1[i];
                }

                if (valuesArray2[i] == valuesArray2[i + 1] &&
                    valuesArray2[i + 1] == valuesArray2[i + 2])
                {
                    playerTwoPair = valuesArray2[i];
                }
                    
            }
            
            return playerOnePair > playerTwoPair;
        }

        return true;

    }
    
    // Define a function to return the values as an int array
    static int[] ValuesToArray(string values)
    {
        // Convert the values to an integer array
        int[] straight = new int[5];

        for (int i = 0; i < 5; i++)
        {
            if (values[i] == 'T')
            {
                straight[i] = 10;
            }
            else if (values[i] == 'J')
            {
                straight[i] = 11;
            }
            else if (values[i] == 'Q')
            {
                straight[i] = 12;
            }
            else if (values[i] == 'K')
            {
                straight[i] = 13;
            }
            else if (values[i] == 'A')
            {
                straight[i] = 14;
            }
            else
            {
                straight[i] = values[i] - '0';
            }
        }
        
        return straight;
    }
}
