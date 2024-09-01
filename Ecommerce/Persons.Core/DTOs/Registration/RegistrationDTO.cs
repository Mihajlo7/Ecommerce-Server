using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persons.Core.DTOs.Registration
{
    public class RegistrationDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string BirthDay { get; set; }
        public string Telephone { get; set; }
        public PasswordDTO Password { get; set; }
        public EmailAddressDTO EmailAddress { get; set; }
        public CreditCardDTO CreditCard { get; set; }
        public AddressDTO Address { get; set; }
    }
}
