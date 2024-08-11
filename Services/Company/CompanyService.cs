using BusinessPortal.Data;
using BusinessPortal.Entities;

namespace BusinessPortal.Services
{
    public class CompanyService : BaseService<Company>, ICompanyService
    {
        public CompanyService(BusinessPortalContext context) : base(context)
        {
        }

    }
}
