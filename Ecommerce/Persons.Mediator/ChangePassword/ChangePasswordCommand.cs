using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Generic.Mediator;
using Persons.Core.DTOs.ChangePassword;

namespace Persons.Mediator.ChangePassword
{
    public record ChangePasswordCommand(Guid id,ChangePasswordRequestDTO ChangePasswordRequest): ICommand<ChangePasswordResponseDTO>;
    
}
