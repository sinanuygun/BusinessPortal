using System.ComponentModel.DataAnnotations;

namespace BusinessPortal.Entities
{
    public class Language
    {
        [Key]
        public int Id { get; set; } // Primary key

        [Required]
        [MaxLength(10)]
        public string Code { get; set; } // Language code (e.g., "en", "tr")

        [Required]
        [MaxLength(50)]
        public string Name { get; set; } // Language name (e.g., "English", "Türkçe")

        public List<Translation> Translations { get; set; } = new List<Translation>(); // Navigation property for translations
    }
}
