using MyCrudStudentApi.Models;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace MyCrudStudentApi.Input
{
    public class StudentInput
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome do aluno é obrigatório.")]
        [StringLength(255, MinimumLength = 10, ErrorMessage = "O tamanho do nome do aluno deve ter entre 10 e 255 caracteres")]
        public string? StudentName { get; set; }

        [Required(ErrorMessage = "A data de nascimento é obrigatória.")]
        public DateTime? BirthDate { get; set; }

        [Required(ErrorMessage = "O nome do pai aluno é obrigatório.")]
        [StringLength(255, MinimumLength = 10, ErrorMessage = "O tamanho do nome do pai do aluno deve ter entre 10 e 255 caracteres")]
        public string? FatherName { get; set; }

        [Required(ErrorMessage = "O nome da mãe aluno é obrigatório.")]
        [StringLength(255, MinimumLength = 10, ErrorMessage = "O tamanho do nome da mãe do aluno deve ter entre 10 e 255 caracteres")]
        public string? MotherName { get; set; }

        [Required(ErrorMessage = "O e-mail para contato é obrigatório.")]
        [EmailAddress(ErrorMessage = "E-mail em formato inválido.")]
        public string? Email { get; set; }

        public Student Mirror()
        {
            var mirror = new Student();
            mirror.Id = this.Id;
            mirror.StudentName = this.StudentName;
            mirror.BirthDate = this.BirthDate ?? DateTime.MinValue;
            mirror.FatherName = this.FatherName;
            mirror.MotherName = this.MotherName;
            mirror.Email = this.Email;
            return mirror;
        }        
    }
}
