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
        private readonly IPersonRepository _personRepository;
        public DeletePersonHandler(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }
        public async Task<DeletePersonResponseDTO> Handle(DeletePersonCommand request, CancellationToken cancellationToken)
        {
            var result = await _personRepository.DeletePerson(request.id);
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
            
        }
    }
}
