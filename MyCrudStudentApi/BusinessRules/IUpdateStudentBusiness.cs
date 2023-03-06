using MyCrudStudentApi.Models;

namespace MyCrudStudentApi.BusinessRules
{
    public interface IUpdateStudentBusiness
    {
        void Update(int id, Student studentToUpdate);
    }
}