﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Persons.Core.DTOs.ChangePassword;
using Persons.Core.DTOs.Login;
using Persons.Core.DTOs.Registration;
using Persons.Mediator.ChangePassword;
using Persons.Mediator.Login;
using Persons.Mediator.Registration;

namespace Persons.Service.implementation
{
    public class PersonService : IPersonService
    {
        private readonly IMediator _mediator;

        public PersonService(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<ChangePasswordResponseDTO> ChangePassword(Guid id, ChangePasswordRequestDTO changePasswordRequestDTO)
        {
            return await _mediator.Send(new ChangePasswordCommand(id,changePasswordRequestDTO));
        }

        public async Task<LoginResponseDTO> Login(LoginRequestDTO loginRequestDTO)
        {
            return await _mediator.Send(new LoginQuery(loginRequestDTO));
        }

        public async Task<RegisterResponseDTO> RegisterPerson(RegistrationDTO registrationDTO)
        {
            return await  _mediator.Send(new RegistrationCommand(registrationDTO));
        }
    }
}
