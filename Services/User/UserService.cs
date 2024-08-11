using BusinessPortal.Data;
using BusinessPortal.Entities;

namespace BusinessPortal.Services
{
    public class UserService : BaseService<User>, IUserService
    {
        public UserService(BusinessPortalContext context) : base(context)
        {
        }

    }
}
