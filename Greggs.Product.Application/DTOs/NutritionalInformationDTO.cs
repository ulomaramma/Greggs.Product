using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Greggs.Products.Application.DTOs
{
    public class NutritionalInformationDTO
    {
        public int NutritionID { get; set; }
        public int NutrientID { get; set; }
        public decimal Measurement { get; set; }
        public decimal NutritionalValue { get; set; }
        public NutrientDTO Nutrient { get; set; }
    }
}
