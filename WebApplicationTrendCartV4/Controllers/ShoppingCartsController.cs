using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplicationTrendCartV4.Models;
using WebApplicationTrendCartV4.Repository;

namespace WebApplicationTrendCartV4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShoppingCartsController : ControllerBase
    {
        private readonly IRepo<ShoppingCart> _repo;

        public ShoppingCartsController(IRepo<ShoppingCart> repo)

        {
            _repo = repo;
        }
        // GET: api/<CustomersController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ShoppingCart>>> Get()
        {
            return Ok(await _repo.GetAll());
        }

        // GET api/<CustomersController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ShoppingCart>> Get(int id)
        {
            var shopping = await _repo.GetById(id);
            if (shopping == null)
            {
                return NotFound();
            }
            return Ok(shopping);
        }

        // POST api/<CustomersController>
        [HttpPost]
        public async Task<ActionResult<ShoppingCart>> Post([FromBody] ShoppingCart shopping)
        {
            await _repo.Add(shopping);
            return CreatedAtAction(nameof(Get), new { id = shopping.CartId }, shopping);
        }

        // PUT api/<CustomersController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<ShoppingCart>> Put(int id, [FromBody] ShoppingCart shopping)
        {
            if (id != shopping.CartId)
            {
                return BadRequest();

            }
            await _repo.Update(shopping);
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
