using Microsoft.AspNetCore.Mvc;
using Persons.Core.DTOs.Registration;
using Persons.Service;

namespace WebShopApi.Controllers
{
    [ApiController]
    [Route("api/people")]
    public class PersonController : ControllerBase
    {
        private readonly IPersonService _personService;

        public PersonController(IPersonService personService)
        {
            _personService = personService;
        }
        [HttpPost("registration")]
        public async Task<IActionResult> Registration([FromBody] RegistrationDTO registrationDTO)
        {
            return Ok(await _personService.RegisterPerson(registrationDTO));
        }
    }
}
