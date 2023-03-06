using MyCrudStudentApi.Models;

namespace MyCrudStudentApi.Output
{
    public class ResumeStudentOutput
    {
        public ResumeStudentOutput(Student student)
        {
            Id = student.Id;
            StudentName = student.StudentName;
        }

        public int Id { get; set; }
        public string StudentName { get; set;}
    }
}
