using System;

class Program
{
    static void Main()
    {
        StudentList<Student> studentList = new StudentList<Student>();
        // Adding students
        studentList.AddStudent(new Student("Dagmawi Muluwerk", 20, 101, "A"));
        studentList.AddStudent(new Student("Bruk Tedla", 21, 102, "B"));
        studentList.AddStudent(new Student("Joseph Birara", 19, 103, "C"));

        while (true)
        {
            Console.WriteLine("\n========== Student Management System ==========");
            Console.WriteLine("1. Add Student");
            Console.WriteLine("2. Search Student by Name");
            Console.WriteLine("3. Search Student by RollNumber");
            Console.WriteLine("4. Display All Students");
            Console.WriteLine("5. Save Students to JSON");
            Console.WriteLine("6. Load Students from JSON");
            Console.WriteLine("7. Exit");
            Console.Write("Enter your choice (1-7): ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.Write("Enter Student Name: ");
                    string name = Console.ReadLine();
                    Console.Write("Enter Student Age: ");
                    int age = int.Parse(Console.ReadLine());
                    Console.Write("Enter Student RollNumber: ");
                    int rollNumber = int.Parse(Console.ReadLine());
                    Console.Write("Enter Student Grade: ");
                    string grade = Console.ReadLine();

                    studentList.AddStudent(new Student(name, age, rollNumber, grade));
                    Console.WriteLine("Student added successfully!");
                    break;

                case "2":
                    Console.Write("Enter Name to Search: ");
                    string searchName = Console.ReadLine();
                    Student foundStudentByName = studentList.GetStudentByName(searchName);
                    if (foundStudentByName != null)
                    {
                        Console.WriteLine($"Found Student with Name: {foundStudentByName.Name}, RollNumber: {foundStudentByName.RollNumber}, Grade: {foundStudentByName.Grade}");
                    }
                    else
                    {
                        Console.WriteLine($"No Student found with Name: {searchName}");
                    }
                    break;

                case "3":
                    Console.Write("Enter RollNumber to Search: ");
                    int searchRollNumber = int.Parse(Console.ReadLine());
                    Student foundStudentById = studentList.GetStudentById(searchRollNumber);
                    if (foundStudentById != null)
                    {
                        Console.WriteLine($"Found Student with Name: {foundStudentById.Name}, RollNumber: {foundStudentById.RollNumber}, Grade: {foundStudentById.Grade}");
                    }
                    else
                    {
                        Console.WriteLine($"No Student found with RollNumber: {searchRollNumber}");
                    }
                    break;

                case "4":
                    Console.WriteLine("All Students:");
                    studentList.DisplayAllStudents();
                    break;

                case "5":
                    Console.Write("Enter file path to save: ");
                    string filePath = Console.ReadLine();
                    studentList.SerializeToJson(filePath);
                    Console.WriteLine("Data serialized to students.json");
                    break;

                case "6":
                    Console.Write("Enter file path to load: ");
                    filePath = Console.ReadLine();
                    studentList.DeserializeFromJson(filePath);
                    Console.WriteLine("Data deserialized from students.json:");
                    studentList.DisplayAllStudents();
                    break;

                case "7":
                    Console.WriteLine("Exiting...");
                    return;

                default:
                    Console.WriteLine("Invalid choice! Please try again.");
                    break;
            }
        }
    }
}
