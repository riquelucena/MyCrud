using Microsoft.AspNetCore.Mvc;
using MyCrudStudentApi.BusinessRules;
using MyCrudStudentApi.Input;
using MyCrudStudentApi.Output;

namespace MyCrudStudentApi.Controllers
{
    [ApiController]
    [Route("controller")]
    public class StudentController : ControllerBase
    {

        private readonly IAddStudentBusiness _addBusiness;
        private readonly IGetStudentBusiness _getBusiness;
        private readonly IGetStudentByIdBusiness _getByIdBusiness;
        private readonly IUpdateStudentBusiness _updateBusiness;
        private readonly IDeleteStudentBusiness _deleteBusiness;

        public StudentController(
            IAddStudentBusiness addBusiness,
            IGetStudentBusiness getBusiness,
            IGetStudentByIdBusiness getByIdBusiness,
            IUpdateStudentBusiness updateBusiness,
            IDeleteStudentBusiness deleteBusiness)
        {
            _addBusiness = addBusiness;
            _getBusiness = getBusiness;
            _getByIdBusiness = getByIdBusiness;
            _updateBusiness = updateBusiness;
            _deleteBusiness = deleteBusiness;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public IActionResult AddStudent([FromBody] StudentInput input)
        {
            var student = input.Mirror();
            _addBusiness.Add(student);
            return CreatedAtAction(nameof(GetStudentById), new { id = student.Id }, student);
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetStudent([FromQuery] int skip = 0, [FromQuery] int take = 10)
        {
            var students = _getBusiness.Get()
                .Select(student => new ResumeStudentOutput(student))
                .ToList();
;
            return Ok(students);
        }

        [HttpGet("{Id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetStudentById(int id)
        {
            var student = _getByIdBusiness.GetById(id);
            if (student is null)
            {
                return NotFound();
            }
            return Ok(student);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult UpdateStudent(int id, [FromBody] StudentInput input)
        {
            var existingStudent = _getByIdBusiness.GetById(id);
            var student = input.Mirror();

            if (existingStudent is null)
            {
                return NotFound();
            }            

            existingStudent.StudentName = student.StudentName;
            existingStudent.BirthDate = student.BirthDate;
            existingStudent.FatherName = student.FatherName;
            existingStudent.MotherName = student.MotherName;
            existingStudent.Email = student.Email;
            _updateBusiness.Update(id, existingStudent);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult DeleteStudent(int id)
        {

            var student = _getByIdBusiness.GetById(id);
            if (student is null)
            {
                return NotFound();
            }
            _deleteBusiness.Delete(id);
            return NoContent();
        }
    }
}
