using Microsoft.EntityFrameworkCore;
using MyCrudStudentApi.Models;

namespace MyCrudStudentApi.ApplicationContext
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Student>().HasKey(s => s.Id);
        }

        public DbSet<Student> students { get; set; }
    }
}
