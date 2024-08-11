using BusinessPortal.Data;
using BusinessPortal.Entities;
using Services.Language;

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

        public async Task<Translation> GetTranslate(string key, string languageCode)
        {
            var LanguageControl = _context.Languages.Where(x => x.Code == languageCode).FirstOrDefault();
            if (LanguageControl == null)
            {
                return null;
            }

            var translation = GetTranslationByKeyAndLanguageCode(key, languageCode);
            if (translation != null)
            {
                return translation;
            }
            else
            {
                var defaultLanguageControl = GetTranslationByKeyAndLanguageCode(key, DefaultLanguageCode);
                if (defaultLanguageControl == null)
                {
                    SaveTranslation(key, key, DefaultLanguageCode, false);
                }


                bool updateRequired = true;
                if (languageCode!=DefaultLanguageCode)
                {
                    var onlineTranslation = await GetOnlineTranslation(key, languageCode);
                    SaveTranslation(key, onlineTranslation, languageCode, true);
                    key=onlineTranslation;
                }

                return new Translation { Key = key, Value = key, LanguageId = GetLanguageIdByCode(languageCode).Value, LanguageCode=languageCode, UpdateRequired=updateRequired };
            }


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

        private async Task<string> GetOnlineTranslation(string key, string languageCode)
        {
            if (DefaultLanguageCode!=languageCode)
            {
                var translatorService = new BingTranslatorService();
                key = await translatorService.TranslateText(key, DefaultLanguageCode, languageCode);
            }

            return key;
        }

        private void SaveTranslation(string key, string value, string languageCode, bool updateRequired)
        {
            var languageId = GetLanguageIdByCode(languageCode);
            if (languageId != null)
            {
                var translation = new Translation
                {
                    Key = key,
                    Value = value,
                    LanguageId = languageId.Value,
                    LanguageCode = languageCode,
                    UpdateRequired = updateRequired
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
