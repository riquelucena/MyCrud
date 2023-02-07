namespace MyCrudStudent.Models
{
    public class StudentRepository
    {
        public static List<Student> students = new List<Student>();

        private static int initialId = 0;

        public static void AddStudent(Student student)
        {
            student.Id = ++initialId;
            students.Add(student);
        }
                      
        public static IEnumerable<Student> SearchStudent(string textField)
        {
            var result = students.Where(s => s.Id.ToString().Contains(textField) || s.StudentName?.Contains(textField) == true);
            return result;
        }

        public static void DeleteStudent(int id)
        {
            students.RemoveAll(s => s.Id == id);
        }

        public static IEnumerable<Student> StudentList
        {
            get
            {
                return students;
            }
        }
    }
}
