using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Greggs.Products.Application.DTOs
{
    public class ProductDTO
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public decimal PriceInPounds { get; set; }
        public decimal ConvertedPrice { get; set; } // Converted Price in another 
        public string ConvertedCurrency { get; set; } 
        public int CategoryID { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public CategoryDTO Category { get; set; }
        public List<NutritionalInformationDTO> NutritionalInformations { get; set; }
    }
}
