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
    public class LocationRepository: ILocationRepository
    {
        private readonly ApplicationDbContext _context;

        public LocationRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Location> GetByLocationCodeAsync(string code)
        {
            return await _context.Locations.Where(l => l.Code == code).FirstOrDefaultAsync();
        }
    }
}
