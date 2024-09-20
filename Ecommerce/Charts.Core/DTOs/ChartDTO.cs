using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Products.Core.DTOs;

namespace Charts.Core.DTOs
{
    public class ChartDTO
    {
        public Guid Id {  get; set; }
        public Guid PersonId { get; set; }
        public decimal Total {  get; set; }
        [JsonIgnore(Condition =JsonIgnoreCondition.WhenWritingNull)]
        public int Status { get; set; }
        public ICollection<CategoryDTO> Categories { get; set; }
    }
}
