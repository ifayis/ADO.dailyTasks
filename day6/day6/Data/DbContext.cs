using Microsoft.EntityFrameworkCore;
using day6.Model;

namespace day6.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(
                "Server=localhost\\SQLEXPRESS;Database=newstudentsDB;Trusted_Connection=True;");
        }
    }
}
