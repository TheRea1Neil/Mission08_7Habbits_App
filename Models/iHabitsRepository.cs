
namespace Mission08_7Habbits_App.Models
{
    public interface iHabitsRepository //
    {
        IEnumerable<object> Tasks { get; }
        object Categories { get; }
    }
}
