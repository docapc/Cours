using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DemoTests.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DemoController : ControllerBase
    {
        private readonly DemoDbContext _context;

        public DemoController(DemoDbContext context)
        {
            _context = context;
        }

        // GET: api/<DemoController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _context.Set<DemoEntity>().ToListAsync(); 
            return Ok(result);
        }

        // GET api/<DemoController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _context.Set<DemoEntity>().FindAsync(id);
            return Ok(result);
        }

        // POST api/<DemoController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] string value)
        {
            var demo = new DemoEntity() {Content = value}; 
            await _context.Set<DemoEntity>().AddAsync(demo);
            await _context.SaveChangesAsync(); 
            return CreatedAtAction(nameof(Get),demo);
        }

        // PUT api/<DemoController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] string value)
        {
            var demo = new DemoEntity() { Id= id,Content = value };
            _context.Set<DemoEntity>().Update(demo);
            await _context.SaveChangesAsync();
            return Ok();
        }

        // DELETE api/<DemoController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var demo = new DemoEntity() { Id = id };
            _context.Set<DemoEntity>().Remove(demo);
            await _context.SaveChangesAsync();
            return Ok(); 
        }
    }
}
