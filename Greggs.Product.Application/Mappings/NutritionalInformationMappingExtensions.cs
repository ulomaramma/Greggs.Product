using Greggs.Products.Application.DTOs;
using Greggs.Products.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Greggs.Products.Application.Mappings
{
    public static class NutritionalInformationMappingExtensions
    {
        public static NutritionalInformationDTO ToDTO(this NutritionalInformation nutritionalInformation)
        {
            return new NutritionalInformationDTO
            {
                NutritionID = nutritionalInformation.NutritionID,
                NutrientID = nutritionalInformation.NutrientID,
                Measurement = nutritionalInformation.Measurement,
                NutritionalValue = nutritionalInformation.NutritionalValue,
                Nutrient = nutritionalInformation.Nutrient?.ToDTO()
            };
        }
    }
}
