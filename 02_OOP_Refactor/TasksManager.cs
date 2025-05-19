public class TasksManager
{
    private readonly List<ITaskItem> _tasks = new();
    public int Count => _tasks.Count;

    public void AddTask(ITaskItem task)
    {
        _tasks.Add(task);
    }

    public void PrintAll()
    {
        for (int i = 0; i < _tasks.Count; i++)
        {
            Console.Write($"#{(i + 1)} | ");
            _tasks[i].PrintDetails();
        }
    }

    public void ToggleTask(int index)
    {
        if (index >= 0 && index < Count)
        {
            _tasks[index].ToggleTask();
        }
    }

    public void DeleteTask(int index)
    {
        if (index >= 0 && index < Count)
        {
            _tasks.RemoveAt(index);
        }
    }

    public bool IsValidIndex(int index)
    {
        return (index >= 0) && (index < _tasks.Count);
    }
}