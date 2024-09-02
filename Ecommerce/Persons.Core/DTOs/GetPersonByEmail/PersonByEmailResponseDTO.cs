using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Persons.Core.DTOs.Registration;

namespace Persons.Core.DTOs.GetPersonByEmail
{
    public class PersonByEmailResponseDTO
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDay { get; set; }
        public string Telephone { get; set; }
        public EmailAddressDTO EmailAddress { get; set; }
        public ICollection<AddressDTO> Addresses { get; set; }
        public ICollection<CreditCardDTO> CreditCards { get; set; }
    }
}
