using MyCrudStudentApi.Models;

namespace MyCrudStudentApi.BusinessRules
{
    public interface IGetStudentByIdBusiness
    {
        Student? GetById(int id);
    }
}