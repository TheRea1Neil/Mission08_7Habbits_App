
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
    }
}
