using day6.Data;
using day6.Model;
using System;
using System.Linq;

namespace day6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (var context = new AppDbContext())
            {
                // CREATE
                var student = new Student
                {
                    Name = "Fayis",
                    Age = 22,
                    DOB = new DateTime(2002, 5, 10),
                    Email = "fayis@gmail.com",
                    Phone = "9876543210",
                    Password = "hashed_password",
                    CourseId = 1
                };

                context.Students.Add(student);
                context.SaveChanges();
                Console.WriteLine("Student inserted");

                // READ
                var students = context.Students.ToList();
                foreach (var s in students)
                {
                    Console.WriteLine($"{s.Id} - {s.Name} - {s.Age}");
                }

                // UPDATE
                var single = context.Students.FirstOrDefault(s => s.Id == student.Id);
                if (single != null)
                {
                    single.Age = 23;
                    context.SaveChanges();
                }

                // DELETE
                if (single != null)
                {
                    context.Students.Remove(single);
                    context.SaveChanges();
                }
            }

            Console.WriteLine("Done");
            Console.ReadKey();
        }
    }
}
