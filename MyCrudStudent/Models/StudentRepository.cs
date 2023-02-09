namespace MyCrudStudent.Models
{
    public class StudentRepository : IStudentRepository
    {
        private static IList<Student> students = new List<Student>();
        private static int lastId = 0;

        public void Add(Student student)
        {
            ValidateStudent.Validate(student);

            student.Id = ++lastId;
            students.Add(student);
        }
        public void Delete(int id)
        {
            var student = students.Where(x => x.Id == id).FirstOrDefault();
            if (student is not null)
                students.Remove(student);
        }

        public IEnumerable<Student> Search(string? textField = null)
        {
            if (!string.IsNullOrWhiteSpace(textField))
                return students.Where(s => s.Id.ToString().Contains(textField) || s.StudentName?.Contains(textField) == true);
            return students.Select(x => x.Copy()).ToList();
        }
    }
}
