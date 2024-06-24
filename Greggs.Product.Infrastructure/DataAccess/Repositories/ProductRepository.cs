using Azure;
using Greggs.Products.Application.Interfaces.QueryBuilder;
using Greggs.Products.Application.Interfaces.Repositories;
using Greggs.Products.Domain.Entities;
using Greggs.Products.Infrastructure.DataAccess.QueryBuilder;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Greggs.Products.Infrastructure.DataAccess.Repositories
{
    public class ProductRepository 
    {
        private readonly ApplicationDbContext _context;
        private readonly IProductQueryBuilder _productQueryBuilder;

        public ProductRepository(ApplicationDbContext context, IProductQueryBuilder productQueryBuilder)
        {
            _context = context;
            _productQueryBuilder = productQueryBuilder;

        }

        public IProductQueryBuilder GetLatestProducts(string orderBy)
        {
            return _productQueryBuilder
                        .IncludeCategory()
                        .IncludeNutritionalInformations()
                        .OrderByDescending(orderBy);
        }






    }
}
