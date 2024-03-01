namespace Mission08_7Habbits_App.Models
{
    public interface iTaskRepository
    {
        List<Task> Tasks { get; }
        List<Category> Categories { get; }

        void SaveChanges(bool v);
        void SaveChanges();
        void Update(Task update);

        void Remove(Task category);
    }
}
