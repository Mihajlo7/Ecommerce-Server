using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Charts.Core.DTOs
{
    public class ChartUpdateDTO
    {
        public Guid Id { get; set; }
        public Guid PersonId { get; set; }
        public DateTime UpdatedAt { get; set; }
        public ICollection<ChartProductDTO> Products { get; set; }
    }
}
