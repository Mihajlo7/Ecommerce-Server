using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBOperations;
using Generic.Mediator;
using Microsoft.Data.SqlClient;
using Persons.Core.DTOs.GetPersonByEmail;
using Persons.Core.DTOs.Registration;
using Persons.Infrastructure;

namespace Persons.Mediator.GetPersonByEmail
{
    internal class GetPersonByEmailHandler : IQueryHandler<GetPersonByEmalQuery, PersonByEmailResponseDTO>
    {
        private readonly IPersonRepository _personRepository;

        public GetPersonByEmailHandler(IPersonRepository personRepository)
        {
            _personRepository=personRepository;
        }
        public async Task<PersonByEmailResponseDTO> Handle(GetPersonByEmalQuery request, CancellationToken cancellationToken)
        {
            var personByEmail = await _personRepository.GetPersonByEmail(request.PersonRequest.Email);

            return personByEmail;
        }
        
    }
}
