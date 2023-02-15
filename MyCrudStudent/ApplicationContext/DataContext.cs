using Microsoft.EntityFrameworkCore;
using MyCrudStudent.Models;

namespace MyCrudStudent.ApplicationContext
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Student>().HasKey(student => student.Id);
        }
        
        public DbSet<Student> students { get;set; }      
    }
}
