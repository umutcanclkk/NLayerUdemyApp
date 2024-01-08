using NLayer.Core.DTOs;
using NLayer.Core.IServices;
using NLayer.Core.Models;

namespace NLayer.Core.Services
{
    public interface IPaymentSevice:IService<Payment>
    {

        Task<PaymentDto> GetPaymentByTransactionId(string TransactionId);

    }
}
