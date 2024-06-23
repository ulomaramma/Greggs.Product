using Greggs.Products.Application.Interfaces.Repositories;
using Greggs.Products.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Greggs.Products.Infrastructure.DataAccess.Repositories
{
    public class LocationRepository: GenericRepository<Location>, ILocationRepository
    {
        public LocationRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<Location> GetByLocationCodeAsync(string code)
        {
            return await _context.Locations.Where(l => l.Code == code).FirstOrDefaultAsync();
        }
    }
}
