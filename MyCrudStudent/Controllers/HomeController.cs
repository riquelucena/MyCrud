using Microsoft.AspNetCore.Mvc;
using MyCrudStudent.Models;
using System.Diagnostics;

namespace MyCrudStudent.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult StudentRegistry()
        {
            return View();
        }

        [HttpPost]
        public IActionResult StudentRegistry(Student student)
        {
            StudentRepository.AddStudent(student);
            return View("RegistrySucessfull", student);
        }

        public IActionResult StudentList()
        {
            return View(StudentRepository.StudentList);
        }

        public IActionResult Delete(int id)
        {
            StudentRepository.DeleteStudent(id);
            return View("RemoveSucessfull");
        }

        public IActionResult StudentSearch()
        {
            return View();
        }

        [HttpPost]
        public IActionResult StudentSearch(string textField)
        {
            var result = StudentRepository.SearchStudent(textField);
            return View(result);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}