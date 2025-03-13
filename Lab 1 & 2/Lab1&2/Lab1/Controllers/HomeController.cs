using Lab1.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Lab1.Controllers
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
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult ThrowError()
        {
            try
            {
                throw new Exception("Тестова помилка!");
            }
            catch (Exception ex)
            {
                return View("Error", ex);
            }

        }

        public IActionResult BadRequestTest(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                return BadRequest("Ім'я є обов'язковим!");
            }
            return Content($"Привіт, {name}");
        }

        public IActionResult ForbiddenTest()
        {
            return Forbid();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}