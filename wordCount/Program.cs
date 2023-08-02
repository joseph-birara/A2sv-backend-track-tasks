using System;
using System.Collections.Generic;
using System.Linq;

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

        Console.WriteLine("\nWord Frequency Count:");
        foreach (var word in wordFrequency)
        {
            Console.WriteLine($"{word.Key}: {word.Value}");
        }
    }

    static Dictionary<string, int> CalculateWordFrequency(string input)
    {
        // Convert the input to lowercase and split into words
        string[] words = input.ToLowerInvariant().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);


        words = words.Select(RemovePunctuationMarks).ToArray();

        // Create a dictionary to store the word frequency
        Dictionary<string, int> wordFrequency = new Dictionary<string, int>();


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

    static string RemovePunctuationMarks(string word)
    {
        char[] punctuations = { '.', ',', '!', '?', ';', ':', '-', '_', '(', ')' };
        foreach (char punctuation in punctuations)
        {
            word = word.Replace(punctuation.ToString(), "");
        }
        return word;
    }
}
