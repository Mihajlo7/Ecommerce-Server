using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBOperations;
using Generic.Mediator;
using Microsoft.Data.SqlClient;
using PasswordGeneratorPR;
using Persons.Core.DTOs.ChangePassword;
using Persons.Infrastructure;

namespace Persons.Mediator.ChangePassword
{
    internal class ChangePasswordHandler : ICommandHandler<ChangePasswordCommand, ChangePasswordResponseDTO>
    {
        private readonly IPersonRepository _personRepository;

        public ChangePasswordHandler(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        public async Task<ChangePasswordResponseDTO> Handle(ChangePasswordCommand request, CancellationToken cancellationToken)
        {
            var hash = PasswordGenerator.HashPassword(request.ChangePasswordRequest.NewPassword, out var salt);
            var stringSalt=Convert.ToBase64String(salt);

            var affectedRow = await _personRepository.UpdatePassword(request.id, hash, stringSalt);
                
            if(affectedRow>0)
                {
                    return new ChangePasswordResponseDTO
                    {
                        Sucess = true,
                        Message = "Password has been changed succefully"
                    };
                }
                else
                {
                    return new ChangePasswordResponseDTO
                    {
                        Sucess = false,
                        Message = "Password has not been changed"
                    };
                }
        }
    }
}
