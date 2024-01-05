using Microsoft.EntityFrameworkCore;
using NLayer.Core.DTOs;
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
    public class PaymentRepository : GenericRepository<Payment>, IPaymentRepository
    {
        public PaymentRepository(AppDbContext context) : base(context)
        {
        }

        // Burada sadece Payment sınıfa ait bir özellik olduğu için  ekstra  bir kod ekledik
        public async Task<Payment> GetPaymentByTransactionId(string transactionId)
        {
            // Belirli bir TransactionId ile ödeme nesnesini almak için LINQ sorgusu kullanabilirsiniz.
            // Örneğin, Payments tablosundan TransactionId'ye göre filtreleme:
            return await _context.Payments.FirstOrDefaultAsync(p => p.TransactionId == transactionId);

        }

        public async Task<List<Payment>> GetPayments()
        {
            //Tüm ödemeleri ve her bir ödemenin ödeme yöntemini içeren bir liste alır.
            return await _context.Payments.Include(x => x.PaymentMethod).ToListAsync();
        }
    }
}
