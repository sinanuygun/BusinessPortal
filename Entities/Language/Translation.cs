using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessPortal.Entities
{
    public class Translation
    {
        [Key]
        public int Id { get; set; } // Primary key

        [Required]
        [MaxLength(100)]
        public string Key { get; set; } // Translation key (e.g., "WelcomeMessage")

        [Required]
        [MaxLength(500)]
        public string Value { get; set; } // Translation value (e.g., "Hoşgeldiniz")

        [Required]
        public int LanguageId { get; set; } // Foreign key to Language

        [ForeignKey("LanguageId")]
        public Language Language { get; set; } // Navigation property to Language
    }
}
