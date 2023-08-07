using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

public enum TaskCategory
{
    school,
    family,
    Personal,
    Work,
    Errands,

    Other

}

public class TodoTask
{
    public string? Name { get; set; }
    public string? Description { get; set; }
    public TaskCategory Category { get; set; }
    public bool IsCompleted { get; set; }
}

// This manager will be responsible for loading and saving all of our tasks to a CSV file on disk

public class TaskManager
{
    private List<TodoTask> tasks = new List<TodoTask>();
    private readonly string dataFilePath = "tasks.csv";

    public TaskManager()
    {
        // Load tasks from the file when the TaskManager is initialized
        try
        {
            LoadTasksFromFileAsync(dataFilePath).Wait();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error loading tasks from file: {ex.Message}");
        }
    }

    public async Task AddTaskAsync(string name, string description, TaskCategory category)
    {
        // Validate user input
        if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(description))
        {
            Console.WriteLine("Invalid input. Name and description cannot be empty.");
            return;
        }

        TodoTask newTask = new TodoTask
        {
            Name = name,
            Description = description,
            Category = category,
            IsCompleted = false
        };

        tasks.Add(newTask);
        await SaveTasksToFileAsync(dataFilePath);
    }

    public void ViewAllTasks()
    {
        Console.WriteLine("All Tasks:");
        Console.WriteLine("---------------------------------------------------");
        Console.WriteLine("|   Name   |   Description   |   Category   |   IsCompleted   |");
        Console.WriteLine("---------------------------------------------------");

        foreach (var task in tasks)
        {
            Console.WriteLine($" {task.Name,-8}  {task.Description,-15}  {task.Category,-11}  {task.IsCompleted,-14} ");
        }

        Console.WriteLine("---------------------------------------------------");
    }

    //filter tasks by catagory
    public List<TodoTask> GetTasksByCategory(TaskCategory category)
    {
        return tasks.Where(t => t.Category == category).ToList();
    }


    // save task to file
    public async Task SaveTasksToFileAsync(string filePath)
    {
        try
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                foreach (var task in tasks)
                {
                    await writer.WriteLineAsync($"{task.Name},{task.Description},{task.Category},{task.IsCompleted}");
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error saving tasks to file: {ex.Message}");
        }
    }

    public async Task LoadTasksFromFileAsync(string filePath)
    {
        try
        {
            if (File.Exists(filePath))
            {
                tasks.Clear();
                using (StreamReader reader = new StreamReader(filePath))
                {
                    string line;
                    while ((line = await reader.ReadLineAsync()) != null)
                    {
                        string[] parts = line.Split(',');
                        if (parts.Length == 4)
                        {
                            TodoTask task = new TodoTask
                            {
                                Name = parts[0],
                                Description = parts[1],
                                Category = (TaskCategory)Enum.Parse(typeof(TaskCategory), parts[2]),
                                IsCompleted = bool.Parse(parts[3])
                            };
                            tasks.Add(task);
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error loading tasks from file: {ex.Message}");
        }
    }
}
