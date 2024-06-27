using Greggs.Products.Application.Interfaces.QueryBuilder;
using Greggs.Products.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Greggs.Products.Infrastructure.DataAccess.QueryBuilder
{
    public class ProductQueryBuilder : IProductQueryBuilder
    {
        private readonly ApplicationDbContext _context;
        private IQueryable<Product> _query;

        public ProductQueryBuilder(ApplicationDbContext context)
        {
            _context = context;
            _query = _context.Products.Where(p => !p.IsDeleted);
        }

        public IProductQueryBuilder IncludeCategory()
        {
            _query = _query.Include(p => p.Category);
            return this;
        }

        public IProductQueryBuilder IncludeNutritionalInformations()
        {
            _query = _query.Include(p => p.NutritionalInformations)
                           .ThenInclude(n => n.Nutrient);
            return this;
        }

        public IProductQueryBuilder OrderByDescending(string orderBy)
        {
            _query = _query.OrderByDescending(p => EF.Property<object>(p, orderBy));
            return this;
        }

        public async Task<IEnumerable<Product>> GetPagedProducts(int pageStart, int pageSize)
        {
            return await _query.Skip(pageStart * pageSize)
                               .Take(pageSize)
                               .ToListAsync();
        }


        public async Task<IEnumerable<Product>> ToListAsync()
        {
            return await _query.ToListAsync();
        }
    }
}
