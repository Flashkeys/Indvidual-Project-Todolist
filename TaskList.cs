﻿using System.Text.Json;

namespace Indvidual_Project_Todolist
{
    class TaskList
    {
        public TaskList()
        {
            Tasks = new List<Task>();
        }
        public List<Task> Tasks { get; set; }
        // Add a task to the list
        public void AddTask(Task task)
        {
            Tasks.Add(task);
        }
        // Remove a task from the list
        public void RemoveTask(Task task)
        {
            Tasks.Remove(task);
        }
        // Print the list of tasks
        public void PrintTasks()
        {
            foreach (var task in Tasks)
            {
                Console.Write(task.Title.PadRight(20));
                Console.Write(task.Date.ToString("yyyy-MM-dd").PadRight(20));

                if (task.Stat == Task.Status.Done)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                }
                if (task.Stat == Task.Status.InProgress)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                }
                if (task.Stat == Task.Status.ToDo)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                }

                Console.Write(Enum.GetName<Task.Status>(task.Stat).PadRight(20));
                Console.ResetColor();
                Console.WriteLine(task.Project);
            }
        }
        // Load the task list from a JSON file
        public static TaskList Load(string filePath)
        {
            try
            {
                string contents = System.IO.File.ReadAllText(filePath);
                TaskList? taskList = JsonSerializer.Deserialize<TaskList>(contents);
                if (taskList.Tasks.Count == 0)
                {
                    taskList.AddTask(new Task("Task1", DateTime.Parse("2022-01-01"), Task.Status.Done, "Project1"));
                    taskList.AddTask(new Task("Task2", DateTime.Parse("2022-01-02"), Task.Status.InProgress, "Project2"));
                    taskList.AddTask(new Task("Task3", DateTime.Parse("2022-01-03"), Task.Status.ToDo, "Project3"));
                    taskList.AddTask(new Task("Task4", DateTime.Parse("2023-01-04"), Task.Status.Done, "Project4"));
                    taskList.AddTask(new Task("Task5", DateTime.Parse("2022-01-05"), Task.Status.InProgress, "Project5"));
                    taskList.AddTask(new Task("Task6", DateTime.Parse("2022 -01-06"), Task.Status.ToDo, "Project6"));
                }
                return taskList;
            }
            // If the file is not found, create a new task list with some default tasks
            catch (System.IO.FileNotFoundException)
            {
                TaskList taskList = new TaskList();
                taskList.AddTask(new Task("Task1", DateTime.Parse("2022-01-01"), Task.Status.Done, "Project1"));
                taskList.AddTask(new Task("Task2", DateTime.Parse("2022-01-02"), Task.Status.InProgress, "Project2"));
                taskList.AddTask(new Task("Task3", DateTime.Parse("2022-01-03"), Task.Status.ToDo, "Project3"));
                taskList.AddTask(new Task("Task4", DateTime.Parse("2023-01-04"), Task.Status.Done, "Project4"));
                taskList.AddTask(new Task("Task5", DateTime.Parse("2022-01-05"), Task.Status.InProgress, "Project5"));
                taskList.AddTask(new Task("Task6", DateTime.Parse("2022 -01-06"), Task.Status.ToDo, "Project6"));
                return taskList;
            }
        }
        // Save the task list to a JSON file
        public void Save(string filePath)
        {
            string contents = JsonSerializer.Serialize<TaskList>(this);
            System.IO.File.WriteAllText(filePath, contents);
        }
        public bool Contains(Task task)
        {
            return Tasks.Contains(task);
        }
        public bool Contains(string titleName)
        {
            foreach (var task in Tasks)
            {
                if (task.Title.ToLower() == titleName.ToLower())
                {
                    return true;
                }
            }
            return false;
        }

    }
}
