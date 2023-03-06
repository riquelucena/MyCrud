using MyCrudStudentApi.Models;
using MyCrudStudentApi.Repository;

namespace MyCrudStudentApi.BusinessRules
{
    public class GetStudentByIdBusiness : IGetStudentByIdBusiness
    {
        private readonly IStudentRepository _studentRepository;

        public GetStudentByIdBusiness(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public Student? GetById(int id)
        {
            return _studentRepository.GetById(id);
        }
    }
}
