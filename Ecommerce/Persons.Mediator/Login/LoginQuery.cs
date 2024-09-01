using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Generic.Mediator;
using Persons.Core.DTOs.Login;

namespace Persons.Mediator.Login
{
    public record LoginQuery(LoginRequestDTO LoginRequest): IQuery<LoginResponseDTO>;
    
}
