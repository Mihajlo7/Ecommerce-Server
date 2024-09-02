﻿using System;
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
        private readonly IDbOperations<PersonDbContext> _dbOperations;

        public AddCreditCardHandler(IDbOperations<PersonDbContext> dbOperations)
        {
            _dbOperations = dbOperations;
        }
        public async Task<CreditCardResponseDTO> Handle(AddCreditCardCommand request, CancellationToken cancellationToken)
        {
            // parameters
            var parameters = new SqlParameter[]
            {
                new SqlParameter("@PersonId",System.Data.SqlDbType.UniqueIdentifier){Value=request.personId},
                new SqlParameter("@Type",System.Data.SqlDbType.NVarChar,50){Value=request.CreditCard.Type},
                new SqlParameter("@Number",System.Data.SqlDbType.NVarChar,50){Value=request.CreditCard.Number},
                new SqlParameter("@ExpMonth",System.Data.SqlDbType.Int){Value=request.CreditCard.ExpMonth},
                new SqlParameter("@ExpYear",System.Data.SqlDbType.Int){Value=request.CreditCard.ExpYear},
            };

            // execute
            var result= await _dbOperations.CreateAsync(PersonOperations.SP_ADD_CREDIT_CARD,false,parameters);
            if(result>0)
            {
                return new CreditCardResponseDTO
                {
                    Success = true,
                    Message = "Credit Card has been succefully added"
                };
            }
            else
            {
                return new CreditCardResponseDTO
                {
                    Success = false,
                    Message = "Credit Card has not been added!"
                };
            }
        }
    }
}
