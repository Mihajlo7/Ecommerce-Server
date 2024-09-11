using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Generic.Mediator;
using Products.Core.DTOs;

namespace Products.Mediator.GetAppleProducts
{
    public sealed record GetAppleProductsQuery() : IQuery<IEnumerable<ProductDTO>>;
    
    
}
