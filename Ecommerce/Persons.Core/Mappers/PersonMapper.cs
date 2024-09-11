using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Persons.Core.DTOs.GetPersonByEmail;
using Persons.Core.DTOs.Registration;

namespace Persons.Core.Mappers
{
    public static class PersonMapper
    {
        public static PersonByEmailResponseDTO mapToPersonFromSP(this IEnumerable<PersonByEmailRawResponse> data)
        {
            var firstData = data.First();

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
                Addresses = data
                .GroupBy(r => new { r.AddressLine1, r.AddressLine2, r.PostalCode, r.City, r.CountryCode })
                .Select(g => new Core.DTOs.Registration.AddressDTO
                {
                    AddressLine1 = g.Key.AddressLine1,
                    AddressLine2 = g.Key.AddressLine2,
                    PostalCode = g.Key.PostalCode,
                    City = g.Key.City,
                    CountryCode = g.Key.CountryCode
                }).ToList(),

                CreditCards = data
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
