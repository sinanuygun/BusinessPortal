using BusinessPortal.Entities;
using Microsoft.EntityFrameworkCore;

namespace BusinessPortal.Data.Seed
{
    public static class RoleSeed
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>().HasData(
                new Role
                {
                    Id = Guid.NewGuid(),
                    Name = "Admin",
                    Description = "System administrator with full access"
                },
                new Role
                {
                    Id = Guid.NewGuid(),
                    Name = "Manager",
                    Description = "Manager with access to manage departments and employees"
                },
                new Role
                {
                    Id = Guid.NewGuid(),
                    Name = "Employee",
                    Description = "Regular employee with limited access"
                }
            );
        }
    }
}
