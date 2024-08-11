using BusinessPortal.Entities;

namespace BusinessPortal.Services
{
    public interface IAuthService
    {
        User Authenticate(string email, string password);
        string GenerateJwtToken(User user);
    }
}
