using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
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
    public class CustomersServiceWithCaching : ICustomersService
    {
        private const string CacheCustomersKey = "CustomersCache";
        private readonly IMapper _mapper;
        private readonly IMemoryCache _memoryCache;
        private readonly ICustomersRepository _customersRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CustomersServiceWithCaching(IMapper mapper, IMemoryCache memoryCache, ICustomersRepository customersRepository, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _memoryCache = memoryCache;
            _customersRepository = customersRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Customers> AddAsync(Customers entity)
        {
            await _customersRepository.AddAsync(entity);
            await _unitOfWork.CommitAsync();
            await CacheAllCustomersAsync();
            return entity;
        }

        public async Task<IEnumerable<Customers>> AddRangeAsync(IEnumerable<Customers> entities)
        {
            await _customersRepository.AddRangeAsync(entities);
            await _unitOfWork.CommitAsync();
            await CacheAllCustomersAsync();
            return entities;
        }

        public async Task<bool> AnyAsync(Expression<Func<Customers, bool>> expression)
        {
            return await _customersRepository.AnyAsync(expression);
        }

        public Task<IEnumerable<Customers>> GetAllAsync()
        {
            return Task.FromResult(_memoryCache.Get<IEnumerable<Customers>>(CacheCustomersKey));
            //return await _memoryCache.GetOrCreateAsync(CacheCustomersKey, async entry =>
            //{
            //    entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(10); // Set cache expiration time
            //    return await _customersRepository.GetAll().ToListAsync();
            //});
        }

        public async Task<Customers> GetByIdAsync(int id)
        {
            var customers = await _memoryCache.GetOrCreateAsync(CacheCustomersKey, async entry =>
            {
                entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(10); // Set cache expiration time
                return await _customersRepository.GetAll().ToListAsync();
            });

            var customer = customers.FirstOrDefault(x => x.Id == id);

            if (customer == null)
            {
                throw new NotFoundException($"{typeof(Customers).Name}({id}) not found");
            }

            return customer;
        }

        public async Task RemoveAsync(Customers entity)
        {
            _customersRepository.Remove(entity);
            await _unitOfWork.CommitAsync();
            await CacheAllCustomersAsync();
        }

        public async Task RemoveRangeAsync(IEnumerable<Customers> entities)
        {
            _customersRepository.RemoveRange(entities);
            await _unitOfWork.CommitAsync();
            await CacheAllCustomersAsync();
        }

        public async Task UpdateAsync(CustomersUpdateDto customersDto)
        {
            var customer = await GetByIdAsync(customersDto.Id);
            _mapper.Map(customersDto, customer);
            await _unitOfWork.CommitAsync();
            await CacheAllCustomersAsync();
        }

        public async Task UpdateAsync(Customers entity)
        {
            _customersRepository.Update(entity);
            await _unitOfWork.CommitAsync();
            await CacheAllCustomersAsync();
        }

        public IQueryable<Customers> Where(Expression<Func<Customers, bool>> expression)
        {
            // .Where(expression.Compile()): LINQ sorgusu ile belirtilen koşulları karşılayan müşteri öğelerini filtreler.
            // expression.Compile(), LINQ ifadesini derleyerek bir Predicate delegate'ine dönüştürür.
            return _memoryCache.Get<List<Customers>>(CacheCustomersKey).Where(expression.Compile()).AsQueryable();
            // .AsQueryable(): Filtrelenmiş müşteri koleksiyonunu IQueryable'e dönüştürür.
        }

        public async Task CacheAllCustomersAsync()
        {
            _memoryCache.Set(CacheCustomersKey, await _customersRepository.GetAll().ToListAsync());
        }
    }
}
