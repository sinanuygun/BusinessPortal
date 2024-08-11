using BusinessPortal.Entities;
using BusinessPortal.Services;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RolesController : ControllerBase
    {
        private readonly IRoleService _roleService;

        public RolesController(IRoleService roleService)
        {
            _roleService = roleService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var roles = _roleService.GetAll();
            return Ok(roles);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            var role = _roleService.GetById(id);
            if (role == null) return NotFound();
            return Ok(role);
        }

        [HttpPost]
        public IActionResult Create(Role role)
        {
            _roleService.Create(role);
            return CreatedAtAction(nameof(GetById), new { id = role.Id }, role);
        }

        [HttpPut("{id}")]
        public IActionResult Update(Guid id, Role role)
        {
            if (id != role.Id) return BadRequest();
            _roleService.Update(role);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            _roleService.Delete(id);
            return NoContent();
        }
    }

}
