using System.ComponentModel.DataAnnotations;

namespace MyCrudStudent.Models
{
    public class Student
    {
        public int Id { get; set; }

        public string? StudentName { get; set; }

        public DateTime BirthDate { get; set; }

        public string? FatherName { get; set; }

        public string? MotherName { get; set; }

        public string? Email { get; set; }
    }
}