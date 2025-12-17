using System.Collections.Generic;

namespace day6.Model
{
    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Teacher { get; set; }

        public ICollection<Student> Students { get; set; }
    }
}
