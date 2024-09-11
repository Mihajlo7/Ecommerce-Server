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
        private readonly IPersonRepository _personRepository;

        public LoginHandler(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }
        public async Task<LoginResponseDTO> Handle(LoginQuery request, CancellationToken cancellationToken)
        {
            try
            {
                // input parameter
                var result = await _personRepository.GetPasswordByPersonEmail(request.LoginRequest.Email);
                
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
