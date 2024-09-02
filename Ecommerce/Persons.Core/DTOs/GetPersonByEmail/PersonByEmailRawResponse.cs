using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persons.Core.DTOs.GetPersonByEmail
{
    public class PersonByEmailRawResponse
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDay { get; set; }
        public string Telephone { get; set; }
        public string Email { get; set; }
        public int EmailPromotion { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string PostalCode { get; set; }
        public string City { get; set; }
        public string CountryCode { get; set; }
        public string CountryName { get; set; }
        public string CreditCardType { get; set; }
        public string CreditCardNumber { get; set; }
        public int ExpMonth { get; set; }
        public int ExpYear { get; set; }
    }
}
