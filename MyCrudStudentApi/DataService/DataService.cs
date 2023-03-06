using Microsoft.EntityFrameworkCore;
using MyCrudStudentApi.ApplicationContext;
using MyCrudStudentApi.Models;
using MyCrudStudentApi.Repository;

namespace MyCrudStudentApi.DataService
{
    public class DataService : IDataService
    {
        private readonly DataContext context;
        private readonly IStudentRepository studentRepository;

        public DataService(DataContext context, IStudentRepository studentRepository)
        {
            this.context = context;
            this.studentRepository = studentRepository;
        }

        public void initializeDB()
        {
            context.Database.Migrate();
            var students = new List<Student>();

            studentRepository.AddDataBase(students);
        }
    }
}
