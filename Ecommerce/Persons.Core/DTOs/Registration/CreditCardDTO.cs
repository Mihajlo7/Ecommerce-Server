using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persons.Core.DTOs.Registration
{
    public class CreditCardDTO
    {
        
            public string Type { get; set; }
            public string Number { get; set; }
            public int ExpMonth { get; set; }
            public int ExpYear { get; set; }
        
    }
}
