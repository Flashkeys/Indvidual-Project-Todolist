namespace Indvidual_Project_Todolist
{
    class Task
    {
        public enum Status
        {
            Done,
            InProgress,
            ToDo
        }
        public Task(string Title, DateTime Date, Status Stat, string Project)
        {
            this.Title = Title;
            this.Date = Date;
            this.Stat = Stat;
            this.Project = Project;
        }

        public string Title { get; set; }
        public DateTime Date { get; set; }
        public Status Stat { get; set; }
        public string Project { get; set; }

        public override bool Equals(object? x)
        {
            var task = x as Task;
            if (task == null)
            {
                return false;
            }
            return this.Title == task.Title;
        }
    }
}
