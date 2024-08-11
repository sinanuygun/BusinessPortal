using BusinessPortal.Data;
using BusinessPortal.Entities;

namespace BusinessPortal.Services
{
    public class DepartmentService : BaseService<Department>, IDepartmentService
    {
        public DepartmentService(BusinessPortalContext context) : base(context)
        {
        }

    }
}
