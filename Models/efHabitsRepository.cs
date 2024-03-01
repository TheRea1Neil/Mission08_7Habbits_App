namespace Mission08_7Habbits_App.Models
{
    public class efHabitsRepository : iHabitsRepository //Look at me, look at me, i'm the HomeController now 
    {
        private HighHabitsContext context;

        public efHabitsRepository(HighHabitsContext temp )
        {
            context = temp;
        }

        

    }
}
