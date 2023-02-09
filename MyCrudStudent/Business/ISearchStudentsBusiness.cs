using MyCrudStudent.Models;

namespace MyCrudStudent.Business
{
  public interface ISearchStudentsBusiness {
    IEnumerable<Student> Search(string? searchText = null);
  }
}