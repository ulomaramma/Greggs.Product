using Greggs.Products.Application.DTOs;
using Greggs.Products.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Greggs.Products.Application.Interfaces.Services
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDTO>> List(int pageStart, int pageSize);
        Task<IEnumerable<ProductDTO>> ListWithConvertedPrices(int pageStart, int pageSize, string code);
        Task<IEnumerable<ProductDTO>> ListWithPricesInEuros(int pageStart, int pageSize); 
    }
}
