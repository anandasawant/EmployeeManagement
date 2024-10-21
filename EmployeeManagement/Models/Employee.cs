namespace EmployeeManagement.Models
{
    public class Employee
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string EmailId { get; set; }

        public int Salery { get; set; }

        public string Position { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string? ImagePath { get; set; }

        public int DepartmentId { get; set; }

        public Department? department { get; set; }
    }
}
