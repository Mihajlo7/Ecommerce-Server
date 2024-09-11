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
        public string ShortDescription { get; set; }
        public string LongDescription { get; set; }
        public decimal Price { get; set; }
        public string Color { get; set; }
        public string Size { get; set; }
        public string Weight { get; set; }
        public string Status { get; set; }
        public string Image { get; set; }
        public Guid SubCategoryId { get; set; }
        public long SubCategoryNumber { get; set; }
        public string SubCategoryName { get; set; }
        public Guid CategoryId { get; set; }
        public long CategoryNumber { get; set; }
        public string CategoryName { get; set; }
    }
}
