using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;

public class StudentList<T> where T : Student
{
    private List<T> students;

    public StudentList()
    {
        students = new List<T>();
    }

    public void AddStudent(T student)
    {
        students.Add(student);
    }

    public T? GetStudentByName(string name)
    {
        return students.FirstOrDefault(s => s.Name == name);
    }

    public T? GetStudentById(int rollNumber)
    {
        return students.FirstOrDefault(s => s.RollNumber == rollNumber);
    }

    public void DisplayAllStudents()
    {
        foreach (T student in students)
        {
            Console.WriteLine($"Name: {student.Name}, Age: {student.Age}, RollNumber: {student.RollNumber}, Grade: {student.Grade}");
        }
    }

    // Serialization and deserialization methods
    public void SerializeToJson(string filePath)
    {
        string json = System.Text.Json.JsonSerializer.Serialize(students);
        System.IO.File.WriteAllText(filePath, json);
    }

    public void DeserializeFromJson(string filePath)
    {
        string json = System.IO.File.ReadAllText(filePath);
        var options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true // Allows case-insensitive matching during deserialization
        };
        students = System.Text.Json.JsonSerializer.Deserialize<List<T>>(json, options);
    }
}
