using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Greggs.Product.Domain.Entities
{
    public class Nutrient
    {
        public int NutrientID { get; set; }
        public string Name { get; set; }
        public string Unit { get; set; }
    }
}
