using System;
using System.Linq;
using AutoMapper;
using day5.Data;
using day5.Mapping;
using day5.Models;

namespace day5
{
    internal class Program
    {
        static void Main()
        {
            // AutoMapper setup
            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });

            var mapper = mapperConfig.CreateMapper();

            using var context = new AppDbContext();

            // INSERT Department
            var dept = new Department { Name = "IT" };
            context.Departments.Add(dept);
            context.SaveChanges();

            // INSERT Employee
            var emp = new Employee
            {
                Name = "Fayis",
                Salary = 50000,
                DepartmentId = dept.Id
            };

            context.Employees.Add(emp);
            context.SaveChanges();

            // READ + Lazy Loading
            var employee = context.Employees.First();

            // Department is NOT loaded yet
            Console.WriteLine("Employee Name: " + employee.Name);

            // Department loads HERE (lazy loading)
            Console.WriteLine("Department: " + employee.Department.Name);

            // AutoMapper → DTO
            var dto = mapper.Map<DTOs.EmployeeDto>(employee);

            Console.WriteLine("\nDTO Output:");
            Console.WriteLine($"{dto.Name} - {dto.Salary} - {dto.DepartmentName}");

            Console.ReadKey();
        }
    }
}
