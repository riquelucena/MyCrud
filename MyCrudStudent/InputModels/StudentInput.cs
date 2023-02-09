using System.ComponentModel.DataAnnotations;
using MyCrudStudent.Models;

namespace MyCrudStudent.InputModels
{
    public class StudentInput
    {
        public int Id { get; set; }

        public string? StudentName { get; set; }

        public DateTime BirthDate { get; set; }

        public string? FatherName { get; set; }

        public string? MotherName { get; set; }

        public string? Email { get; set; }

        public Student ToModel() {
            var model = new Student();
            model.Id = this.Id;
            model.StudentName = this.StudentName;
            model.BirthDate = this.BirthDate;
            model.FatherName = this.FatherName;
            model.MotherName = this.MotherName;
            model.Email = this.Email;
            return model;
        }
    }
}