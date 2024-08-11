using BusinessPortal.Entities;
using BusinessPortal.Services;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DepartmentsController : ControllerBase
    {
        private readonly IDepartmentService _departmentService;

        public DepartmentsController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var departments = _departmentService.GetAll();
            return Ok(departments);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            var department = _departmentService.GetById(id);
            if (department == null) return NotFound();
            return Ok(department);
        }

        [HttpPost]
        public IActionResult Create(Department department)
        {
            _departmentService.Create(department);
            return CreatedAtAction(nameof(GetById), new { id = department.Id }, department);
        }

        [HttpPut("{id}")]
        public IActionResult Update(Guid id, Department department)
        {
            if (id != department.Id) return BadRequest();
            _departmentService.Update(department);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            _departmentService.Delete(id);
            return NoContent();
        }
    }

}
