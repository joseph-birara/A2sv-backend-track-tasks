using System;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {
        bool keepChecking = true;

        while (keepChecking)
        {
            Console.Write("Enter a string to check if it is a palindrome (type 'exit' to stop): ");
            string inputText = Console.ReadLine();

            if (inputText.ToLowerInvariant() == "exit")
            {
                keepChecking = false;
            }
            else
            {
                bool isPalindrome = IsPalindrome(inputText);
                Console.WriteLine($"Is the input a palindrome? {isPalindrome}");
            }
        }
    }

    static bool IsPalindrome(string input)
    {
        // Remove spaces and punctuation using a regular expression
        string cleanedInput = Regex.Replace(input, @"[\W_]", "").ToLowerInvariant();

        // Compare the cleaned input with its reverse
        return cleanedInput.SequenceEqual(cleanedInput.Reverse());
    }
}
