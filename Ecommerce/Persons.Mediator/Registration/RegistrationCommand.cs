using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Generic.Mediator;
using Persons.Core.DTOs.Registration;

namespace Persons.Mediator.Registration
{
    public record RegistrationCommand(RegistrationDTO Registration): ICommand<RegisterResponseDTO>;
    
}
