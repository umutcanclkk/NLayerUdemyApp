using NLayer.Core.DTOs;
using NLayer.Core.IServices;
using NLayer.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks; 

namespace NLayer.Core.Services
{
    public interface IPaymentSevice:IService<Payment>
    {

        Task<PaymentDto> GetPaymentByTransactionId(string TransactionId);

    }
}
