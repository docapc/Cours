using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectWebApi.Dtos;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProjectWebApi.Controllers
{
    [Route("api/[controller]")] // Le api/ est une convention qu'il faut respecter
    [ApiController]
    public class ProjectController : ControllerBase
    {
        IMapper _mapper; // le mapper en question
        //var _mappedProject = _mapper.Map<Project>(ProjectDto); pour mapper un ProjectDto en Project
        DbContext _context;

        public ProjectController(IMapper mapper, DbContext context) // ici injection du mapper et du context
        {
            _mapper = mapper;
            _context = context;
            _context.Database.EnsureCreated();
        }

        // GET: api/<ProjectController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<ProjectController>/5
        [HttpGet("{id}")] // ce qu'il y a {ressource} est le nom de la ressource à la fin du endpoint
        public int Get(int id)
        {
            return 42;
        }

        // si {X} : X est différent de my_number il faudra lui fournir un nom pour la ressource lors de la requête
        [HttpGet("truc/{my_number}")] // si l'on ne donne pas un name/ on ne peut pas différencier les deux Get
        public float Get(float my_number)
        {
            return 42 * my_number;
        }

        // La convention est de nommer details
        [HttpGet("details")]
        public double Get(double my_number) // le nom donné à la variable ici ser affiché dans la requête /detail?ma_variable=valeur_passée
        {
            return 42 * my_number;
        }

        [HttpGet("test/{id}")]
        public ProjectDto Get(int id, string name) // on peut aussi passer un dto en paramètre directement
        {
            return new ProjectDto()
            {
                Id = id,
                Name = name,
                Description = "test description"
            };
        }

        // La méthode POST est utilisée pour envoyer une entité vers la ressource indiquée.Cela entraîne généralement un changement d'état ou des effets de bord sur le serveur.
        // POST api/<ProjectController>
        [HttpPost]
        public void Post([FromBody] string value) 
        {
            // FromBody Si les infos sont dans le body, elles ne seront pas dans l'url (http.../api/project?id=1 par exemple)
        }

        // La méthode PUT remplace toutes les représentations actuelles de la ressource visée par le contenu de la requête.
        // PUT api/<ProjectController>/5
        [HttpPut("{id}")] 
        public void Put(int id, [FromBody] string value)
        {
        }

        [HttpPut("detail")]
        public ProjectDto Put(ProjectDto projectDto) // a préférer au fromBody ProjectObject quand on veux passer un objet spécifique.
        {
            var test = projectDto.Id; // ne sert strictement à rien ici, juste pour avoir un corps d'exemple
            return projectDto;
        }

        // DELETE api/<ProjectController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
