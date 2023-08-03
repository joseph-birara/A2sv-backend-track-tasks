using System;
using System.Threading.Tasks;

class Program
{
    static async Task Main()
    {
        Console.WriteLine("Simple Task Manager");
        Console.WriteLine("-------------------");

        TaskManager taskManager = new TaskManager();

        // Adding a task using object initializer
        await taskManager.AddTaskAsync("Task 1", "This is the first task", TaskCategory.Personal);
        await taskManager.AddTaskAsync("Task 2", "This is the second task", TaskCategory.Work);

        while (true)
        {
            Console.WriteLine("\nSelect an option:");
            Console.WriteLine("1. View all tasks");
            Console.WriteLine("2. View tasks by category");
            Console.WriteLine("3. Add a new task");
            Console.WriteLine("4. Exit");

            string input = Console.ReadLine();

            // get all tasks
            if (input == "1")
            {
                taskManager.ViewAllTasks();
            }

            // filter by catrgory
            else if (input == "2")
            {
                Console.WriteLine("Enter category (Personal, Work, Errands, etc.):");
                string categoryInput = Console.ReadLine();
                //check if the category input is in the enum
                if (Enum.TryParse<TaskCategory>(categoryInput, out TaskCategory category))
                {
                    var tasksByCategory = taskManager.GetTasksByCategory(category);
                    if (tasksByCategory.Count > 0)
                    {
                        Console.WriteLine($"Tasks in category '{category}':");
                        foreach (var task in tasksByCategory)
                        {
                            Console.WriteLine($"Name: {task.Name}, Description: {task.Description}, IsCompleted: {task.IsCompleted}");
                        }
                    }
                    else
                    {
                        Console.WriteLine($"No tasks found in category '{category}'.");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid category.");
                }
            }

            // add task
            else if (input == "3")
            {
                Console.WriteLine("Enter task name:");
                string name = Console.ReadLine();
                Console.WriteLine("Enter task description:");
                string description = Console.ReadLine();
                Console.WriteLine("Enter task category (Personal, Work, Errands, etc.):");
                string categoryInput = Console.ReadLine();
                if (Enum.TryParse<TaskCategory>(categoryInput, out TaskCategory category))
                {
                    await taskManager.AddTaskAsync(name, description, category);
                    Console.WriteLine("Task added successfully.");
                }
                else
                {
                    Console.WriteLine("Invalid category.");
                }
            }
            else if (input == "4")
            {
                break; // Exit the loop and end the program
            }
            else
            {
                Console.WriteLine("Invalid option.");
            }
        }
    }
}
