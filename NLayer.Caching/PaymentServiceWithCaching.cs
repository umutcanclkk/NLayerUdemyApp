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
using NLayer.Service.Services;
using NLayerRepository.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Caching
{
    public class PaymentServiceWithCaching : PaymentService
    {
        private const string CachePaymentsKey = "PaymentsCache";
        private readonly IMapper _mapper;
        private readonly IPaymentRepository _paymentsrepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMemoryCache _memorycache;

        public PaymentServiceWithCaching(IMapper mapper, IPaymentRepository paymentsrepository, IUnitOfWork unitOfWork, IMemoryCache memorycache)
            : base(paymentsrepository, unitOfWork, mapper,paymentsrepository )
        {          
            _mapper = mapper;
            _paymentsrepository = paymentsrepository;
            _unitOfWork = unitOfWork;
            _memorycache = memorycache;

            // Ödeme önbelleğini kontrol et
            if (!_memorycache.TryGetValue(CachePaymentsKey, out List<Payment> payments))
            {
                // Ödeme önbelleği boşsa, tüm ödemeleri getir ve önbelleğe ekle
                payments = _paymentsrepository.GetAll().ToList();
                _memorycache.Set(CachePaymentsKey, payments);
            }
        }


        public async Task<Payment> AddAsync(Payment entity)
        {
            await _paymentsrepository.AddAsync(entity);
            await _unitOfWork.CommitAsync();
            await CacheAllPaymentsCache();
            return entity;
        }

        public async Task<IEnumerable<Payment>> AddRangeAsync(IEnumerable<Payment> entities)
        {
            await _paymentsrepository.AddRangeAsync(entities);
            await _unitOfWork.CommitAsync();
            await CacheAllPaymentsCache();
            return entities;
        }

        public Task<bool> AnyAsync(Expression<Func<Payment, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Payment>> GetAllAsync()
        {
            return Task.FromResult(_memorycache.Get<IEnumerable<Payment>>(CachePaymentsKey));
        }

        public async Task<Payment> GetByIdAsync(int id)
        {
            if (!_memorycache.TryGetValue(CachePaymentsKey, out List<Payment> payments))
            {
                // Önbellekte ödemeler bulunamadı, isteği gerçekleştiremiyoruz
                throw new NotFoundException($"{typeof(Payment).Name} list not found in cache");
            }

            // İlgili Id'ye sahip ödemenin aranması
            var payment = payments.FirstOrDefault(x => x.Id == id);

            if (payment == null)
            {
                // İlgili Id'ye sahip ödeme bulunamadı
                throw new NotFoundException($"{typeof(Payment).Name}({id}) not found");
            }

            // İlgili ödeme bulundu, geri döndür
            return await Task.FromResult(payment);
        }

        public async Task<PaymentDto> GetPaymentByTransactionId(string TransactionId)
        {

            if (!_memorycache.TryGetValue(CachePaymentsKey, out List<PaymentDto> payments))
            {
                // Önbellekte ödemeler bulunamadı, isteği gerçekleştiremiyoruz
                throw new NotFoundException($"{typeof(PaymentDto).Name} list not found in cache");
            }

            // İlgili TransactionId'ye sahip ödemenin aranması
            var payment = payments.FirstOrDefault(x => x.TransactionId == TransactionId);

            if (payment == null)
            {
                // İlgili TransactionId'ye sahip ödeme bulunamadı
                throw new NotFoundException($"{typeof(PaymentDto).Name} ({TransactionId}) not found");
            }

            //// İlgili ödeme bulundu, DTO'ya dönüştür ve geri döndür
            var paymentDto = _mapper.Map<PaymentDto>(payment);
            return await Task.FromResult(paymentDto);
        }

        public async Task RemoveAsync(Payment entity)
        {
            _paymentsrepository.Remove(entity);
            await _unitOfWork.CommitAsync();
            await CacheAllPaymentsCache();
        }

        public async Task RemoveRangeAsync(IEnumerable<Payment> entities)
        {
            _paymentsrepository.RemoveRange(entities);
            await _unitOfWork.CommitAsync();
            await CacheAllPaymentsCache();
        }

        public async Task UpdateAsync(Payment entity)
        {
            _paymentsrepository.Update(entity);
            await _unitOfWork.CommitAsync();
            await CacheAllPaymentsCache();
        }

        public IQueryable<Payment> Where(Expression<Func<Payment, bool>> expression)
        {
            return _paymentsrepository.GetPayments().Result.Where(expression.Compile()).AsQueryable();
            //return _paymentsrepository.Get<List<Payment>>(CachePaymentsKey).Where(expression.Compile()).AsQueryable();
        }



        public async Task CacheAllPaymentsCache()
        {
            _memorycache.Set(CachePaymentsKey, await _paymentsrepository.GetAll().ToListAsync());
        }



    }
}
