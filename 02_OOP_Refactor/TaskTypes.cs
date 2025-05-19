public class RegularTask : BaseTaskItem
{
    public RegularTask(string description, DateTime endTime) : base(description, endTime)
    { }

    public override void PrintDetails()
    {
        Console.WriteLine($"[Regular] | {Description} | {EndTime:d} | {(IsCompleted ? "V" : "X")}");
    }
}

public class UrgentTask : BaseTaskItem
{
    public int PriorityLevel { get; private set; }

    public UrgentTask(string description, DateTime endTime, int priority) : base(description, endTime)
    {
        PriorityLevel = priority;
    }

    public override void PrintDetails()
    {
        Console.WriteLine($"[Urgent {PriorityLevel}] | {Description} | {EndTime:d} | {(IsCompleted ? "V" : "X")}");
    }
}