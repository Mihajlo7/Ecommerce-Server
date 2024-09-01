﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Persons.Core.DTOs.Registration;

namespace Persons.Service
{
    public interface IPersonService
    {
        public Task<RegisterResponseDTO> RegisterPerson(RegistrationDTO registrationDTO);
    }
}
