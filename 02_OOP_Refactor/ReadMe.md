# ToDo Console App – OOP Refactored

## Description

A console application for managing a list of tasks.  
Users can:

- Add regular or urgent tasks
- View all tasks
- Change task status
- Delete tasks

All tasks are stored in memory using `List<ITaskItem>`.

---

## UI – Main Menu

Choose an option:
	Add Regular Task
	Add Urgent Task
	Print Tasks
	Change Task Status
	Delete Task
	Exit


---

## User Actions

- **Add Task:**  
  Input task description and due date.  
  Default status is `X`.

- **Delete Task:**  
  Input task number (validated against task list).

---

## OOP Refactoring Highlights

- Introduced `ITaskItem` interface
- Created `BaseTaskItem` abstract class
- Implemented polymorphism via `PrintDetails()` per task type
- Separated concerns:
  - `TaskManager` handles logic
  - `ConsoleUI` handles input/output

---

## Run the App

```bash \ cmd
dotnet run
