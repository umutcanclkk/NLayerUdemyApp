using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using NLayer.Core;
using NLayer.Core.DTOs;
using NLayer.Core.Models;
using NLayer.Core.Repositories;
using NLayer.Core.Services;
using NLayer.Core.UnitOfWorks;
using NLayer.Service.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace NLayer.Caching
{
    public class CategoryServiceWithCaching : ICategoryService
    {
        private const string CacheCategoryKey = "CategoryCache";
        private readonly IMapper _mapper;
        private readonly ICategoryRepository _categoryRepository; // Assuming there's an ICategoryRepository
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMemoryCache _memoryCache;

        public CategoryServiceWithCaching(IMapper mapper, ICategoryRepository categoryRepository, IUnitOfWork unitOfWork, IMemoryCache memoryCache)
        {
            _mapper = mapper;
            _categoryRepository = categoryRepository;
            _unitOfWork = unitOfWork;
            _memoryCache = memoryCache;
        }

        public async Task<Category> AddAsync(Category entity)
        {
            await _categoryRepository.AddAsync(entity);
            await _unitOfWork.CommitAsync();
            await CacheAllCategoriesAsync();
            return entity;
        }

        public async Task<IEnumerable<Category>> AddRangeAsync(IEnumerable<Category> entities)
        {
            await _categoryRepository.AddRangeAsync(entities);
            await _unitOfWork.CommitAsync();
            await CacheAllCategoriesAsync();
            return entities;
        }

        public async Task<bool> AnyAsync(Expression<Func<Category, bool>> expression)
        {
            return await _categoryRepository.AnyAsync(expression);
        }

        public async Task<IEnumerable<Category>> GetAllAsync()
        {
            //return Task.FromResult(_memoryCache.Get<IEnumerable<Category>>(CacheCategoryKey));
            return await _memoryCache.GetOrCreateAsync(CacheCategoryKey, async entry =>
            {
                entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(10);
                return await _categoryRepository.GetAll().ToListAsync();
            });
        }

        public async Task<Category> GetByIdAsync(int id)
        {
            var categories = await _memoryCache.GetOrCreateAsync(CacheCategoryKey, async entry =>
            {
                entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(10);
                return await _categoryRepository.GetAll().ToListAsync();
            });

            var category = categories.FirstOrDefault(x => x.Id == id);

            if (category == null)
            {
                throw new NotFoundException($"{typeof(Category).Name}({id}) not found");
            }

            return category;
        }

        public async Task RemoveAsync(Category entity)
        {
            _categoryRepository.Remove(entity);
            await _unitOfWork.CommitAsync();
            await CacheAllCategoriesAsync();
        }

        public async Task RemoveRangeAsync(IEnumerable<Category> entities)
        {
            _categoryRepository.RemoveRange(entities);
            await _unitOfWork.CommitAsync();
            await CacheAllCategoriesAsync();
        }

        public async Task UpdateAsync(Category entity)
        {
            _categoryRepository.Update(entity);
            await _unitOfWork.CommitAsync();
            await CacheAllCategoriesAsync();
        }

        public IQueryable<Category> Where(Expression<Func<Category, bool>> expression)
        {
            return _memoryCache.Get<List<Category>>(CacheCategoryKey).Where(expression.Compile()).AsQueryable();
        }

        public async Task CacheAllCategoriesAsync()
        {
            _memoryCache.Set(CacheCategoryKey, await _categoryRepository.GetAll().ToListAsync());
        }

        public async Task<CustomResponseDto<CategoryWithProductsDto>> GetSingleCategoryByIdWithProductsAsync(int categoryID)
        {
            // Implement your logic to retrieve category with products, including caching if needed.
            throw new NotImplementedException();
        }
    }
}
