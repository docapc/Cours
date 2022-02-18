using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DemoController : ControllerBase
    {
        private readonly IDemoRepository _repository;
        public DemoController(IDemoRepository repository)
        {
            _repository = repository;
        }
        // GET: DemoController
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var result = await _repository.GetAll();
            return Ok(result);
        }

        // GET: DemoController/Details/5
        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id)
        {
            var result = await _repository.GetById(id);
            return Ok(result);
        }

        // POST: DemoController/Create
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] string value)
        {

            var demo = new DemoEntity() { Content = value };
            await _repository.Add(demo);
            return CreatedAtAction(nameof(Get), demo);
        }

        // GET: DemoController/Edit/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] string value)
        {
            var demo = new DemoEntity() { Id = id,  Content = value };
            await _repository.Update(demo);
            return Ok(demo);
        }

        // GET: DemoController/Delete/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            //var demo = new DemoEntity() {Id = id};
            await _repository.Delete(id);
            return Ok();
        }

    }
}
