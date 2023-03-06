using Microsoft.AspNetCore.Mvc;
using MyCrudStudentApi.Models;
using MyCrudStudentApi.Repository;

namespace MyCrudStudentApi.BusinessRules
{
    public class GetStudentBusiness : IGetStudentBusiness
    {
        private readonly IStudentRepository _studentRepository;

        public GetStudentBusiness(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public IEnumerable<Student> Get([FromQuery] int skip = 0, [FromQuery] int take = 10)
        {
            return _studentRepository.Get(skip, take);
        }
    }
}
