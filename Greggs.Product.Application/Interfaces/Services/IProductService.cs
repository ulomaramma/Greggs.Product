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
        Task<IEnumerable<ProductDTO>> GetLatestProducts(int pageStart, int pageSize, string orderBy);
        Task<IEnumerable<ProductDTO>> GetLatestProductsByLocation(int pageStart, int pageSize, string orderBy, string code);
    }
}
