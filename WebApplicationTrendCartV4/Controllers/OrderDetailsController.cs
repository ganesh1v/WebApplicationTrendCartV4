using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplicationTrendCartV4.Models;
using WebApplicationTrendCartV4.Repository;

namespace WebApplicationTrendCartV4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderDetailsController : ControllerBase
    {
        private readonly IRepo<OrderDetail> _repo;

        public OrderDetailsController(IRepo<OrderDetail> repo)
        {
            _repo = repo;
        }
        // GET: api/<CustomersController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderDetail>>> Get()
        {
            return Ok(await _repo.GetAll());
        }

        // GET api/<CustomersController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OrderDetail>> Get(int id)
        {
            var orderdetail = await _repo.GetById(id);
            if (orderdetail == null)
            {
                return NotFound();
            }
            return Ok(orderdetail);
        }

        // POST api/<CustomersController>
        [HttpPost]
        public async Task<ActionResult<OrderDetail>> Post([FromBody] OrderDetail orderdetail)
        {
            await _repo.Add(orderdetail);
            return CreatedAtAction(nameof(Get), new { id = orderdetail.OrderDetailId }, orderdetail);
        }

        // PUT api/<CustomersController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<OrderDetail>> Put(int id, [FromBody] OrderDetail orderdetail)
        {
            if (id != orderdetail.OrderDetailId)

            {
                return BadRequest();
            }
            await _repo.Update(orderdetail);
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
