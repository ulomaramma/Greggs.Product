using Greggs.Products.Application.DTOs;
using Greggs.Products.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Greggs.Products.Application.Mappings
{
    public static class NutrientMappingExtensions
    {
        public static NutrientDTO ToDTO(this Nutrient nutrient)
        {
            return new NutrientDTO
            {
                NutrientID = nutrient.NutrientID,
                Name = nutrient.Name,
                Unit = nutrient.Unit
            };
        }
    }
}
