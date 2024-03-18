using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TP3_EcoWatch.Models;

namespace TP3_EcoWatch.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            ViewBag.UserEmail = HttpContext.Session.GetString("UserEmail");
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult Analytics()
        {
            return View();
        }
        public IActionResult Communities()
        {
            return View();
        }
        public IActionResult About()
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
