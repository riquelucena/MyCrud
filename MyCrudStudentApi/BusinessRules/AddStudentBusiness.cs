using MyCrudStudentApi.Models;
using MyCrudStudentApi.Repository;

namespace MyCrudStudentApi.BusinessRules
{
    public class AddStudentBusiness : IAddStudentBusiness
    {
        private readonly IStudentRepository _studentRepository;

        public AddStudentBusiness(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public void Add(Student student)
        {
            _studentRepository.Add(student);
        }
    }
}
