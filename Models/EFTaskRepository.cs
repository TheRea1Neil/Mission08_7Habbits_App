
using SQLitePCL;

namespace Mission08_7Habbits_App.Models
{
    public class EFTaskRepository : iTaskRepository
    {
        private HighHabitsContext _context;

        public EFTaskRepository(HighHabitsContext context) 
        {
            _context = context;
        }

        public List<Task> Tasks => _context.Tasks.ToList();

        public List<Category> Categories => _context.Categories.ToList();

        public void SaveChanges(bool v)
        {
           _context.SaveChanges(v);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public void Update(Task update)
        {
           _context.Update(update);
        }

        public void Remove(Task recordToDelete)
        {
            _context.Remove(recordToDelete);
        }

        public List<Task> Include(Task task)
        {
            throw new NotImplementedException();
        }

        public void AddTask(Task task)
        {
            _context.Add(task);
            _context.SaveChanges();
        }
    }
}
