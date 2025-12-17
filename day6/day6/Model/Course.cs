using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace day6.Model
{
    internal class Course
    {
        public class course
        {
            public int id { get; set; }
            public string name { get; set; }
            public string teacher { get; set; }

            public ICollection<Student> student { get; set; }
        }
    }
}
