using System.ComponentModel.DataAnnotations;

namespace MyCrudStudentApi.Models
{
    public class Student
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome do aluno é obrigatório.")]
        [StringLength(255, MinimumLength = 10)]
        public string? StudentName { get; set; }

        [Required(ErrorMessage = "A data de nascimento é obrigatória.")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? BirthDate { get; set; }

        [Required(ErrorMessage = "O nome do pai aluno é obrigatório.")]
        [StringLength(255, MinimumLength = 10)]
        public string? FatherName { get; set; }

        [Required(ErrorMessage = "O nome da mãe aluno é obrigatório.")]
        [StringLength(255, MinimumLength = 10)]
        public string? MotherName { get; set; }

        [Required(ErrorMessage = "O e-mail para contato é obrigatório.")]
        [EmailAddress(ErrorMessage = "E-mail em formato inválido.")]
        public string? Email { get; set; }

        public Student Model()
        {
            var model = new Student();
            model.Id = this.Id;
            model.StudentName = this.StudentName;
            model.BirthDate = this.BirthDate ?? DateTime.MinValue;
            model.FatherName = this.FatherName;
            model.MotherName = this.MotherName;
            model.Email = this.Email;
            return model;
        }
    }
}
