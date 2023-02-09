using MyCrudStudent.Business;
using MyCrudStudent.Models;

static class IServiceCollectionMyCrudExtensions
{
  public static void AddMyCrudDependencies(this IServiceCollection serviceCollection)
  {
    serviceCollection.AddScoped<IStudentRepository, StudentRepository>();
    serviceCollection.AddScoped<IAddStudentBusiness, AddStudentBusiness>();
    serviceCollection.AddScoped<IDeleteStudentBusiness, DeleteStudentBusiness>();
    serviceCollection.AddScoped<ISearchStudentsBusiness, SearchStudentsBusiness>();
  }
}