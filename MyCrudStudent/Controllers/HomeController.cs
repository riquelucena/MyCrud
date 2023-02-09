using Microsoft.AspNetCore.Mvc;
using MyCrudStudent.Business;
using MyCrudStudent.InputModels;
using MyCrudStudent.Models;
using MyCrudStudent.OutputModel;
using System.Diagnostics;

namespace MyCrudStudent.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IAddStudentBusiness _addBusiness;
        private readonly IDeleteStudentBusiness _deleteBusiness;
        private readonly ISearchStudentsBusiness _searchBusiness;

        public HomeController(
            ILogger<HomeController> logger,
            IAddStudentBusiness addBusiness,
            IDeleteStudentBusiness deleteBusiness,
            ISearchStudentsBusiness searchBusiness)
        {
            _logger = logger;
            _addBusiness = addBusiness;
            _deleteBusiness = deleteBusiness;
            _searchBusiness = searchBusiness;
        }

        public IActionResult StudentRegistry()
        {
            return View();
        }

        [HttpPost]
        public IActionResult StudentRegistry(StudentInput input)
        {
            try
            {
                _addBusiness.Add(input.ToModel());
                return View("RegistrySucessfull", input);
            }
            catch (Exception ex)
            {
                ViewData["Message"] = ex.Message;
                return View("ErrorPage");
            }
            
        }

        public IActionResult StudentList()
        {
            var students = _searchBusiness
                .Search()
                .Select(student => new StudentResumeOutput(student))
                .ToList();
            
            return View(students);
        }

        public IActionResult Delete(int id)
        {
            _deleteBusiness.Delete(id);
            return View("RemoveSucessfull");
        }

        public IActionResult StudentSearch()
        {
            return View();
        }

        [HttpPost]
        public IActionResult StudentSearch(string textField)
        {
            var result = _searchBusiness.Search(textField);
            return View(result);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}