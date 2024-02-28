using Microsoft.AspNetCore.Mvc;
using Mission08_7Habbits_App.Models;
using System.Diagnostics;

namespace Mission08_7Habbits_App.Controllers
{
    public class HomeController : Controller
    {
        private HighHabitsContext _context;

        public HomeController(HighHabitsContext context) //Constructor
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create_Tasks()
        {
            return View();
        }

        public IActionResult Quadrants()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
