using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Services;
using System.Net;

namespace AngApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly PersonService _globalService;

        public PersonController(PersonService globalService)
        {
            _globalService = globalService;
        }
        [HttpGet]
        public IActionResult GetAllPersons()
        {
            try
            {
                var Persons = _globalService.getAllPersons();
                return Ok(Persons);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
        [HttpGet("{Id}")]
        public IActionResult GetPersonById(int id)
        {
            var Persons = _globalService.getPersonById(id);
            if (Persons == null)
            {
                return NotFound();
            }
            return Ok(Persons);
        }
        [HttpPost]
        public async Task<IActionResult> CreatePerson(Person person)
        {
            try
            {
                var result = _globalService.addPerson(person);
                return Ok(result);
            }
            catch (Exception ex)
            {
                // Handle the exception and return an error response
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePerson(int id, Person person)
        {
            if (id != person.Id)
            {
                return BadRequest();
            }
            var res = _globalService.updatePerson(person);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePerson(int id)
        {
            if (id != null)
            {
                return NotFound();
            }
            _globalService.removePerson(id);
            return NoContent();
        }
    }
}
