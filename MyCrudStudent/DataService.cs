using Microsoft.EntityFrameworkCore;
using MyCrudStudent.ApplicationContext;
using MyCrudStudent.Models;
using System.Collections.Generic;

class DataService : IDataService
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