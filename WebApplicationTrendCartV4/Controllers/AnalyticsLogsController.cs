using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplicationTrendCartV4.Models;
using WebApplicationTrendCartV4.Repository;

namespace WebApplicationTrendCartV4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnalyticsLogsController : ControllerBase
    {
        private readonly IRepo<AnalyticsLog> _repo;

        public AnalyticsLogsController(IRepo<AnalyticsLog> repo)
        {
            _repo = repo;
        }
        // GET: api/<CustomersController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AnalyticsLog>>> Get()
        {
            return Ok(await _repo.GetAll());
        }

        // GET api/<CustomersController>/5
        [HttpGet("{id}")]

        public async Task<ActionResult<AnalyticsLog>> Get(int id)
        {
            var analytics = await _repo.GetById(id);
            if (analytics == null)
            {
                return NotFound();
            }
            return Ok(analytics);
        }

        // POST api/<CustomersController>
        [HttpPost]
        public async Task<ActionResult<AnalyticsLog>> Post([FromBody] AnalyticsLog analytics)
        {
            await _repo.Add(analytics);
            return CreatedAtAction(nameof(Get), new { id = analytics.LogId }, analytics);
        }

        // PUT api/<CustomersController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<AnalyticsLog>> Put(int id, [FromBody] AnalyticsLog analytics)
        {
            if (id != analytics.LogId)
            {
                return BadRequest();
            }
            await _repo.Update(analytics);
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
