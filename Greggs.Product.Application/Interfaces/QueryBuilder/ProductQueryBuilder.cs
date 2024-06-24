using Greggs.Products.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Greggs.Products.Application.Interfaces.QueryBuilder
{
    public interface IProductQueryBuilder
    {
        IProductQueryBuilder IncludeCategory();
        IProductQueryBuilder IncludeNutritionalInformations();
        IProductQueryBuilder OrderByDescending(string orderBy);
        Task<IEnumerable<Product>> GetPagedProducts(int pageStart, int pageSize);
        Task<IEnumerable<Product>> ToListAsync();
    }
}
