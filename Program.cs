using Indvidual_Project_Todolist;
using Task = Indvidual_Project_Todolist.Task;

TaskList taskList = TaskList.Load("tasks.json");

Console.WriteLine("Pick and Option: ");
Console.WriteLine("(1). Print the list of tasks");
Console.WriteLine("(2). Add new task");
Console.WriteLine("(3). Edit a task");
Console.WriteLine("(4). Remove a task");
Console.WriteLine("(5). Save and Quit");

while (true)
{
    string checkInput = Console.ReadLine().Trim();

    // Quit the program
    if (checkInput == "5")
    {
        taskList.Save("tasks.json");
        break;
    }
    switch (checkInput)
    {
        // Print the list of tasks
        case "1":
            Console.WriteLine("Sort by Date or Project");
            string filter = Console.ReadLine().ToLower();
            if (filter == "date")
            {
                taskList.Tasks = taskList.Tasks.OrderBy(p => p.Date).ToList();
            }
            else if (filter == "project")
            {
                taskList.Tasks = taskList.Tasks.OrderBy(p => p.Project).ToList();
            }
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Title".PadRight(20) + "Due Date".PadRight(20) + "Status".PadRight(20) + "Project");
            Console.ResetColor();

            taskList.PrintTasks();
            break;
        // Add new task
        case "2":
            {
                Console.Write("Enter a Title: ");
                string title = Console.ReadLine();

                if (taskList.Contains(title))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Task already exists in the list.");
                    Console.ResetColor();
                    break;
                }

                Console.Write("Enter a Due Date: ");
                string date = Console.ReadLine();

                Console.Write("Enter a Status: ");
                string status = (Console.ReadLine());

                Console.Write("Enter a Project: ");
                string project = Console.ReadLine();

                Task newTask = new Task(title, DateTime.Parse(date), Enum.Parse<Task.Status>(status, true), project);

                taskList.AddTask(newTask);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Task added successfully.");
                Console.ResetColor();

                break;
            }
        // Edit a task
        case "3":
            {
                Console.Write("Enter the Task Title you want to edit: ");
                string oldTitle = Console.ReadLine();
                if (!taskList.Contains(oldTitle))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Task not found.");
                    Console.ResetColor();
                    break;
                }
                Task oldTask = taskList.Tasks.Find(p => p.Title.ToLower() == oldTitle.ToLower());
                Console.WriteLine("Old Title = " + oldTask.Title);
                Console.WriteLine("Enter the New title: ");
                string newTitle = Console.ReadLine();

                if (taskList.Contains(newTitle) && oldTitle != newTitle)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Task already exists in the list.");
                    Console.ResetColor();
                    break;
                }
                newTitle = newTitle == "" ? oldTask.Title : newTitle;

                Console.WriteLine("Old Date = " + oldTask.Date.ToString("yyyy-MM-dd"));
                Console.WriteLine("Enter a Due Date: ");
                string date = Console.ReadLine();
                date = date == "" ? oldTask.Date.ToString("yyyy-MM-dd") : date;

                Console.WriteLine("Old Status = " + oldTask.Stat);
                Console.WriteLine("Enter a Status: ");
                string status = Console.ReadLine();
                status = status == "" ? oldTask.Stat.ToString() : status;

                Console.WriteLine("Old Project Name = " + oldTask.Project);
                Console.WriteLine("Enter a Project: ");
                string project = Console.ReadLine();
                project = project == "" ? oldTask.Project : project;

                Task newTask = new Task(newTitle, DateTime.Parse(date), Enum.Parse<Task.Status>(status, true), project);

                taskList.RemoveTask(oldTask);
                taskList.AddTask(newTask);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("Succesfully edited");
                Console.ResetColor();
                break;
            }
        case "4":
            {
                Console.Write("Enter the Task Title you want to remove: ");
                string title = Console.ReadLine();
                if (!taskList.Contains(title))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Task not found.");
                    Console.ResetColor();
                    break;
                }
                Task task = taskList.Tasks.Find(p => p.Title.ToLower() == title.ToLower());
                taskList.Tasks.Remove(task);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Task removed successfully.");
                Console.ResetColor();
                break;
            }

        // If the input is invalid, print an error message
        default:
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid input. Please try again.");
                Console.ResetColor();
                Console.WriteLine("Pick and Option: ");
                Console.WriteLine("(1). Print the list of tasks");
                Console.WriteLine("(2). Add new task");
                Console.WriteLine("(3). Edit a task");
                Console.WriteLine("(4). Remove a task");
                Console.WriteLine("(5). Save and Quit");
                break;
            }
    }
}

