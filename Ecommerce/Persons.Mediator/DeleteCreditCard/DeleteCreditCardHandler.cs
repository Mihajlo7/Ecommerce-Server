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

namespace Persons.Mediator.DeleteCreditCard
{
    internal class DeleteCreditCardHandler : ICommandHandler<DeleteCreditCardCommand, CreditCardResponseDTO>
    {
        private readonly IPersonRepository _personRepository;

        public DeleteCreditCardHandler(IPersonRepository personRepository)
        {
            _personRepository=personRepository;
        }
        public async Task<CreditCardResponseDTO> Handle(DeleteCreditCardCommand request, CancellationToken cancellationToken)
        {
            var result = await _personRepository.DeleteCreditCard(request.personId,request.CreditCard);
            if (result)
            {
                return new CreditCardResponseDTO
                {
                    Success = true,
                    Message = "Credit Card has been succefully deleted"
                };
            }
            else
            {
                return new CreditCardResponseDTO
                {
                    Success = false,
                    Message = "Credit Card has not been deleted!"
                };
            }
        }
    }
}
