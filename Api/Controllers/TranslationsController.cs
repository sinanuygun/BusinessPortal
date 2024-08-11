using BusinessPortal.Entities;
using BusinessPortal.Services;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TranslationsController : ControllerBase
    {
        private readonly ITranslateService _translateService;

        public TranslationsController(ITranslateService translateService)
        {
            _translateService = translateService;
        }

        // Belirli bir dil için tüm çevirileri getir
        [HttpGet("{languageCode}")]
        public IActionResult GetTranslationsByLanguage(string languageCode)
        {
            var translations = _translateService.GetAllLanguageValue(languageCode);
            if (translations == null || !translations.Any())
            {
                return NotFound($"No translations found for language code '{languageCode}'.");
            }
            return Ok(translations);
        }

        // Belirli bir dilde ve anahtara sahip çeviriyi getir
        [HttpGet("{languageCode}/{key}")]
        public async Task<IActionResult> GetTranslation(string key, string languageCode)
        {
            var translation = await _translateService.GetTranslate(key, languageCode);
            if (translation == null)
            {
                return NotFound("Translation failed");
            }
            return Ok(translation);
        }

        // Yeni bir çeviri ekle
        [HttpPost]
        public IActionResult CreateTranslation(Translation translation)
        {
            _translateService.Create(translation);
            return CreatedAtAction(nameof(GetTranslation), new { key = translation.Key, languageCode = translation.LanguageId }, translation);
        }

        // Mevcut bir çeviriyi güncelle
        [HttpPut("{id:int}")]
        public IActionResult UpdateTranslation(int id, Translation translation)
        {
            if (id != translation.Id)
            {
                return BadRequest();
            }
            _translateService.Update(translation);
            return NoContent();
        }

        // Belirli bir çeviriyi sil
        [HttpDelete("{id:Guid}")]
        public IActionResult DeleteTranslation(Guid id)
        {
            var existingTranslation = _translateService.GetById(id);
            if (existingTranslation == null)
            {
                return NotFound();
            }
            _translateService.Delete(id);
            return NoContent();
        }
    }



}
