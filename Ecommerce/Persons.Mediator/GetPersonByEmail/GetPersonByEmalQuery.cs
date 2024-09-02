using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Generic.Mediator;
using Persons.Core.DTOs.GetPersonByEmail;

namespace Persons.Mediator.GetPersonByEmail
{
    public record GetPersonByEmalQuery(PersonRequestDTO PersonRequest): IQuery<PersonByEmailResponseDTO>;
    
}
