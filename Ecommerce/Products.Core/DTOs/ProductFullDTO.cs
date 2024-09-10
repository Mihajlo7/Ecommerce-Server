using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Products.Core.DTOs
{
    public class ProductFullDTO
    { 
        public Guid Id { get; set; }
        public long ProductNumber { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Color { get; set; }
        public string Class {  get; set; }
        public SizeDTO Size { get; set; }
        public WeightDTO Weight { get; set; }
        public SubCategoryDTO SubCategory { get; set; }
    }
}
