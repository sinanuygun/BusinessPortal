using BusinessPortal.Data;
using BusinessPortal.Entities;

namespace BusinessPortal.Services
{
    public class TranslateService : BaseService<Translation>, ITranslateService
    {
        private new readonly BusinessPortalContext _context;
        private const string DefaultLanguageCode = "tr";

        public TranslateService(BusinessPortalContext context) : base(context)
        {
            _context = context;
        }

        public Translation GetTranslate(string key, string languageCode)
        {
            var translation = GetTranslationByKeyAndLanguageCode(key, languageCode);
            if (translation != null)
            {
                return translation;
            }

            var defaultTranslation = GetTranslationByKeyAndLanguageCode(key, DefaultLanguageCode);
            if (defaultTranslation != null)
            {
                SaveTranslation(key, defaultTranslation.Value, languageCode);
                return new Translation { Key = key, Value = defaultTranslation.Value, LanguageId = GetLanguageIdByCode(languageCode).Value };
            }

            var onlineTranslation = GetOnlineTranslation(key, languageCode);
            SaveTranslation(key, onlineTranslation, languageCode);
            return new Translation { Key = key, Value = onlineTranslation, LanguageId = GetLanguageIdByCode(languageCode).Value };
        }

        public IEnumerable<Translation> GetAllLanguageValue(string languageCode)
        {
            var language = _context.Languages.FirstOrDefault(l => l.Code == languageCode);
            if (language == null) return new List<Translation>();

            return _dbSet.Where(t => t.LanguageId == language.Id).ToList();
        }

        private Translation GetTranslationByKeyAndLanguageCode(string key, string languageCode)
        {
            var language = _context.Languages.FirstOrDefault(l => l.Code == languageCode);
            if (language == null) return null;

            return _dbSet.FirstOrDefault(t => t.Key == key && t.LanguageId == language.Id);
        }

        private string GetOnlineTranslation(string key, string languageCode)
        {
            return $"[Online Translation for '{key}' in '{languageCode}']";
        }

        private void SaveTranslation(string key, string value, string languageCode)
        {
            var languageId = GetLanguageIdByCode(languageCode);
            if (languageId != null)
            {
                var translation = new Translation
                {
                    Key = key,
                    Value = value,
                    LanguageId = languageId.Value
                };
                _context.Translations.Add(translation);
                _context.SaveChanges();
            }
        }

        private int? GetLanguageIdByCode(string languageCode)
        {
            var language = _context.Languages.FirstOrDefault(l => l.Code == languageCode);
            return language?.Id;
        }
    }
}
