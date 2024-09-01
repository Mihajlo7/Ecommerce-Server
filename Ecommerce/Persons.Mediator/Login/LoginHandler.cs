using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBOperations;
using Generic.Mediator;
using Microsoft.Data.SqlClient;
using Persons.Core.DTOs.Login;
using Persons.Infrastructure;

namespace Persons.Mediator.Login
{
    public class LoginHandler : IQueryHandler<LoginQuery, LoginResponseDTO>
    {
        private readonly IDbOperations<PersonDbContext> _dbOperations;

        public LoginHandler(IDbOperations<PersonDbContext> dbOperations)
        {
            _dbOperations = dbOperations;
        }
        public async Task<LoginResponseDTO> Handle(LoginQuery request, CancellationToken cancellationToken)
        {
            try
            {
                // input parameter
                var parameters = new SqlParameter[]
                {
                    new SqlParameter("@Email",System.Data.SqlDbType.NVarChar,255){Value=request.LoginRequest.Email}
                };

                // execute procedure
                var result = await  _dbOperations.GetAsync<PasswordResponseDTO>(PersonOperations.LOGIN, parameters);

                // check password
                if(PasswordGeneratorPR.PasswordGenerator
                    .VerifyPassword(request.LoginRequest.Password, result.PasswordHash, Convert.FromBase64String(result.PasswordSalt)))
                {
                    return new LoginResponseDTO()
                    {
                        Success = true,
                        Message = " Login has been succefull"!
                    };
                }
                else
                {
                    return new LoginResponseDTO()
                    {
                        Success = false,
                        Message = "Email or Password is not correct!"
                    };
                }
            }catch (SqlException ex)
            {
                if(ex.Message== "Email does not exists!")
                {
                    return new LoginResponseDTO()
                    {
                        Success = false,
                        Message = "Email or Password is not correct!"
                    };
                }
                throw;
            }
        }
    }
}
