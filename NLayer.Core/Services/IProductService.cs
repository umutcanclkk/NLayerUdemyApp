using NLayer.Core.DTOs;
using NLayer.Core.IServices;

namespace NLayer.Core.Services
{
    public interface IProductService : IService<Product>
    {
        Task<CustomResponseDto<List<ProductWithCategoryDto>>> GetProductsWitCategory();
    }
}
