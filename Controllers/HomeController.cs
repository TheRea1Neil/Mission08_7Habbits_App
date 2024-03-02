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
        private iTaskRepository _repo;

        public HomeController(iTaskRepository context) //Constructor
        {
            _repo = context;
        }
       


        public IActionResult Index()
        {

            var tasks = _repo.Tasks
                .OrderBy(x => x.TaskID);

            ViewBag.category = _repo.Categories
                .ToList();

            ViewBag.Quadrant1 = _repo.Tasks.Where(x => x.Quadrant == 1).ToList();
            ViewBag.Quadrant2 = _repo.Tasks.Where(x => x.Quadrant == 2).ToList();
            ViewBag.Quadrant3 = _repo.Tasks.Where(x => x.Quadrant == 3).ToList();
            ViewBag.Quadrant4 = _repo.Tasks.Where(x => x.Quadrant == 4).ToList();
            

            return View();
        }

        //        <h2>Quadrant 1 Tasks</h2>
        //@foreach(var task in Model.Quadrant1)
        //        {
        //    < p > @task.Name </ p > < !--Replace with actual property names -->}
        [HttpGet]
        public IActionResult CreateTask()
        {
            ViewBag.Categories = _repo.Categories.ToList();
            return View(new Mission08_7Habbits_App.Models.Task());
        }

        [HttpPost]
        public IActionResult CreateTask(Mission08_7Habbits_App.Models.Task _newTask)
        {
            if (ModelState.IsValid)
            {
                _repo.AddTask( _newTask);

                ViewBag.category = _repo.Categories
                    .Single(x => x.CategoryID == _newTask.CategoryID);

                return View("Confirmation", _newTask);
            }
            else
            {
                ViewBag.Categories = _repo.Categories.ToList();

                return View(_newTask);
            }
        }


        [HttpGet]
        public IActionResult Edit(int id)
        {
            var recordToEdit = _repo.Tasks
                .Single(x => x.TaskID == id);

            ViewBag.Categories = _repo.Categories.ToList();

            return View("CreateTask", recordToEdit);
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
            Console.WriteLine(id);
            var recordToDelete = _repo.Tasks.Single(x => x.TaskID == id);
         
            
                _repo.Remove(recordToDelete);
                _repo.SaveChanges();
          

            return RedirectToAction("Index");
        }


    }
}
