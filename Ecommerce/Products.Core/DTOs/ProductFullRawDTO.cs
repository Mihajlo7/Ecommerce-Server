using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Products.Core.DTOs
{
    public class ProductFullRawDTO
    {
        public Guid Id { get; set; }
        public long ProductNumber { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Color { get; set; }
        public string Class { get; set; }
        public string Size { get; set; }
        public string Weight { get; set; }
        public Guid SubCategoryId { get; set; }
        public long SubCategoryNumber { get; set; }
        public string SubCategoryName { get; set; }
    }
}
