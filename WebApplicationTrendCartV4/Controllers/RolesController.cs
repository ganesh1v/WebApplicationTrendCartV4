using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplicationTrendCartV4.Models;
using WebApplicationTrendCartV4.Repository;

namespace WebApplicationTrendCartV4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        private readonly IRepo<Role> _repo;

        public RolesController(IRepo<Role> repo)
        {
            _repo = repo;
        }
        // GET: api/<CustomersController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Role>>> Get()
        {

            return Ok(await _repo.GetAll());
        }

        // GET api/<CustomersController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Role>> Get(int id)
        {
            var role = await _repo.GetById(id);
            if (role == null)
            {
                return NotFound();
            }
            return Ok(role);
        }

        // POST api/<CustomersController>
        [HttpPost]
        public async Task<ActionResult<Role>> Post([FromBody] Role role)
        {
            await _repo.Add(role);
            return CreatedAtAction(nameof(Get), new { id = role.RoleId }, role);
        }

        // PUT api/<CustomersController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<Role>> Put(int id, [FromBody] Role role)
        {
            if (id != role.RoleId)
            {
                return BadRequest();
            }
            await _repo.Update(role);
            return NoContent();
        }

        // DELETE api/<CustomersController>/5
        [HttpDelete("{id}")]

        public async Task<ActionResult> Delete(int id)
        {
            await _repo.DeleteById(id);
            return NoContent();
        }
    }
}
