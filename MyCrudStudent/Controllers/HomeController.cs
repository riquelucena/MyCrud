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
            try
            {
                StudentRepository.AddStudent(student);
                return View("RegistrySucessfull", student);
            }
            catch (Exception ex)
            {
                ViewData["Message"] = ex.Message;
                return View("ErrorPage");
            }
            
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
            var result = SearchStudent.Search(textField);
            return View(result);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}