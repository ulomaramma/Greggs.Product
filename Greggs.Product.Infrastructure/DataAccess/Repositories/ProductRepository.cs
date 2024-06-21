using Azure;
using Greggs.Products.Application.Interfaces.Repositories;
using Greggs.Products.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Greggs.Products.Infrastructure.DataAccess.Repositories
{
    public class ProductRepository :  GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(ApplicationDbContext context) : base(context)
        {
        }

        public override async Task<IEnumerable<Product>> List(int pageStart, int pageSize)
        {
            var products = await _context.Products.Where(p => !p.IsDeleted).Include(p => p.Category).Include(p => p.NutritionalInformations)
                        .ThenInclude(n => n.Nutrient).OrderByDescending(p => p.CreatedDate)
                        .Skip(pageStart * pageSize)
                        .Take(pageSize)
                        .ToListAsync();

            return products;
        }
    }
}
