using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Persons.Core.DTOs.CreditCard;
using Persons.Core.DTOs.GetPersonByEmail;
using Persons.Core.DTOs.Registration;

namespace Persons.Infrastructure
{
    public interface IPersonRepository
    {
        public Task<int> InsertPerson(RegistrationDTO registration);
        public Task<PasswordDTO> GetPasswordByPersonEmail(string email);
        public Task<int> UpdatePassword(Guid personId, string hash,string salt);
        public Task<int> InsertCreditCard(Guid personId,CreditCardRequestDTO creditCard);
        public Task<PersonByEmailResponseDTO> GetPersonByEmail(string email);
        public Task<bool> DeletePerson(Guid personId);
        public Task<bool> DeleteCreditCard(Guid personId,CreditCardRequestDTO creditCard);

    }
}
