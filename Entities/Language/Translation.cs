using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

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

        [ForeignKey("Language")]
        public int LanguageId { get; set; }
        public string LanguageCode { get; set; }
        [JsonIgnore]
        public Language Language { get; set; }

        [Required]
        public bool UpdateRequired { get; set; }
    }
}
