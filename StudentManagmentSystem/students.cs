public class Student
{
    public string? Name { get; set; }
    public int Age { get; set; }
    public readonly int RollNumber;
    public string? Grade { get; set; }

    // Parameterless constructor for deserialization
    public Student()
    {
    }

    public Student(string name, int age, int rollNumber, string grade)
    {
        Name = name;
        Age = age;
        RollNumber = rollNumber;
        Grade = grade;
    }
}
