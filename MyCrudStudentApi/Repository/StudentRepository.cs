using Azure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using MyCrudStudentApi.ApplicationContext;
using MyCrudStudentApi.Models;
using MyCrudStudentApi.Output;

namespace MyCrudStudentApi.Repository
{
    public class StudentRepository : IStudentRepository
    {
        private readonly DataContext context;

        public StudentRepository(DataContext context)
        {
            this.context = context;
        }

        public void Add(Student student)
        {
            context.Set<Student>().Add(student);
            context.SaveChanges();
        }

        public IEnumerable<Student> Get([FromQuery] int skip = 0, [FromQuery] int take = 10)
        {
            var students = context.Set<Student>()
                .Skip(skip)
                .Take(take)
                .ToList();            
            return students;                
        }

        public Student? GetById(int id)
        {
            var student = context.Set<Student>().SingleOrDefault(s => s.Id == id);
            return student?.Model();
        }

        public void Update(int id, Student studentToUpdate)
        {
            var student = context.Set<Student>().FirstOrDefault(s => s.Id == id);
            if (student is not null)
            {
                student.StudentName = studentToUpdate.StudentName;
                student.BirthDate = studentToUpdate.BirthDate;
                student.FatherName = studentToUpdate.FatherName;
                student.MotherName = studentToUpdate.MotherName;
                student.Email = studentToUpdate.Email;
                context.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            var student = context.Set<Student>().FirstOrDefault(s => s.Id == id);
            if (student is not null)
            {
                context.Set<Student>().Remove(student);
                context.SaveChanges();
            }
        }

        public void AddDataBase(List<Student> students)
        {
            foreach (var student in students)
            {
                context.Set<Student>().Add(student);
            }
            context.SaveChanges();
        }
    }
}
