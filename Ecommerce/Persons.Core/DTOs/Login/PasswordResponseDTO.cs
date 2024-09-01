using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persons.Core.DTOs.Login
{
    public class PasswordResponseDTO
    {
        public string HashPassword { get; set; }
        public string SaltPassword { get; set; }
    }
}
