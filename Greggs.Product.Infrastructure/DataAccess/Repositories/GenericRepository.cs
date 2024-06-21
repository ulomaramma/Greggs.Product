using Azure;
using Greggs.Products.Application.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Greggs.Products.Infrastructure.DataAccess.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly ApplicationDbContext _context;
        public GenericRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public virtual async Task<IEnumerable<T>> List(int pageStart, int pageSize)
        {
            return await _context.Set<T>().Skip(pageStart * pageSize).Take(pageSize).ToListAsync();
        }
    }
}
