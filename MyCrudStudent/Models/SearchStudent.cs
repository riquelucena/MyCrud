namespace MyCrudStudent.Models
{
    public class SearchStudent : StudentRepository
    {
        public static IEnumerable<Student> Search(string textField)
        {
            var result = students.Where(s => s.Id.ToString().Contains(textField) || s.StudentName?.Contains(textField) == true);
            return result;
        }

    }
}
