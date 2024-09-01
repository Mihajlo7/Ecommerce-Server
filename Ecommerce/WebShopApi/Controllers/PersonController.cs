using Microsoft.AspNetCore.Mvc;
using Persons.Core.DTOs.Login;
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
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDTO loginRequest)
        {
            return Ok(await _personService.Login(loginRequest));
        }
    }
}
