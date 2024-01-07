using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NLayer.Core.DTOs;
using NLayer.Core.Models;
using NLayer.Core.Services;
using NLayer.Service.Validations;

namespace NLayer.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : CustomBaseController
    {
        private readonly IMapper _mapper;
        private readonly IPaymentSevice _paymentService;

        public PaymentController(IMapper mapper, IPaymentSevice paymentSevice)
        {
            _mapper = mapper;
            _paymentService = paymentSevice;
        }


        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var payments = await _paymentService.GetAllAsync();
            var paymentDto = _mapper.Map<List<PaymentDto>>(payments.ToList());
            return CreateActionResult(CustomResponseDto<List<PaymentDto>>.Success(200, paymentDto));

        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var payment = await _paymentService.GetByIdAsync(id);
            var paymentDto = _mapper.Map<PaymentDto>(payment);
            return CreateActionResult(CustomResponseDto<PaymentDto>.Success(200, paymentDto));

        }





        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            var payments = await _paymentService.GetByIdAsync(id);
            await _paymentService.RemoveAsync(payments);
            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));// NoContentDto yazmamızın  sebebi geri birşey dönememiz

        }


        [HttpPost]
        public async Task<IActionResult> Save(PaymentUpdateDto paymentDto)
        {
            // PaymentUpdateDto'yu doğrula
            var validationResult = new PaymentUpdateDtoValidator().Validate(paymentDto);

            // Doğrulama sonuçlarına göre işlem yap
            if (!validationResult.IsValid)
            {
                // Doğrulama başarısız olduğunda, hataları işle
                var errors = validationResult.Errors.Select(error => $"{error.PropertyName}: {error.ErrorMessage}").ToList();
                return BadRequest(string.Join(", ", errors));
            }

            // PaymentUpdateDto doğrulama başarılı ise, ödeme ekleme işlemini gerçekleştir
            var payment = await _paymentService.AddAsync(_mapper.Map<Payment>(paymentDto));

            // Eklenen ödemeyi PaymentUpdateDto'ya dönüştür
            var paymentsDto = _mapper.Map<PaymentUpdateDto>(payment);

            // Başarılı yanıt oluştur
            return CreateActionResult(CustomResponseDto<PaymentUpdateDto>.Success(201, paymentsDto));
        }


        [HttpGet("ByTransactionId/{transactionId}")]

        public async Task<IActionResult> GetPaymentByTransactionId(string transactionId)
        {
            // PaymentUpdateDto'yu doğrula
            var validationResult = new TransactionIdValidator().Validate(transactionId);

            // Doğrulama sonuçlarına göre işlem yap
            if (!validationResult.IsValid)
            {
                // Doğrulama başarısız olduğunda, hataları işle
                var errors = validationResult.Errors.Select(error => $"{error.PropertyName}: {error.ErrorMessage}").ToList();
                return BadRequest(string.Join(", ", errors));
            }

            var payments = await _paymentService.GetPaymentByTransactionId(transactionId);
            var paymentDto = _mapper.Map<PaymentDto>(payments);
            return CreateActionResult(CustomResponseDto<PaymentDto>.Success(200, paymentDto));
        }




        [HttpPut]
        public async Task<IActionResult> Update(PaymentDto paymentDto)
        {
            // PaymentDto'yu doğrula
            var validationResult = new PaymentsDtoValidator().Validate(paymentDto);

            // Doğrulama sonuçlarına göre işlem yap
            if (!validationResult.IsValid)
            {
                // Doğrulama başarısız olduğunda, hataları işle
                var errors = validationResult.Errors.Select(error => $"{error.PropertyName}: {error.ErrorMessage}").ToList();
                return BadRequest(string.Join(", ", errors));
            }

            // PaymentDto doğrulama başarılı ise, ödeme güncelleme işlemini gerçekleştir
            await _paymentService.UpdateAsync(_mapper.Map<Payment>(paymentDto));

            // Başarılı yanıt oluştur
            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }


    }
}

