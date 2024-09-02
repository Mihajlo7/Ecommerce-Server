using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBOperations;
using Generic.Mediator;
using Microsoft.Data.SqlClient;
using Persons.Core.DTOs.DeletePerson;
using Persons.Infrastructure;

namespace Persons.Mediator.DeletePerson
{
    internal class DeletePersonHandler : ICommandHandler<DeletePersonCommand, DeletePersonResponseDTO>
    {
        IDbOperations<PersonDbContext> _dbOperations;
        public DeletePersonHandler(IDbOperations<PersonDbContext> dbOperations)
        {
            _dbOperations = dbOperations;
        }
        public async Task<DeletePersonResponseDTO> Handle(DeletePersonCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var parameters = new SqlParameter[]
                {
                    new SqlParameter("@PersonId",System.Data.SqlDbType.UniqueIdentifier){Value=request.id}
                };
                var result = await _dbOperations.DeleteAsync(PersonOperations.SP_DELETE_PERSON, false, parameters);
                if (result)
                {
                    return new DeletePersonResponseDTO
                    {
                        Sucess = result,
                        Message = "Person has been deleted succefully"
                    };
                }
                else
                {
                    return new DeletePersonResponseDTO
                    {
                        Sucess = result,
                        Message = "Person has been not deleted"
                    };
                }
            }catch (SqlException ex)
            {
                throw;
            }
        }
    }
}
