using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessPortal.Entities
{
    public class User
    {
        [Key]
        public Guid Id { get; set; } // Unique identifier for the user

        [Required]
        [MaxLength(50)]
        public string Username { get; set; } // Username for login

        [Required]
        [EmailAddress]
        [MaxLength(100)]
        public string Email { get; set; } // User's email address

        [Required]
        [MaxLength(256)]
        public string PasswordHash { get; set; } // Hashed password for security

        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; } // User's first name

        [Required]
        [MaxLength(50)]
        public string LastName { get; set; } // User's last name

        public DateTime CreatedAt { get; set; } // Account creation date
        public DateTime? LastLoginAt { get; set; } // Last login date, nullable in case user hasn't logged in yet
        public bool IsActive { get; set; } // Flag to indicate if the account is active

        [ForeignKey("Company")]
        public Guid CompanyId { get; set; } // Foreign key to Company
        public Company Company { get; set; } // Navigation property to Company

        [ForeignKey("Department")]
        public Guid DepartmentId { get; set; } // Foreign key to Department
        public Department Department { get; set; } // Navigation property to Department

        [ForeignKey("Role")]
        public Guid RoleId { get; set; } // Foreign key to Role
        public Role Role { get; set; } // Navigation property to Role

        [ForeignKey("Language")]
        public int LanguageId { get; set; } // Foreign key to Language
        public Language Language { get; set; } // Navigation property to Language
    }
}


