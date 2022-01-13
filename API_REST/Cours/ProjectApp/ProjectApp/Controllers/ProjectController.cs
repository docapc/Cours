using Microsoft.AspNetCore.Mvc;
using ProjectApp.Dto;
using AutoMapper;
using ProjectApp.Model;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProjectApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private IMapper _mapper;

        private ProjectAPIContext _context;
        public ProjectController(IMapper mapper, ProjectAPIContext context)
        {
            _mapper = mapper;
            _context = context;
        }


        // GET: api/<ProjectController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<ProjectController>/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ProjectDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<ProjectDto> Get(int id)
        {
            if(id == 0)
            {
                return NotFound();
            }

            //var p = new Project()
            //{
            //    Id = id,
            //    Surname = "test",
            //    Description = "desc"
            //};

            var p = _context.Project.Find(id);

            var mapProj = _mapper.Map<ProjectDto>(p);

            return Ok(mapProj);
        }

        [HttpGet("details")]
        public string GetDetails([FromQuery]string name, string prenom)
        {
            return "value";
        }

        // POST api/<ProjectController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ProjectController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        [HttpPut("{id}")]
        public ProjectDto Put(ProjectDto dto)
        {
            var test = dto.Id;
            return dto;
        }

        // DELETE api/<ProjectController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
