using NLayer.Core.Models;

namespace NLayer.Core.Repositories
{
    public interface ICustomersRepository : IGenericRepository<Customers>
    {
        Task AddAsync(IEnumerable<Customers> entities);
    }
}
