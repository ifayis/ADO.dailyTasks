using Microsoft.EntityFrameworkCore;
using day5.Models;

namespace day5.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options
                .UseLazyLoadingProxies()
                .UseSqlServer(
                    "Server=localhost\\SQLEXPRESS;Database=newdepartmentDB;Trusted_Connection=True;TrustServerCertificate=True");
        }
    }
}
