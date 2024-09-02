using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBOperations;
using Generic.Mediator;
using Microsoft.Data.SqlClient;
using Persons.Core.DTOs.GetPersonByEmail;
using Persons.Core.DTOs.Registration;
using Persons.Infrastructure;

namespace Persons.Mediator.GetPersonByEmail
{
    internal class GetPersonByEmailHandler : IQueryHandler<GetPersonByEmalQuery, PersonByEmailResponseDTO>
    {
        private readonly IDbOperations<PersonDbContext> _dbOperations;

        public GetPersonByEmailHandler(IDbOperations<PersonDbContext> dbOperations)
        {
            _dbOperations = dbOperations;
        }
        public async Task<PersonByEmailResponseDTO> Handle(GetPersonByEmalQuery request, CancellationToken cancellationToken)
        {
            try
            {
                // input parameters
                var parameters = new SqlParameter[]
                {
                    new SqlParameter("@Email",System.Data.SqlDbType.NVarChar, 255){Value=request.PersonRequest.Email},
                };
                // execute
                var result = await _dbOperations.GetAllAsync<PersonByEmailRawResponse>(PersonOperations.SP_GET_PERSON_BY_EMAIL,parameters);

                return mapPersonRawToPersonDTO(result);
            }catch (SqlException ex)
            {
                throw;
            }
        }
        private PersonByEmailResponseDTO mapPersonRawToPersonDTO(IList<PersonByEmailRawResponse> personByEmailRawResponses)
        {
            var firstData= personByEmailRawResponses.First();

            var personByEmail = new PersonByEmailResponseDTO()
            {
                Id = firstData.Id,
                FirstName = firstData.FirstName,
                LastName = firstData.LastName,
                BirthDay = firstData.BirthDay,
                Telephone = firstData.Telephone,
                EmailAddress = new Core.DTOs.Registration.EmailAddressDTO
                {
                    Email = firstData.Email,
                    EmailPromotion = firstData.EmailPromotion,
                },
                Addresses = personByEmailRawResponses
                .GroupBy(r => new { r.AddressLine1, r.AddressLine2, r.PostalCode, r.City, r.CountryCode })
                .Select(g => new Core.DTOs.Registration.AddressDTO
                {
                    AddressLine1 = g.Key.AddressLine1,
                    AddressLine2 = g.Key.AddressLine2,
                    PostalCode = g.Key.PostalCode,
                    City = g.Key.City,
                    CountryCode = g.Key.CountryCode
                }).ToList(),

                CreditCards = personByEmailRawResponses
            .GroupBy(r => new { r.CreditCardType, r.CreditCardNumber, r.ExpMonth, r.ExpYear })
            .Select(g => new CreditCardDTO
            {
                Type = g.Key.CreditCardType,
                Number = g.Key.CreditCardNumber,
                ExpMonth = g.Key.ExpMonth,
                ExpYear = g.Key.ExpYear
            })
            .ToList()
            };

            return personByEmail;
        }
    }
}
