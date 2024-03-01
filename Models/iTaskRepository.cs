namespace Mission08_7Habbits_App.Models
{
    public interface iTaskRepository
    {
        List<Task> Tasks { get; }
        List<Category> Categories { get; }

        public void AddTask(Task task);
        public void SaveChanges(bool v);
        public void SaveChanges();
        List<Task> Include(Task task);
        public void Update(Task update);

        public void Remove(Task category);
    }
}
