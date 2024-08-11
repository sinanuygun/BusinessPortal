using BusinessPortal.Data;
using BusinessPortal.Entities;
using System.Text;

namespace BusinessPortal.Services
{
    public class UserService : BaseService<User>, IUserService
    {
        private new readonly BusinessPortalContext _context;

        public UserService(BusinessPortalContext context) : base(context)
        {
            _context = context;
        }

        public void Create(User user, string password)
        {
            user.PasswordHash = HashPassword(password);
            base.Create(user);
        }

        private string HashPassword(string password)
        {
            // Burada hashleme işlemi yapılmalı. Örnek olarak SHA256 kullanılıyor.
            using (var sha256 = System.Security.Cryptography.SHA256.Create())
            {
                var bytes = Encoding.UTF8.GetBytes(password);
                var hash = sha256.ComputeHash(bytes);
                return Convert.ToBase64String(hash);
            }
        }
    }
}
