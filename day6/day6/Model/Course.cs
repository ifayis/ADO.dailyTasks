using day6.Models;

namespace day6.Models
{
    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Teacher { get; set; }

        public ICollection<Student> Students { get; set; }
    }
}
