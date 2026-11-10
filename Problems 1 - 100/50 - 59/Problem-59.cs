// Problem 59
// Decrypt the message and find the sum of the ASCII values in the original text

string text = File.ReadAllText("../../../0059_cipher.txt");

int[] cipher = text
    .Split(',')
    .Select(int.Parse)
    .ToArray();

int theCount = 0;
string answerText = "";

// Try all keys, since we only have 26 * 26 * 26:
for (char a = 'a'; a <= 'z'; a++)
{
    int[] decrypted = new int[cipher.Length];
    
    for (char b = 'a'; b <= 'z'; b++)
    {
        for (char c = 'a'; c <= 'z'; c++)
        {
            string key = a.ToString() + b + c;
            
            for(int index = 0; index < decrypted.Length; index++)
                decrypted[index] = cipher[index] ^ key[index % 3];
            
            string decryptedText = new string(
                decrypted.Select(x => (char)x).ToArray());
            
            int temp = decryptedText.Split("the ").Length;

            if (temp > theCount)
            {
                theCount = temp;
                answerText = decryptedText;
            }
        }
    }
}

// Find the ascii value in the original text:
int output = 0;

foreach (char c in answerText)
{
    output += (int)c;
}

Console.WriteLine(output);

// Answer: 129448
