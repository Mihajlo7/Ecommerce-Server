using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Generic.Mediator;
using Persons.Core.DTOs.DeletePerson;

namespace Persons.Mediator.DeletePerson
{
    public record DeletePersonCommand(Guid id): ICommand<DeletePersonResponseDTO>;
    
}
