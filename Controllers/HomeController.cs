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
        private iHabitsRepository _repo;

        public HomeController(iHabitsRepository context) //Constructor
        {
            _repo = context;
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
                Quadrant1 = _repo.Tasks.Where(x => x.Quadrant == 1).ToList(),
                Quadrant2 = _repo.Tasks.Where(x => x.Quadrant == 2).ToList(),
                Quadrant3 = _repo.Tasks.Where(x => x.Quadrant == 3).ToList(),
                Quadrant4 = _repo.Tasks.Where(x => x.Quadrant == 4).ToList()
            };

            return View(viewModel);
        }

        //        <h2>Quadrant 1 Tasks</h2>
        //@foreach(var task in Model.Quadrant1)
        //        {
        //    < p > @task.Name </ p > < !--Replace with actual property names -->}
        public IActionResult Create_Tasks()
        {
            ViewBag.Categories = _repo.Categories.ToList();
            return View();
        }


        [HttpGet]
        public IActionResult Edit(int id)
        {
            var recordToEdit = _repo.Tasks
                .Single(x => x.TaskId == id);

            ViewBag.Categories = _repo.Categories.ToList();

            return View("Create_Tasks", recordToEdit);
        }
        [HttpPost]
        public IActionResult Edit(Models.Task update)
        {
            _repo.Update(update);
            _repo.SaveChanges(true);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var recordToDelete = _repo.Tasks.Single(x => x.TaskId == id);
            return View(recordToDelete);
        }
        [HttpPost]
        public IActionResult Delete(Models.Task task)
        {
            _repo.Tasks.Remove(task);
            _repo.SaveChanges();

            return RedirectToAction("Index");

        }


    }
}
