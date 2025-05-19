using System.Threading.Tasks;

namespace ToDoListApp
{
    public class App
    {
        private static void Main()
        {
            TasksManager manager = new TasksManager();
            ConsoleUI ui = new ConsoleUI(manager);

            ui.ShowMenu();
        }
    }
}