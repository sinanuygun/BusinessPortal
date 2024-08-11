using BusinessPortal.Data;
using BusinessPortal.Entities;

namespace BusinessPortal.Services
{
    public class RoleService : BaseService<Role>, IRoleService
    {
        public RoleService(BusinessPortalContext context) : base(context)
        {
        }

    }
}
