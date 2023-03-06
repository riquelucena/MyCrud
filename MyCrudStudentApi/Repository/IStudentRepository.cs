using Microsoft.AspNetCore.Mvc;
using MyCrudStudentApi.Models;

namespace MyCrudStudentApi.Repository
{
    public interface IStudentRepository
    {
        void Add(Student student);
        IEnumerable<Student> Get([FromQuery] int skip = 0, [FromQuery] int take = 10);
        Student? GetById(int id);
        void Update(int id, Student studentToUpdate);
        void Delete(int id);
        void AddDataBase(List<Student> students);
    }
}