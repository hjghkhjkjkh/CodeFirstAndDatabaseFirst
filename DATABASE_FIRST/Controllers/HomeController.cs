using DATABASE_FIRST.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DATABASE_FIRST.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly SinhviensContext sinhviensContext;

        public HomeController(ILogger<HomeController> logger, SinhviensContext sinhviensContext)
        {
            _logger = logger;
            this.sinhviensContext = sinhviensContext;
        }

        public IActionResult Index()
        {
            var sinhvien = sinhviensContext.Sinhviens.ToList();
            return View();
        }

        public IActionResult Privacy()
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
