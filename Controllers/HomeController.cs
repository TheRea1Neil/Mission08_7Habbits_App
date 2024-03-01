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
        public IActionResult Create_Tasks()
        {
            ViewBag.Categories = _repo.Categories.ToList();
            return View();
        }


        [HttpGet]
        public IActionResult Edit(int id)
        {
            var recordToEdit = _repo.Tasks
                .Single(x => x.TaskID == id);

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

        [HttpPost]
        public IActionResult Delete(int taskId)
        {
            Console.Write(taskId);
            var recordToDelete = _repo.Tasks.Single(x => x.TaskID == taskId);
            if (recordToDelete != null)
            {
                _repo.Tasks.Remove(recordToDelete);
                _repo.SaveChanges();
            }
            else
            {
                Console.Write("test");
            }

            return RedirectToAction("Index");
        }


    }
}
