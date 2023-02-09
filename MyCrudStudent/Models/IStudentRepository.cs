namespace MyCrudStudent.Models
{
  public interface IStudentRepository
  {
    void Add(Student student);
    void Delete(int id);
    IEnumerable<Student> Search(string? textField = null);
  }
}