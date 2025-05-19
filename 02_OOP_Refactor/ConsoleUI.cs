using System.Net;

public class ConsoleUI
{
    private readonly TasksManager _tasksManager;

    public ConsoleUI(TasksManager manager)
    {
        _tasksManager = manager;
    }

    public void ShowMenu()
    {
        Console.WriteLine("\n~ Welcome to the ToDo List App ~\n");

        while (true)
        {
            Console.Clear();
            Console.WriteLine(@"Choose an option:
                1. Add Regular Task
                2. Add Urgent Task
                3. Print Tasks
                4. Change Task Status
                5. Remove Task
                6. Exit
            ");

            var input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    AddRegularTask();
                    break;
                case "2":
                    AddUrgetnTask();
                    break;
                case "3":
                    PrintTasks();
                    break;
                case "4":
                    ToggleTask();
                    break;
                case "5":
                    RemoveTask();
                    break;
                case "6":
                    Console.WriteLine("Exit\n");
                    return;
                default:
                    Console.WriteLine("Invalid Option");
                    break;
            }

            Console.WriteLine("\nPress any key to return to the menu\n");
            Console.ReadKey();
        }
    }

    public void AddRegularTask()
    {
        Console.Clear();
        Console.WriteLine("Add A Regular Task");

        Console.WriteLine("Enter A Task Description: ");
        string? description = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(description))
        {
            Console.WriteLine("Error: The description cannot be empty");
            Console.ReadKey();
            return;
        }

        Console.WriteLine("Enter an End Time: (yyyy-MM-dd)");
        string? dateInput = Console.ReadLine();

        if (!DateTime.TryParse(dateInput, out DateTime daueDate))
        {
            Console.WriteLine("Date format is not valid");
            Console.ReadKey();
            return;
        }

        try
        {
            var task = new RegularTask(description, daueDate);
            _tasksManager.AddTask(task);
            
            Console.WriteLine("Task was succefuly added");
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"Error {ex.Message}");
        }
    }

    public void AddUrgetnTask()
    {
        //todo
    }

    public void PrintTasks()
    {
        _tasksManager.PrintAll();
    }

    public void ToggleTask()
    {
        if (_tasksManager.Count == 0)
        {
            System.Console.WriteLine("No Tasks to toggle");
            return;
        }

        int index = PromptForTaskIndex("Enter Task Index: ");
        _tasksManager.ToggleTask(index);
    }

    public void RemoveTask()
    {
        if (_tasksManager.Count == 0)
        {
            System.Console.WriteLine("No Tasks to remove");
            return;
        }

        int index = PromptForTaskIndex("Enter Task Index To Remove: ");
        _tasksManager.DeleteTask(index);
    }


    private int PromptForTaskIndex(string prompt)
    {
        while (true)
        {
            Console.WriteLine(prompt);
            string? input = Console.ReadLine();

            if (int.TryParse(input, out int num))
            {
                int index = num - 1;

                if (_tasksManager.IsValidIndex(index))
                {
                    return index;
                }
            }

            Console.WriteLine("Invalid input. Please Try again : ");
        }
    }
}