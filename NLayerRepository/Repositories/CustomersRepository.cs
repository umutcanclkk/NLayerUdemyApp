using Microsoft.EntityFrameworkCore;
using NLayer.Core;
using NLayer.Core.Models;
using NLayer.Core.Repositories;
using NLayerRepository;
using NLayerRepository.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Repository.Repositories
{
    public class CustomersRepository : GenericRepository<Customers>, ICustomersRepository
    {
        public CustomersRepository(AppDbContext context) : base(context)
        {
        }

        public  async Task AddAsync(IEnumerable<Customers> entities)
        {
            await _context.Customers.AddRangeAsync(entities);
            await _context.SaveChangesAsync();
        }
    }
}
