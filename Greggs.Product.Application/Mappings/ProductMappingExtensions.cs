using Greggs.Products.Application.DTOs;
using Greggs.Products.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Greggs.Products.Application.Mappings
{
    public static class ProductMappingExtensions
    {
        public static ProductDTO ToDTO(this Product product)
        {
            return new ProductDTO
            {
                ProductID = product.ProductID,
                ProductName = product.ProductName,
                PriceInPounds = product.PriceInPounds,
                CategoryID = product.CategoryID,
                Description = product.Description,
                CreatedDate = product.CreatedDate,
                UpdatedDate = product.UpdatedDate,
                Category = product.Category?.ToDTO(),
                NutritionalInformations = product.NutritionalInformations?.Select(ni => ni.ToDTO()).ToList()
            };
        }
    }
}
