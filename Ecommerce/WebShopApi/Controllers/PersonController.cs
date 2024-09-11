using MediatR;
using Microsoft.AspNetCore.Mvc;
using Persons.Core.DTOs.ChangePassword;
using Persons.Core.DTOs.CreditCard;
using Persons.Core.DTOs.GetPersonByEmail;
using Persons.Core.DTOs.Login;
using Persons.Core.DTOs.Registration;
using Persons.Mediator.AddCreditCard;
using Persons.Mediator.ChangePassword;
using Persons.Mediator.DeleteCreditCard;
using Persons.Mediator.DeletePerson;
using Persons.Mediator.GetPersonByEmail;
using Persons.Mediator.Login;
using Persons.Mediator.Registration;


namespace WebShopApi.Controllers
{
    [ApiController]
    [Route("api/people")]
    public class PersonController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PersonController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost("registration")]
        public async Task<IActionResult> Registration([FromBody] RegistrationDTO registrationDTO)
        {
            var registrationResult=await _mediator.Send(new RegistrationCommand(registrationDTO));
            if(registrationResult.Number>0)
            {
                return Ok(registrationResult);
            }
            else
            {
                return BadRequest(registrationResult);
            }
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDTO loginRequest)
        {
            var loginResult=await _mediator.Send(new LoginQuery(loginRequest));
            if(loginResult.Success)
            {
                return Ok(loginResult);
            }
            else
            {
                return BadRequest(loginResult);
            }
        }
        [HttpPost("changePassword/{id}")]
        public async Task<IActionResult> ChangePassword(Guid id, [FromBody] ChangePasswordRequestDTO changePassword)
        {
            var changePasswordResult = await _mediator.Send(new ChangePasswordCommand(id,changePassword));
            if (changePasswordResult.Sucess)
            {
                return Ok(changePasswordResult);
            }
            else
            {
                return BadRequest(changePasswordResult);
            }
        }
        [HttpDelete("deletePerson{id}")]
        public async Task<IActionResult> DeletePerson(Guid id)
        {
            var deletedPersonResult = await _mediator.Send(new DeletePersonCommand(id));
            return deletedPersonResult.Sucess ? Ok(deletedPersonResult) : BadRequest(deletedPersonResult);
        }
        [HttpPost("getPersonByEmail")]
        public async Task<IActionResult> GetPersonByEmail([FromBody] PersonRequestDTO personRequest)
        {
            var personByEmailResult = await _mediator.Send(new GetPersonByEmalQuery(personRequest));
            return Ok(personByEmailResult);
        }
        [HttpPost("addCreditCard/{id}")]
        public async Task<IActionResult> AddCreditCard(Guid id,[FromBody] CreditCardRequestDTO creditCardRequest)
        {
            var addedCreditCardResult = await _mediator.Send(new AddCreditCardCommand(id,creditCardRequest));
            return addedCreditCardResult.Success ? Ok(addedCreditCardResult) : BadRequest(addedCreditCardResult);
        }
        [HttpDelete("deleteCreditCard/{id}")]
        public async Task<IActionResult> DeleteCreditCard(Guid id, [FromBody]  CreditCardRequestDTO creditCardRequest)
        {
            var deletedCreditCardResult = await _mediator.Send(new DeleteCreditCardCommand(id,creditCardRequest));
            return deletedCreditCardResult.Success ? Ok(deletedCreditCardResult): BadRequest(deletedCreditCardResult);
        }
        
    }
}
