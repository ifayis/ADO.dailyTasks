namespace day5.Models
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }

        // Lazy loading
        public virtual ICollection<Employee> Employees { get; set; }
    }
}
