using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBOperations;
using Generic.Mediator;
using PasswordGeneratorPR;
using Persons.Core.DTOs.Registration;
using Persons.Infrastructure;
using System.Data;
using System.Globalization;

namespace Persons.Mediator.Registration
{
    public class RegistrationHandler : ICommandHandler<RegistrationCommand, RegisterResponseDTO>
    {
        private readonly IPersonRepository _personRepository;

        public RegistrationHandler(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }
        public async Task<RegisterResponseDTO> Handle(RegistrationCommand request, CancellationToken cancellationToken)
        {
            var result = await _personRepository.InsertPerson(request.Registration);
            
                return new RegisterResponseDTO
                {
                    Number= result,
                    Message = "Registration has been successfull"
                };
            }
        }
    }
