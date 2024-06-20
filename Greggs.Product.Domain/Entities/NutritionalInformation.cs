using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Greggs.Products.Domain.Entities
{
    public class NutritionalInformation
    {
        public int NutritionID { get; set; }
        public int ProductID { get; set; }
        public int NutrientID { get; set; }
        public decimal Measurement { get; set; }
        public decimal NutritionalValue { get; set; }
        public Product Product { get; set; }
        public Nutrient Nutrient { get; set; }
    }
}
