using BusinessPortal.Entities;

namespace BusinessPortal.Services
{
    public interface ITranslateService : IBaseService<Translation>
    {
        IEnumerable<Translation> GetAllLanguageValue(string languageCode);

        Translation GetTranslate(string key, string languageCode);
    }
}
