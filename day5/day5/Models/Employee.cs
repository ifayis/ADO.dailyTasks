namespace day5.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Salary { get; set; }

        public int DepartmentId { get; set; }

        // Lazy loading
        public virtual Department Department { get; set; }
    }
}
