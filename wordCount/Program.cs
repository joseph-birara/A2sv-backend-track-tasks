using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Console.WriteLine("Word Frequency Count");
        Console.WriteLine("--------------------");

        // Get the input text from the user
        Console.Write("Enter a text: ");
        string inputText = Console.ReadLine();

        // Calculate word frequency
        Dictionary<string, int> wordFrequency = CalculateWordFrequency(inputText);

        // Display the word frequency dictionary
        Console.WriteLine("\nWord Frequency Count:");
        foreach (var kvp in wordFrequency)
        {
            Console.WriteLine($"{kvp.Key}: {kvp.Value}");
        }
    }

    static Dictionary<string, int> CalculateWordFrequency(string input)
    {
        // Step 1: Convert the input to lowercase and split into words
        string[] words = ConvertToLowercaseAndSplitIntoWords(input);

        // Step 2: Create a dictionary to store the word frequency
        Dictionary<string, int> wordFrequency = CreateWordFrequencyDictionary();

        // Step 3: Count the frequency of each word
        CountWordFrequency(words, wordFrequency);

        return wordFrequency;
    }

    // Step 1: Convert the input to lowercase and split into words
    static string[] ConvertToLowercaseAndSplitIntoWords(string input)
    {
        input = input.ToLowerInvariant();

        // Split into words based on spaces
        string[] words = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

        // Remove punctuation marks from each word
        for (int i = 0; i < words.Length; i++)
        {
            words[i] = RemovePunctuationMarks(words[i]);
        }

        return words;
    }

    // Remove punctuation marks from a word
    static string RemovePunctuationMarks(string word)
    {
        char[] punctuations = { '.', ',', '!', '?', ';', ':', '-', '_', '(', ')' };
        foreach (char punctuation in punctuations)
        {
            word = word.Replace(punctuation.ToString(), "");
        }
        return word;
    }

    // Step 2: Create a dictionary to store the word frequency
    static Dictionary<string, int> CreateWordFrequencyDictionary()
    {
        return new Dictionary<string, int>();
    }

    // Step 3: Count the frequency of each word
    static void CountWordFrequency(string[] words, Dictionary<string, int> wordFrequency)
    {
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
    }
}
