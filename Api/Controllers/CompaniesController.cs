using BusinessPortal.Entities;
using BusinessPortal.Services;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CompaniesController : ControllerBase
    {
        private readonly ICompanyService _companyService;

        public CompaniesController(ICompanyService companyService)
        {
            _companyService = companyService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var companies = _companyService.GetAll();
            return Ok(companies);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            var company = _companyService.GetById(id);
            if (company == null) return NotFound();
            return Ok(company);
        }

        [HttpPost]
        public IActionResult Create(Company company)
        {
            _companyService.Create(company);
            return CreatedAtAction(nameof(GetById), new { id = company.Id }, company);
        }

        [HttpPut("{id}")]
        public IActionResult Update(Guid id, Company company)
        {
            if (id != company.Id) return BadRequest();
            _companyService.Update(company);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            _companyService.Delete(id);
            return NoContent();
        }
    }

}
