using Microsoft.AspNetCore.Mvc;
using MyCrudStudentApi.Models;

namespace MyCrudStudentApi.BusinessRules
{
    public interface IGetStudentBusiness
    {
        IEnumerable<Student> Get([FromQuery] int skip = 0, [FromQuery] int take = 10);
    }
}