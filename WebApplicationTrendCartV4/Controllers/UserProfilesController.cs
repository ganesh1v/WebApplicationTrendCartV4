using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplicationTrendCartV4.Models;
using WebApplicationTrendCartV4.Repository;

namespace WebApplicationTrendCartV4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserProfilesController : ControllerBase
    {
        private readonly IRepo<UserProfile> _repo;

        public UserProfilesController(IRepo<UserProfile> repo)
        {
            _repo = repo;
        }
        // GET: api/<CustomersController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserProfile>>> Get()
        {
            return Ok(await _repo.GetAll());
        }

        // GET api/<CustomersController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserProfile>> Get(int id)
        {
            var userprofile = await _repo.GetById(id);
            if (userprofile == null)
            {
                return NotFound();
            }
            return Ok(userprofile);
        }

        // POST api/<CustomersController>
        [HttpPost]
        public async Task<ActionResult<UserProfile>> Post([FromBody] UserProfile userprofile)
        {
            await _repo.Add(userprofile);
            return CreatedAtAction(nameof(Get), new { id = userprofile.ProfileId }, userprofile);
        }

        // PUT api/<CustomersController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<UserProfile>> Put(int id, [FromBody] UserProfile userprofile)
        {
            if (id != userprofile.ProfileId)
            {
                return BadRequest();
            }
            await _repo.Update(userprofile);
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
