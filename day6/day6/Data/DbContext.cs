using day6.Models;
using Microsoft.EntityFrameworkCore;

namespace day6.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            if (!options.IsConfigured)
            {
                options.UseSqlServer(
                    "Server=localhost\\SQLEXPRESS;Database=newstudentsDB;Trusted_Connection=True;TrustServerCertificate=True");
            }
        }
    }
}
