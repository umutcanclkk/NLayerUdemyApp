using AutoMapper;
using NLayer.Core.DTOs;
using NLayer.Core.Models;
using NLayer.Core.Repositories;
using NLayer.Core.Services;
using NLayer.Core.UnitOfWorks;
using NLayer.Service.Exceptions;

namespace NLayer.Service.Services
{
    public class PaymentService : Service<Payment>, IPaymentSevice
    {
        private readonly IPaymentRepository _paymentRepository;
        private readonly IMapper _mapper;
   

        public PaymentService(IGenericRepository<Payment> repository, IUnitOfWork unitOfWork, IMapper mapper, IPaymentRepository paymentRepository) : base(repository, unitOfWork)
        {
            _paymentRepository = paymentRepository;
            _mapper = mapper;
        }

        // Burada payment classına özellik olduğu için payment service kodu yazıp implemented yaptık
        public async Task<PaymentDto> GetPaymentByTransactionId(string transactionId)
        {



            var payment = await _paymentRepository.GetPaymentByTransactionId(transactionId);

            if (payment == null)
            {
                throw new NotFoundException($"{typeof(Payment).Name} ({transactionId})  not found");
            }

            var paymentDto = _mapper.Map<PaymentDto>(payment);

            return paymentDto;



        }
    }
}
