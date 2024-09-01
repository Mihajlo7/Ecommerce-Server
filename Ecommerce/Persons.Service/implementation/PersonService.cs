using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Persons.Core.DTOs.Login;
using Persons.Core.DTOs.Registration;
using Persons.Mediator.Login;
using Persons.Mediator.Registration;

namespace Persons.Service.implementation
{
    public class PersonService : IPersonService
    {
        private readonly IMediator _mediator;

        public PersonService(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<LoginResponseDTO> Login(LoginRequestDTO loginRequestDTO)
        {
            return await _mediator.Send(new LoginQuery(loginRequestDTO));
        }

        public async Task<RegisterResponseDTO> RegisterPerson(RegistrationDTO registrationDTO)
        {
            return await  _mediator.Send(new RegistrationCommand(registrationDTO));
        }
    }
}
