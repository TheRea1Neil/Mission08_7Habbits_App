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
            _repo = context; // Implement the Repository Pattern
        }

        public IActionResult Index()
        {

            var tasks = _repo.Tasks
                .OrderBy(x => x.TaskID);

            ViewBag.category = _repo.Categories
                .ToList();

            
            // Seperate tasks based on their Quadrant and save them in ViewBags in order to display in the view
            ViewBag.Quadrant1 = tasks.Where(x => x.Quadrant == 1).ToList();
            ViewBag.Quadrant2 = tasks.Where(x => x.Quadrant == 2).ToList();
            ViewBag.Quadrant3 = tasks.Where(x => x.Quadrant == 3).ToList();
            ViewBag.Quadrant4 = tasks.Where(x => x.Quadrant == 4).ToList();
            

            return View();
        }

        [HttpGet]
        public IActionResult CreateTask()
        {
            // Save categories in Viewbag in order to display in the view
            ViewBag.Categories = _repo.Categories.ToList(); 
            return View(new Mission08_7Habbits_App.Models.Task());
        }

        [HttpPost]
        public IActionResult CreateTask(Mission08_7Habbits_App.Models.Task _newTask)
        {
            // If user input meets the required conditions, save the record (task) to database, and then show the saed record in the "Confiramtion" page 
            if (ModelState.IsValid)
            {
                _repo.AddTask( _newTask);

                ViewBag.category = _repo.Categories
                    .Single(x => x.CategoryID == _newTask.CategoryID);

                return View("Confirmation", _newTask);
            }
            // If not, keep the same info user has put in and give them error message
            // (accomplish by "<div asp-validation-summary="All"></div>" in the view, as well as ErrorMessage in the Model)
            else
            {
                ViewBag.Categories = _repo.Categories.ToList();

                return View(_newTask);
            }
        }


        [HttpGet]
        public IActionResult Edit(int id)
        {
            // Return the selected task for user to edit (based on TaskID)
            var recordToEdit = _repo.Tasks
                .Single(x => x.TaskID == id);

            ViewBag.Categories = _repo.Categories.ToList();

            return View("CreateTask", recordToEdit);
        }
        [HttpPost]
        public IActionResult Edit(Models.Task update)
        {
            // update the info for the task and take the user back to Index
            _repo.Update(update);
            _repo.SaveChanges(true);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            // Delelte the selected task based on TaskID
            Console.Write(id);
            var recordToDelete = _repo.Tasks.Single(x => x.TaskID == id);
            if (recordToDelete != null)
            {
                _repo.Tasks.Remove(recordToDelete);
                _repo.SaveChanges();


            }          

            return RedirectToAction("Index");
        }


    }
}
