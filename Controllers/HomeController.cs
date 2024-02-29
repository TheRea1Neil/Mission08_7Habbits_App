using Microsoft.AspNetCore.Mvc;
using Mission08_7Habbits_App.Models;
using System.Diagnostics;

using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Mission08_7Habbits_App.Controllers
{
    public class HomeController : Controller
    {
        private HighHabitsContext _context;

        public HomeController(HighHabitsContext context) //Constructor
        {
            _context = context;
        }
        public class TasksViewModel
        {
            public List<Models.Task> Quadrant1 { get; set; }
            public List<Models.Task> Quadrant2 { get; set; }
            public List<Models.Task> Quadrant3 { get; set; }
            public List<Models.Task> Quadrant4 { get; set; }
        }


        public IActionResult Index()
        {


            var viewModel = new TasksViewModel
            {
                Quadrant1 = _context.Tasks.Where(x => x.Quadrant == 1).ToList(),
                Quadrant2 = _context.Tasks.Where(x => x.Quadrant == 2).ToList(),
                Quadrant3 = _context.Tasks.Where(x => x.Quadrant == 3).ToList(),
                Quadrant4 = _context.Tasks.Where(x => x.Quadrant == 4).ToList()
            };

            return View(viewModel);
        }

        //        <h2>Quadrant 1 Tasks</h2>
        //@foreach(var task in Model.Quadrant1)
        //        {
        //    < p > @task.Name </ p > < !--Replace with actual property names -->}
        public IActionResult Create_Tasks()
        {
            ViewBag.Categories = _context.Categories.ToList();
            return View();
        }


        [HttpGet]
        public IActionResult Edit(int id)
        {
            var recordToEdit = _context.Tasks
                .Single(x => x.TaskId == id);

            ViewBag.Categories = _context.Categories.ToList();

            return View("Create_Tasks", recordToEdit);
        }
        [HttpPost]
        public IActionResult Edit(Models.Task update)
        {
            _context.Update(update);
            _context.SaveChanges(true);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var recordToDelete = _context.Tasks.Single(x => x.TaskId == id);
            return View(recordToDelete);
        }
        [HttpPost]
        public IActionResult Delete(Models.Task task)
        {
            _context.Tasks.Remove(task);
            _context.SaveChanges();

            return RedirectToAction("Index");

        }


    }
}
