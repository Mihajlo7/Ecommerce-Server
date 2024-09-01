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
        private readonly IDbOperations<PersonDbContext> _dbOperations;

        public ChangePasswordHandler(IDbOperations<PersonDbContext> dbOperations)
        {
            _dbOperations = dbOperations;
        }

        public async Task<ChangePasswordResponseDTO> Handle(ChangePasswordCommand request, CancellationToken cancellationToken)
        {
            var hash = PasswordGenerator.HashPassword(request.ChangePasswordRequest.NewPassword, out var salt);
            var stringSalt=Convert.ToBase64String(salt);
            try
            {
                var parameters = new SqlParameter[]
                {
                    new SqlParameter("@PersonId",System.Data.SqlDbType.UniqueIdentifier){Value=request.id},
                    new SqlParameter("@HashPassword",System.Data.SqlDbType.NVarChar,500){Value=hash},
                    new SqlParameter("@SaltPassword",System.Data.SqlDbType.NVarChar,500){Value=stringSalt}
                };
                var result = await _dbOperations.UpdateAsync(PersonOperations.SP_CHANGE_PASSWORD,false, parameters);
                if(result>0)
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
            }catch(SqlException ex)
            {
                throw ;
            }
        }
    }
}
