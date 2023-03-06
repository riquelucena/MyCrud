using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using Microsoft.EntityFrameworkCore;
using MyCrudStudentApi.ApplicationContext;
using MyCrudStudentApi.BusinessRules;
using MyCrudStudentApi.DataService;
using MyCrudStudentApi.Repository;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("StudentConnection");

builder.Services.AddDbContext<DataContext>(options
    => options.UseSqlServer(connectionString));

builder.Services.AddScoped<IStudentRepository, StudentRepository>();
builder.Services.AddScoped<IAddStudentBusiness, AddStudentBusiness>();
builder.Services.AddScoped<IGetStudentBusiness, GetStudentBusiness>();
builder.Services.AddScoped<IGetStudentByIdBusiness, GetStudentByIdBusiness>();
builder.Services.AddScoped<IUpdateStudentBusiness, UpdateStudentBusiness>();
builder.Services.AddScoped<IDeleteStudentBusiness, DeleteStudentBusiness>();

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

CreateScope(app);

static void CreateScope(WebApplication app)
{
    using (var scope = app.Services.CreateScope())
    {
        scope.ServiceProvider.GetRequiredService<IDataService>().initializeDB();
    }
}