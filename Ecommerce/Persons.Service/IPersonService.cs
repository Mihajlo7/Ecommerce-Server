using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Persons.Core.DTOs.ChangePassword;
using Persons.Core.DTOs.DeletePerson;
using Persons.Core.DTOs.GetPersonByEmail;
using Persons.Core.DTOs.Login;
using Persons.Core.DTOs.Registration;

namespace Persons.Service
{
    public interface IPersonService
    {
        public Task<RegisterResponseDTO> RegisterPerson(RegistrationDTO registrationDTO);
        public Task<LoginResponseDTO> Login(LoginRequestDTO loginRequestDTO);
        public Task<ChangePasswordResponseDTO> ChangePassword(Guid id,ChangePasswordRequestDTO changePasswordRequestDTO);
        public Task<DeletePersonResponseDTO> DeletePerson(Guid id);
        public Task<PersonByEmailResponseDTO> GetPersnByEmail(PersonRequestDTO personRequest);
    }
}
