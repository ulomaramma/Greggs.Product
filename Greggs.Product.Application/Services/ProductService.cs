using Greggs.Products.Application.DTOs;
using Greggs.Products.Application.Interfaces.Repositories;
using Greggs.Products.Application.Interfaces.Services;
using Greggs.Products.Application.Mappings;
using Greggs.Products.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Greggs.Products.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<IEnumerable<ProductDTO>> List(int pageStart, int pageSize)
        {
            var products = await _productRepository.List(pageStart, pageSize);
            return products.Select(p => p.ToDTO());
        }
    }
}
