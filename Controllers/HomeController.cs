using Microsoft.AspNetCore.Mvc;
using Student_Master_Areas.BAL;
using Student_Master_Areas.Models;
using System.Diagnostics;

namespace Student_Master_Areas.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        [CheckAccess]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

    }
}