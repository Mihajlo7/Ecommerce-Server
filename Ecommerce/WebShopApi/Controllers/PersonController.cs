using Microsoft.AspNetCore.Mvc;
using Persons.Core.DTOs.ChangePassword;
using Persons.Core.DTOs.CreditCard;
using Persons.Core.DTOs.GetPersonByEmail;
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
        [HttpPost("changePassword/{id}")]
        public async Task<IActionResult> ChangePassword(Guid id, [FromBody] ChangePasswordRequestDTO changePassword)
        {
            return Ok(await _personService.ChangePassword(id, changePassword));
        }
        [HttpDelete("deletePerson{id}")]
        public async Task<IActionResult> DeletePerson(Guid id)
        {
            return Ok(await _personService.DeletePerson(id));
        }
        [HttpPost("getPersonByEmail")]
        public async Task<IActionResult> GetPersonByEmail([FromBody] PersonRequestDTO personRequest)
        {
            return Ok(await _personService.GetPersnByEmail(personRequest));
        }
        [HttpPost("addCreditCard/{id}")]
        public async Task<IActionResult> AddCreditCard(Guid id,[FromBody] CreditCardRequestDTO creditCardRequest)
        {
            return Ok(await _personService.AddCreditCard(id, creditCardRequest));
        }
        [HttpDelete("deleteCreditCard/{id}")]
        public async Task<IActionResult> DeleteCreditCard(Guid id, [FromBody]  CreditCardRequestDTO creditCardRequest)
        {
            return Ok(await _personService.DeleteCreditCard(id,creditCardRequest));
        }
        
    }
}
