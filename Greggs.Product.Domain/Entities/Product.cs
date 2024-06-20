using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Greggs.Products.Domain.Entities
{
    public class Product
    {
        public int ProductID { get; set; } 
        public string ProductName { get; set; }
        public decimal PriceInPounds { get; set; }
        public int CategoryID { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public bool IsDeleted { get; set; }
        public Category Category { get; set; }

        public List<NutritionalInformation> NutritionalInformations { get; set; }

    }
}
