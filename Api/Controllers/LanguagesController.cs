using BusinessPortal.Entities;
using BusinessPortal.Services;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LanguagesController : ControllerBase
    {
        private readonly ILanguageService _languageService;

        public LanguagesController(ILanguageService languageService)
        {
            _languageService = languageService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var languages = _languageService.GetAll();
            return Ok(languages);
        }

        [HttpGet("{id:Guid}")]
        public IActionResult GetById(Guid id)
        {
            var language = _languageService.GetById(id);
            if (language == null) return NotFound();
            return Ok(language);
        }

        [HttpPost]
        public IActionResult Create(Language language)
        {
            _languageService.Create(language);
            return CreatedAtAction(nameof(GetById), new { id = language.Id }, language);
        }

        [HttpPut("{id:int}")]
        public IActionResult Update(int id, Language language)
        {
            if (id != language.Id) return BadRequest();
            _languageService.Update(language);
            return NoContent();
        }

        [HttpDelete("{id:Guid}")]
        public IActionResult Delete(Guid id)
        {
            _languageService.Delete(id);
            return NoContent();
        }
    }



}
