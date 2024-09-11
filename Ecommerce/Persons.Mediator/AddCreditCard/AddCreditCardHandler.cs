using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBOperations;
using Generic.Mediator;
using Microsoft.Data.SqlClient;
using Persons.Core.DTOs.CreditCard;
using Persons.Infrastructure;

namespace Persons.Mediator.AddCreditCard
{
    internal class AddCreditCardHandler : ICommandHandler<AddCreditCardCommand, CreditCardResponseDTO>
    {
        private readonly IPersonRepository _personRepository;

        public AddCreditCardHandler(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }
        public async Task<CreditCardResponseDTO> Handle(AddCreditCardCommand request, CancellationToken cancellationToken)
        {
            int numOfInsertedPerson = await _personRepository.InsertCreditCard(request.personId,request.CreditCard);

            if (numOfInsertedPerson == 1)
            {
                return new CreditCardResponseDTO() { Success=true, Message=$"Credit Card has been succefull added to person with id {request.personId}"};
            }
            else
            {
                return new CreditCardResponseDTO() { Success = false, Message = $"Adding new Credit Card is failed" };
            }
        }
    }
}
