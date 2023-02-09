using MyCrudStudent.Models;

namespace MyCrudStudent.OutputModel;

public class StudentResumeOutput
{
  public StudentResumeOutput(Student student)
  {
    Id = student.Id;
    StudentName = student.StudentName;
  }
  public int Id { get; set; }
  public string? StudentName { get; set; }
}