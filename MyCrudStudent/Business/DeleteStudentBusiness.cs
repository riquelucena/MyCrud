using MyCrudStudent.Models;

namespace MyCrudStudent.Business;

public class DeleteStudentBusiness : IDeleteStudentBusiness
{
  private readonly IStudentRepository _repository;
  public DeleteStudentBusiness(IStudentRepository repository)
  {
    _repository = repository;
  }

  public void Delete(int id)
  {
    _repository.Delete(id);
  }
}