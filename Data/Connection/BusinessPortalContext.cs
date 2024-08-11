using BusinessPortal.Data.Seed;
using BusinessPortal.Entities;
using Microsoft.EntityFrameworkCore;

namespace BusinessPortal.Data
{
    public class BusinessPortalContext : DbContext
    {
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
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>()
                .HasOne(u => u.Company)
                .WithMany(c => c.Users)
                .HasForeignKey(u => u.CompanyId);

            modelBuilder.Entity<User>()
                .HasOne(u => u.Department)
                .WithMany(d => d.Users)
                .HasForeignKey(u => u.DepartmentId);

            modelBuilder.Entity<User>()
                .HasOne(u => u.Role)
                .WithMany(r => r.Users)
                .HasForeignKey(u => u.RoleId);

            modelBuilder.Entity<Log>()
                .Property(l => l.LogLevel)
                .HasConversion<string>();

            modelBuilder.Entity<WorkflowInstance>()
                .Property(wi => wi.Status)
                .HasConversion<string>();

            RoleSeed.Seed(modelBuilder);
            LanguageSeed.Seed(modelBuilder);
        }
    }
}
