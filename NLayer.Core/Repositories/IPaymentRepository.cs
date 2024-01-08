using NLayer.Core.Models;

namespace NLayer.Core.Repositories
{
    public interface IPaymentRepository:IGenericRepository<Payment>
    {
        Task<Payment> GetPaymentByTransactionId(string transactionId);
        Task<List<Payment>> GetPayments();

    }
}
