using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace day6.Model
{
    internal class Student
    {
        public class student
        {
            public int id { get; set; }
            public String name { get; set; }
            public int age { get; set; }
            public DateOnly DOB { get; set; }
            public String email { get; set; }

            public String phone { get; set; }
            public String password { get; set; }
            public int courseid { get; set; }


            public Course course { get; set; }
        }
    }
}
