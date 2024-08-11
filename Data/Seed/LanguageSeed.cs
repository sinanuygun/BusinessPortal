using BusinessPortal.Entities;
using Microsoft.EntityFrameworkCore;

namespace BusinessPortal.Data.Seed
{
    public static class LanguageSeed
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Language>().HasData(
                           new Language { Id = 1, Code = "tr", Name = "Türkçe" },
                           new Language { Id = 2, Code = "en", Name = "English" },
                           new Language { Id = 3, Code = "de", Name = "Deutsch" },
                           new Language { Id = 4, Code = "fr", Name = "Français" },
                           new Language { Id = 5, Code = "es", Name = "Español" }
                       );
        }
    }
}
