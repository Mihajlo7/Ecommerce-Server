using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBOperations;
using Generic.Mediator;
using PasswordGeneratorPR;
using Persons.Core.DTOs.Registration;
using Persons.Infrastructure;
using System.Data;
using System.Globalization;

namespace Persons.Mediator.Registration
{
    public class RegistrationHandler : ICommandHandler<RegistrationCommand, RegisterResponseDTO>
    {
        private readonly IDbOperations<PersonDbContext> _dbOperations;

        public RegistrationHandler(IDbOperations<PersonDbContext> dbOperations)
        {
            _dbOperations = dbOperations;
        }
        public async Task<RegisterResponseDTO> Handle(RegistrationCommand request, CancellationToken cancellationToken)
        {
            try
            {
                // hashing password
                var hash = PasswordGenerator.HashPassword(request.Registration.Password.NewPassword, out var salt);
                // input parameters
                Console.WriteLine(request.Registration.Address.CountryCode);
               
                var parameters = new SqlParameter[]
                {
                    new SqlParameter("@FirstName", SqlDbType.NVarChar, 50) { Value = request.Registration.FirstName },
                    new SqlParameter("@LastName", SqlDbType.NVarChar, 50) { Value=request.Registration.LastName},
                    new SqlParameter("@BirthDay", SqlDbType.NVarChar, 20) { Value = request.Registration.BirthDay},
                    new SqlParameter("@Telephone", SqlDbType.NVarChar, 20) { Value = request.Registration.Telephone},
                    new SqlParameter("@HashPassword", SqlDbType.NVarChar, 500) { Value = hash},
                    new SqlParameter("@SaltPassword", SqlDbType.NVarChar, 500) { Value = Convert.ToBase64String(salt) },
                    new SqlParameter("@Email", SqlDbType.NVarChar, 255) { Value = request.Registration.EmailAddress.Email},
                    new SqlParameter("@EmailPromotion", SqlDbType.Int) { Value = request.Registration.EmailAddress.EmailPromotion },
                    new SqlParameter("@AddressLine1", SqlDbType.NVarChar, 255) { Value = request.Registration.Address.AddressLine1 },
                    new SqlParameter("@AddressLine2", SqlDbType.NVarChar, 255) { Value = request.Registration.Address.AddressLine2},
                    new SqlParameter("@City", SqlDbType.NVarChar, 100) { Value = request.Registration.Address.City},
                    new SqlParameter("@PostalCode", SqlDbType.NVarChar, 20) { Value = request.Registration.Address.PostalCode},
                    new SqlParameter("@CountryCode", SqlDbType.NVarChar, 10) { Value = request.Registration.Address.CountryCode },
                    new SqlParameter("@Type", SqlDbType.NVarChar, 50) { Value = request.Registration.CreditCard.Type},
                    new SqlParameter("@Number", SqlDbType.NVarChar, 50) { Value = request.Registration.CreditCard.Number },
                    new SqlParameter("@ExpMonth", SqlDbType.Int) { Value =request.Registration.CreditCard.ExpMonth },
                    new SqlParameter("@ExpYear", SqlDbType.Int) { Value = request.Registration.CreditCard.ExpYear}
                };
                // execute stored procedure
                var result = await _dbOperations.CreateAsync(PersonOperations.SP_REGISTER_PERSON, false, parameters);

                return new RegisterResponseDTO
                {
                    Number= result,
                    Message = "Registration has been successfull"
                };
            } catch (SqlException ex)
            {
                return new RegisterResponseDTO
                {
                    Id = Guid.Empty,
                    Message = $"Registration has been successfull\nEXCEPTION:{ex.Message}\nINNER:{ex.InnerException}\nSTACKTRACE:{ex.StackTrace} {ex.Procedure},{ex.LineNumber},{ex.Data},{ex.Class}"
                };
            };
        }
    }
}
