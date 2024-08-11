using System.ComponentModel.DataAnnotations;

namespace BusinessPortal.Entities
{

    public class Company
    {
        [Key]
        public Guid Id { get; set; } // Unique identifier for the company

        [Required]
        [MaxLength(100)]
        public string Name { get; set; } // Company name

        [MaxLength(200)]
        public string Address { get; set; } // Company address

        [MaxLength(15)]
        public string Phone { get; set; } // Company contact phone number

        public DateTime CreatedAt { get; set; } // Date when the company was added to the system

        public List<Department> Departments { get; set; } = new List<Department>(); // A company can have multiple departments
        public List<User> Users { get; set; } = new List<User>(); // A company can have multiple users
    }
}
