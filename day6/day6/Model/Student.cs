using System.ComponentModel.DataAnnotations;

namespace day6.Models
{
    public class Student
    {
        public int Id { get; set; }

        [Required, MaxLength(50)]
        public string Name { get; set; }

        [Range(1, 100)]
        public int Age { get; set; }

        [Required]
        public DateTime DOB { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }

        [Required, MaxLength(15)]
        public string Phone { get; set; }

        [Required]
        public string Password { get; set; }

        public int CourseId { get; set; }
        public Course Course { get; set; }
    }
}
