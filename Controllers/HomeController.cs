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


        //    var Quadrant1 = _context.Mission08_7Habbits_App
        //       (x => x.Quadrant == 1).ToList();
        //    var Quadrant2 = _context.Mission08_7Habbits_App
        //      (x => x.Quadrant == 2).ToList();
        //    var Quadrant3 = _context.Mission08_7Habbits_App
        //      (x => x.Quadrant == 3).ToList();
        //    var Quadrant4 = _context.Mission08_7Habbits_App
        //      (x => x.Quadrant == 4).ToLitst;

        //    return View(Quadrant1, Quadrant2, Quadrant3, Quadrant4);
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
