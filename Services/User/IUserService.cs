using BusinessPortal.Entities;

namespace BusinessPortal.Services
{
    public interface IUserService : IBaseService<User>
    {
        void Create(User user, string password);
    }
}
