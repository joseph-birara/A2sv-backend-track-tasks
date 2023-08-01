using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        // Prompt the student for their name
        Console.Write("Enter student's name: ");
        string studentName = Console.ReadLine();

        // Prompt the student for the number of subjects they have taken
        Console.Write("Enter the number of subjects: ");
        int numSubjects;
        while (!int.TryParse(Console.ReadLine(), out numSubjects) || numSubjects <= 0)
        {
            Console.WriteLine("Invalid input. Please enter a valid positive integer for the number of subjects.");
            Console.Write("Enter the number of subjects: ");
        }

        // Use a dictionary to store subject names and corresponding grades
        Dictionary<string, double> subjectGrades = new Dictionary<string, double>();

        // Loop to input subject names and grades
        for (int i = 0; i < numSubjects; i++)
        {
            Console.Write($"Enter the name of subject {i + 1}: ");
            string subjectName = Console.ReadLine();

            double grade;
            // Validate grade input within a valid range (0 to 100)
            while (true)
            {
                Console.Write($"Enter the grade for {subjectName}: ");
                if (double.TryParse(Console.ReadLine(), out grade) && grade >= 0 && grade <= 100)
                {
                    break;
                }
                Console.WriteLine("Invalid input. Please enter a valid grade between 0 and 100.");
            }

            // Add the subject and grade to the dictionary
            subjectGrades.Add(subjectName, grade);
        }

        // Calculate the average grade using the CalculateAverageGrade method
        double averageGrade = CalculateAverageGrade(subjectGrades);

        // Display the results using string interpolation
        Console.WriteLine($"Student Name: {studentName}");
        Console.WriteLine("Individual Subject Grades:");
        foreach (var kvp in subjectGrades)
        {
            Console.WriteLine($"{kvp.Key}: {kvp.Value}");
        }
        Console.WriteLine($"Average Grade: {averageGrade:F2}");
    }

    // Method to calculate the average grade based on the entered grades
    static double CalculateAverageGrade(Dictionary<string, double> grades)
    {
        if (grades.Count == 0)
        {
            return 0.0;
        }

        double totalGrades = 0.0;
        foreach (var grade in grades.Values)
        {
            totalGrades += grade;
        }

        return totalGrades / grades.Count;
    }
}
