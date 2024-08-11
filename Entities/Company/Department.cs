using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessPortal.Entities

{
    public class Department
    {
        [Key]
        public Guid Id { get; set; } // Unique identifier for the department

        [Required]
        [MaxLength(100)]
        public string Name { get; set; } // Department name

        [ForeignKey("Company")]
        public Guid CompanyId { get; set; } // Foreign key to the Company
        public Company Company { get; set; } // Navigation property to the Company

        public List<User> Users { get; set; } = new List<User>(); // A department can have multiple users
    }
}
