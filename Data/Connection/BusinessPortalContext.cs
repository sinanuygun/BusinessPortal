using BusinessPortal.Data.Seed;
using BusinessPortal.Entities;
using Microsoft.EntityFrameworkCore;

namespace BusinessPortal.Data
{
    public class BusinessPortalContext : DbContext
    {
        public BusinessPortalContext(DbContextOptions<BusinessPortalContext> options)
                    : base(options)
        {
        }
        #region Users
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        #endregion
        #region Company
        public DbSet<Company> Companies { get; set; }
        public DbSet<Department> Departments { get; set; }
        #endregion
        #region Language
        public DbSet<Language> Languages { get; set; }
        public DbSet<Translation> Translations { get; set; }
        #endregion
        #region Log
        public DbSet<Log> Logs { get; set; }
        #endregion
        #region Workflow
        public DbSet<WorkflowTemplate> WorkflowTemplates { get; set; }
        public DbSet<WorkflowStep> WorkflowSteps { get; set; }
        public DbSet<WorkflowInstance> WorkflowInstances { get; set; }
        public DbSet<WorkflowStepInstance> WorkflowStepInstances { get; set; }
        #endregion
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // User -> Company ilişkisinin geri eklenmesi
            modelBuilder.Entity<User>()
                .HasOne(u => u.Company)
                .WithMany(c => c.Users)
                .HasForeignKey(u => u.CompanyId)
                .OnDelete(DeleteBehavior.Restrict)
                    .IsRequired(); 


            // User -> Department ilişkisinin geri eklenmesi
            modelBuilder.Entity<User>()
                .HasOne(u => u.Department)
                .WithMany(d => d.Users)
                .HasForeignKey(u => u.DepartmentId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired(); 

            // User -> Role ilişkisinin geri eklenmesi
            modelBuilder.Entity<User>()
                .HasOne(u => u.Role)
                .WithMany(r => r.Users)
                .HasForeignKey(u => u.RoleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .IsRequired(); 

            // User -> Language ilişkisinin geri eklenmesi
            modelBuilder.Entity<User>()
                .HasOne(u => u.Language)
                .WithMany()
                .HasForeignKey(u => u.LanguageId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .IsRequired(); 

            // Log tablosundaki LogLevel sütununun string olarak saklanması
            modelBuilder.Entity<Log>()
                .Property(l => l.LogLevel)
                .HasConversion<string>();

            // WorkflowInstance tablosundaki Status sütununun string olarak saklanması
            modelBuilder.Entity<WorkflowInstance>()
                .Property(wi => wi.Status)
                .HasConversion<string>();

            // Varsayılan rollerin tohumlanması
            RoleSeed.Seed(modelBuilder);

            // Varsayılan dillerin tohumlanması
            LanguageSeed.Seed(modelBuilder);

        }
    }
}
