using MyCrudStudent.Models;

namespace MyCrudStudent.Business
{
  public class SearchStudentsBusiness : ISearchStudentsBusiness
  {
    private readonly IStudentRepository _repository;

    public SearchStudentsBusiness(IStudentRepository repository)
    {
      _repository = repository;
    }

    public IEnumerable<Student> Search(string? searchText = null)
    {
      return _repository.Search(searchText);
    }
  }
}