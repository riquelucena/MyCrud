namespace MyCrudStudent.Models
{
    public class ValidateStudent
    {
        public static void Validate(Student student)
        {
            if (string.IsNullOrWhiteSpace(student.StudentName))
            {
                throw new ArgumentException("O nome do aluno é obrigatório.");
            }

            if (student.BirthDate == null || student.BirthDate >= DateTime.Now)
            {
                throw new ArgumentException("A data de nascimento do aluno não pode ser igual ou maior que a data atual.");
            }

            if (string.IsNullOrWhiteSpace(student.FatherName))
            {
                throw new ArgumentException("O nome do pai é obrigatório.");
            }

            if (string.IsNullOrWhiteSpace(student.MotherName))
            {
                throw new ArgumentException("O nome da mãe é obrigatório.");
            }

            try
            {
                var addr = new System.Net.Mail.MailAddress(student.Email ?? "");
            }
            catch
            {
                throw new ArgumentException("O e-mail do aluno é inválido.");
            }
        }
    }
}
