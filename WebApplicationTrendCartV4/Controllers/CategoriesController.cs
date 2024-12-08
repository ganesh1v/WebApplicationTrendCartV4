using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplicationTrendCartV4.Models;
using WebApplicationTrendCartV4.Repository;

namespace WebApplicationTrendCartV4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly IRepo<Category> _repo;

        public CategoriesController(IRepo<Category> repo)
        {
            _repo = repo;
        }
        // GET: api/<CustomersController>
        [HttpGet]

        public async Task<ActionResult<IEnumerable<Category>>> Get()
        {
            return Ok(await _repo.GetAll());
        }

        // GET api/<CustomersController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Category>> Get(int id)
        {
            var cat = await _repo.GetById(id);
            if (cat == null)
            {
                return NotFound();
            }
            return Ok(cat);
        }

        // POST api/<CustomersController>
        [HttpPost]
        public async Task<ActionResult<Category>> Post([FromBody] Category cat)
        {
            await _repo.Add(cat);
            return CreatedAtAction(nameof(Get), new { id = cat.CategoryId }, cat);
        }

        // PUT api/<CustomersController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<Category>> Put(int id, [FromBody] Category cat)
        {
            if (id != cat.CategoryId)
            {
                return BadRequest();
            }
            await _repo.Update(cat);
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
