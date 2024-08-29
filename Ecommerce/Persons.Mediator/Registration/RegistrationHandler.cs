using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBOperations;
using Generic.Mediator;
using PasswordGeneratorPR;
using Persons.Core.DTOs.Registration;
using Persons.Infrastructure;

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
                // input parameters
                var firstName= new SqlParameter("FirstName",request.Registration.FirstName);
                var lastName= new SqlParameter("LastName",request.Registration.LastName);
                var birthday = new SqlParameter("BirthDay", request.Registration.BirthDay);
                var telephone = new SqlParameter("Telephone", request.Registration.Telephone);
                var email = new SqlParameter("Email", request.Registration.EmailAddress.Email);
                var emailProm = new SqlParameter("EmailPromotion", request.Registration.EmailAddress.EmailPromotion);
                var adress1 = new SqlParameter("AddressLine1", request.Registration.Address.AddressLine1);
                var adress2 = new SqlParameter("AddressLine2", request.Registration.Address.AddressLine2);
                var city= new SqlParameter("City",request.Registration.Address.City);
                var postalCode = new SqlParameter("PostalCode", request.Registration.Address.PostalCode);
                var countryCode = new SqlParameter("CountyCode", request.Registration.Address.CountryCode);
                var creditCardType = new SqlParameter("CreditCardType", request.Registration.CreditCard.Type);
                var creditCardNumber = new SqlParameter("CreditCardNumber",request.Registration.CreditCard.Number);
                var expMonth = new SqlParameter("ExpMonth", request.Registration.CreditCard.ExpMonth);
                var expYear = new SqlParameter("ExpYear", request.Registration.CreditCard.ExpYear);

                var hash = PasswordGenerator.HashPassword(request.Registration.Password.NewPassword,out var salt);
                var hashPassword = new SqlParameter("HashPassword", hash);
                var saltPassword =new SqlParameter("SaltPassword",Convert.ToBase64String(salt));
                // output parameters
                var outParam = new SqlParameter
                {
                    ParameterName = "RegisteredPersonId",
                    SqlDbType= System.Data.SqlDbType.UniqueIdentifier,
                    Direction=System.Data.ParameterDirection.Output
                };

                // execute stored procedure
                var registrationId  =
                    await _dbOperations
                    .UpdateObjectStoredProcedureWithResult(outParam, PersonOperations.SP_REGISTER_PERSON,
                    firstName,lastName,birthday,telephone,email,emailProm,hashPassword,saltPassword,adress1,adress2,city,postalCode,countryCode,creditCardType,creditCardNumber,expMonth,expYear);

                return new RegisterResponseDTO
                {
                    Id = registrationId,
                    Message = "Registration has been succefull"
                };

            }
            catch (Exception ex)
            {
                throw new Exception("Registration has been not succefull");
            }
        }
    }
}
