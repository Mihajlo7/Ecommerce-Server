using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Persons.Core.DTOs.Registration;
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
        public Task<RegisterResponseDTO> RegisterPerson(RegistrationDTO registrationDTO)
        {
            return _mediator.Send(new RegistrationCommand(registrationDTO));
        }
    }
}
