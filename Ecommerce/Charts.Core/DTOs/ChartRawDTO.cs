using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Charts.Core.DTOs
{
    public class ChartRawDTO
    {
        public Guid Id { get; set; }
        public Guid PersonId { get; set; }
        public string Products { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
