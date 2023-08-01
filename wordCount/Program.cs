using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {
        string inputText = "This is a sample text. It contains sample words, SAMPLE words!";
        Dictionary<string, int> wordFrequency = CountWordFrequency(inputText);

        // Display the word frequency dictionary
        foreach (var kvp in wordFrequency)
        {
            Console.WriteLine($"{kvp.Key}: {kvp.Value}");
        }
    }

    static Dictionary<string, int> CountWordFrequency(string input)
    {
        // Remove punctuation marks and convert the input to lowercase
        string cleanedInput = Regex.Replace(input, @"[^\w\s]", "").ToLowerInvariant();

        // Split the input into words
        string[] words = cleanedInput.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

        // Create a dictionary to store the word frequency
        Dictionary<string, int> wordFrequency = new Dictionary<string, int>(StringComparer.InvariantCultureIgnoreCase);

        // Count the frequency of each word
        foreach (string word in words)
        {
            if (wordFrequency.ContainsKey(word))
            {
                wordFrequency[word]++;
            }
            else
            {
                wordFrequency[word] = 1;
            }
        }

        return wordFrequency;
    }
}
