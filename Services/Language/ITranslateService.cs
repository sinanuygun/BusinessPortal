using BusinessPortal.Entities;

namespace BusinessPortal.Services
{
    public interface ITranslateService : IBaseService<Translation>
    {
        IEnumerable<Translation> GetAllLanguageValue(string languageCode);

        Task<Translation> GetTranslate(string key, string languageCode);
    }
}
