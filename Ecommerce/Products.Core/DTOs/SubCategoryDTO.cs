using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Products.Core.DTOs
{
    public class SubCategoryDTO
    {
        public Guid SubCategoryId { get; set; }
        public long SubCategoryNumber { get; set; }
        public string SubCategoryName { get; set;}
    }
}
