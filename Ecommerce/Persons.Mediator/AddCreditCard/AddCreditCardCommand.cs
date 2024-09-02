using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Generic.Mediator;
using Persons.Core.DTOs.CreditCard;

namespace Persons.Mediator.AddCreditCard
{
    public record AddCreditCardCommand(Guid personId,CreditCardRequestDTO CreditCard) : ICommand<CreditCardResponseDTO>;
    
}
