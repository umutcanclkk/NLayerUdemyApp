using NLayer.Core.DTOs;
using NLayer.Core.IServices;
using NLayer.Core.Models;

namespace NLayer.Core.Services
{
    public interface ICustomersService : IService<Customers>
    {
        Task UpdateAsync(CustomersUpdateDto customersDto);
    }
}
