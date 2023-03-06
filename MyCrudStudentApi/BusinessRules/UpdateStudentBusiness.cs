using MyCrudStudentApi.Models;
using MyCrudStudentApi.Repository;
using System.Runtime.CompilerServices;

namespace MyCrudStudentApi.BusinessRules
{
    public class UpdateStudentBusiness : IUpdateStudentBusiness
    {
        private readonly IStudentRepository _studentRepository;

        public UpdateStudentBusiness(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public void Update(int id, Student studentToUpdate)
        {
            _studentRepository.Update(id, studentToUpdate);
        }
    }
}
