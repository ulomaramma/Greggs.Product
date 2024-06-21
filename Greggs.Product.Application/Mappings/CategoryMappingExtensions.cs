using Greggs.Products.Application.DTOs;
using Greggs.Products.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Greggs.Products.Application.Mappings
{
    public static class CategoryMappingExtensions
    {
        public static CategoryDTO ToDTO(this Category category)
        {
            return new CategoryDTO
            {
                CategoryID = category.CategoryID,
                Name = category.Name
            };
        }
    }
}
