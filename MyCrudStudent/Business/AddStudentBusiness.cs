using MyCrudStudent.Models;

namespace MyCrudStudent.Business;

public class AddStudentBusiness : IAddStudentBusiness
{
  private readonly IStudentRepository _repository;
  public AddStudentBusiness(IStudentRepository repository)
  {
    _repository = repository;
  }

  public void Add(Student student)
  {
    _repository.Add(student);
  }
}
