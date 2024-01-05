using NLayer.Core.DTOs;
using NLayer.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Core.Repositories
{
    public interface IPaymentRepository:IGenericRepository<Payment>
    {
        Task<Payment> GetPaymentByTransactionId(string transactionId);
        Task<List<Payment>> GetPayments();

    }
}
