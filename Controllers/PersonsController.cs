using BeforeApp.Data.Services;
using Microsoft.AspNetCore.Mvc;

namespace BeforeApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonsController : ControllerBase
    {
    
        private readonly IPersonService _personService;

        public PersonsController(IPersonService personService)
        {
            _personService = personService;
        }

        [HttpPost("{personType}")]
        public async AddPerson(string personType, PersonModel model)
        {

        }
    }
}
