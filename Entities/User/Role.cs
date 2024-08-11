using System.ComponentModel.DataAnnotations;

namespace BusinessPortal.Entities

{
    public class Role
    {
        [Key]
        public Guid Id { get; set; } // Unique identifier for the role

        [Required]
        [MaxLength(50)]
        public string Name { get; set; } // Role name (e.g., Admin, Manager, Employee)

        [MaxLength(200)]
        public string Description { get; set; } // Description of the role's responsibilities

        public List<User> Users { get; set; } = new List<User>(); // A role can be assigned to multiple users
    }
}
