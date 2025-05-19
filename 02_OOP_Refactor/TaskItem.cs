using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public abstract class BaseTaskItem : ITaskItem
{
    public string Description { get; protected set; }
    public DateTime EndTime { get; protected set; }
    public bool IsCompleted { get; protected set; }

    public BaseTaskItem(string description, DateTime endTime)
    {
        if (string.IsNullOrWhiteSpace(description))
        {
            throw new ArgumentException("Description cannot be null, empty, or whitespace.", nameof(description));
        }
        
        Description = description;
        EndTime = endTime;

        IsCompleted = false;
    }

    public abstract void PrintDetails();

    public virtual void ToggleTask()
    {
        IsCompleted = !IsCompleted;
    }

    public virtual bool IsOverdue()
    {
        return !IsCompleted && DateTime.Now > EndTime;
    }
}