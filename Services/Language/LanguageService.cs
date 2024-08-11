using BusinessPortal.Data;
using BusinessPortal.Entities;

namespace BusinessPortal.Services
{
    public class LanguageService : BaseService<Language>, ILanguageService
    {
        public LanguageService(BusinessPortalContext context) : base(context)
        {
        }

    }
}
