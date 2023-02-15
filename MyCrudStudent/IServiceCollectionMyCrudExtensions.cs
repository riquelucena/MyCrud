using Microsoft.EntityFrameworkCore;
using MyCrudStudent.ApplicationContext;
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
        AddConnectionString(serviceCollection);
        serviceCollection.AddTransient<IDataService, DataService>();
    }

    private static void AddConnectionString(IServiceCollection serviceCollection)
    {
        var configuration = serviceCollection.BuildServiceProvider().GetService<IConfiguration>();

        if (configuration is not null)
        {
            var connectionString = configuration.GetConnectionString("Default");
            serviceCollection.AddDbContext<DataContext>(options => options.UseSqlServer(connectionString));
        }
    }
}