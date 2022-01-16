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

        private ProjectContext _context;
        public ProjectController(IMapper mapper, ProjectContext context)
        {
            _mapper = mapper;
            _context = context;
        }


        // GET: api/<ProjectController>
        [HttpGet]
        public IEnumerable<Project> Get()
        {
            var allProjects = _mapper.Map<IEnumerable<Project>>(_context.Project.ToList());
            return allProjects;
        }

        // GET api/<ProjectController>/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ProjectDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<ProjectDto> Get(int id)
        {
            var p = _context.Project.Find(id);
            if (p == null)
            {
                return NotFound();
            }
            var mapProj = _mapper.Map<ProjectDto>(p);

            return Ok(mapProj);
        }

        [HttpGet("details")]
        public IEnumerable<ProjectDto> GetDetails([FromQuery]string name)
        {
            var projects = _context.Project.Select(p => p.Name == name).ToList();

            var dto = _mapper.Map<IEnumerable<ProjectDto>>(projects);

            return dto;
        }

        // POST api/<ProjectController>
        [HttpPost]
        public void Post([FromBody] ProjectDto dto)
        {
            var entity = _mapper.Map<Project>(dto);
            _context.Project.Add(entity);
            _context.SaveChanges();
        }

        // PUT api/<ProjectController>/5
        [HttpPut("{id}")]
        public ProjectDto Put(ProjectDto dto)
        {
            var entity = _mapper.Map<Project>(dto);
            var addEntity = _context.Project.Update(entity);
            _context.SaveChanges();
            return _mapper.Map<ProjectDto>(addEntity);
        }

        // DELETE api/<ProjectController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var entity = _context.Project.First(p => p.Id == id);
            _context.Project.Remove(entity);
            _context.SaveChanges();
        }
    }
}
