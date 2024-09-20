using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Charts.Core.DTOs
{
    public class ChartHistoryDTO
    {
        public Guid PersonId { get; set; }
        public string Products { get; set; }
        public decimal Total {  get; set; }
    }
}
