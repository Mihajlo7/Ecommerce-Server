﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Generic.Mediator;
using Products.Core.DTOs;

namespace Products.Mediator.GetProductsBySubCategory
{
    public sealed record GetProductsBySubCategoryIdQuery(Guid SubCategoryId): IQuery<IEnumerable<ProductDTO>>;
    
}
