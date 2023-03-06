using MyCrudStudentApi.Repository;

namespace MyCrudStudentApi.BusinessRules
{
    public class DeleteStudentBusiness : IDeleteStudentBusiness
    {
        private readonly IStudentRepository _studentRepository;

        public DeleteStudentBusiness(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public void Delete(int id)
        {
            _studentRepository.Delete(id);
        }
    }
}
