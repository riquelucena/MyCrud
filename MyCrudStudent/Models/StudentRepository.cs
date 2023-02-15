using MyCrudStudent.ApplicationContext;

namespace MyCrudStudent.Models
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
            ValidateStudent.Validate(student);

            context.Set<Student>().Add(student);
            context.SaveChanges();
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

        public IEnumerable<Student> Search(string? textField = null)
        {
            var students = context.Set<Student>().AsQueryable();
            if (!string.IsNullOrWhiteSpace(textField))
            {
                students = students.Where(s => s.Id.ToString().Contains(textField) || s.StudentName.Contains(textField) == true);
            }
            return students.Select(s => s.Copy()).ToList();
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
