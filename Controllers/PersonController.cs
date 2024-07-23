using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PhoneBookTestApp.Models;
using PhoneBookTestApp.Services.PersonService;

namespace PhoneBookTestApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IPersonService _personService;
        public PersonController(IPersonService personService)
        {
            _personService = personService;
        }
        [HttpGet] 
        public async Task<ActionResult<List<Person>>> GetAllPerson()
        {

            return await _personService.GetAllPerson();    
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<List<Person>>> findPerson(int id)
        {
            var result = await _personService.findPerson(id);
            if (result == null)
                return NotFound("Person not found");
            return Ok(result);
        }

        [HttpPost("{id}")]
        public async Task<ActionResult<List<Person>>> AddPerson(Person person)
        {
            var result = await _personService.AddPerson(person);
            return Ok(result);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<List<Person>>> UpdatePerson(int id, Person requestPerson)
        {
            var result = await _personService.UpdatePerson(id, requestPerson);
            if (result is null)
                return NotFound("Person not found in PhoneBook");
            return Ok(result);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Person>>> DeletePerson(int id)
        {
            var result= await _personService.DeletePerson(id);
            if (result is null)
                return NotFound("Person not found in PhoneBook");
            return Ok(result);
        }
    }
}
