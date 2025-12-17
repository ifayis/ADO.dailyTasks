using day6.Data;
using day6.Models;
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
                // CREATE (INSERT)
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

                // READ ALL
                Console.WriteLine("\nAll Students:");
                var students = context.Students.ToList();

                foreach (var s in students)
                {
                    Console.WriteLine($"{s.Id} - {s.Name} - {s.Age}");
                }

                // READ BY ID
                var singleStudent = context.Students
                                           .FirstOrDefault(s => s.Id == student.Id);

                if (singleStudent != null)
                {
                    Console.WriteLine($"\nFetched Student: {singleStudent.Name}");
                }

                // UPDATE
                if (singleStudent != null)
                {
                    singleStudent.Age = 23;
                    context.SaveChanges();
                    Console.WriteLine("Student updated");
                }

                // FILTER
                Console.WriteLine("\nFiltered Students (Age > 21):");
                var filtered = context.Students
                                      .Where(s => s.Age > 21)
                                      .ToList();

                foreach (var s in filtered)
                {
                    Console.WriteLine(s.Name);
                }

                // DELETE
                if (singleStudent != null)
                {
                    context.Students.Remove(singleStudent);
                    context.SaveChanges();
                    Console.WriteLine("Student deleted");
                }
            }

            Console.WriteLine("\nDone. Press any key to exit...");
            Console.ReadKey();
        }
    }
}
