public interface ITaskItem
{
    void PrintDetails();
    void ToggleTask();
    bool IsOverdue();

    string Description { get; }
}