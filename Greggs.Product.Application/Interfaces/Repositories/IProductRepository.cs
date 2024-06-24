using Greggs.Products.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Greggs.Products.Application.Interfaces.QueryBuilder;

namespace Greggs.Products.Application.Interfaces.Repositories
{
    public interface IProductRepository
    {
        IProductQueryBuilder GetLatestProducts(string orderby);
    }
}
