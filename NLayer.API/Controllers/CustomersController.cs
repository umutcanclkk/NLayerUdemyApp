using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NLayer.Core.DTOs;
using NLayer.Core.IServices;
using NLayer.Core.Models;
using NLayer.Core.Services;
using NLayer.Service.Validations;

namespace NLayer.API.Controllers
{

    public class CustomersController : CustomBaseController
    {
        private readonly IMapper _mapper;
        private readonly ICustomersService _customersService;


        public CustomersController(IService<Customers> service, IMapper mapper,  ICustomersService customersService)
        {
            _mapper = mapper;
            _customersService = customersService;

        }


        [HttpGet]
        public async Task<IActionResult> All()
        {
            var customers = await _customersService.GetAllAsync();
            var customersDto = _mapper.Map<List<CustomersDto>>(customers.ToList());
            return CreateActionResult(CustomResponseDto<List<CustomersDto>>.Success(200, customersDto));
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var customers = await _customersService.GetByIdAsync(id);
            var customersDto = _mapper.Map<CustomersDto>(customers);
            return CreateActionResult(CustomResponseDto<CustomersDto>.Success(200, customersDto));

        }


        [HttpPut]
        public async Task<IActionResult> Update(CustomersUpdateDto customersDto)
        {
            // CustomersUpdateDto'yu CustomersDto'ya dönüştür
            var customersDtoForValidation = _mapper.Map<CustomersDto>(customersDto);

            // Doğrulama işlemini gerçekleştir
            var validationResult = new CustomersDtoValidator().Validate(customersDtoForValidation);

            // Doğrulama sonuçlarına göre işlem yap
            if (!validationResult.IsValid)
            {
                // Doğrulama başarısız olduğunda, hataları işle
                var errors = validationResult.Errors.Select(error => $"{error.PropertyName}: {error.ErrorMessage}").ToList();
                return BadRequest(string.Join(", ", errors));
            }

            // Doğrulama başarılı ise, güncelleme işlemini gerçekleştir
            await _customersService.UpdateAsync(_mapper.Map<Customers>(customersDto));

            // Başarılı yanıt oluştur
            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Removet(int id)
        {
            var customers = await _customersService.GetByIdAsync(id);
            await _customersService.RemoveAsync(customers);

            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));// NoContentDto yazmamızın  sebebi geri birşey dönememiz

        }


        [HttpPost]
        public async Task<IActionResult> Save(CustomersDto customersDto)
        {
            // CustomersDto'yu doğrula
            var validationResult = new CustomersDtoValidator().Validate(customersDto);

            // Doğrulama sonuçlarına göre işlem yap
            if (!validationResult.IsValid)
            {
                // Doğrulama başarısız olduğunda, hataları işle
                var errors = validationResult.Errors.Select(error => $"{error.PropertyName}: {error.ErrorMessage}").ToList();
                return BadRequest(string.Join(", ", errors));
            }

            // CustomersDto doğrulama başarılı ise, ekleme işlemini gerçekleştir
            var customer = await _customersService.AddAsync(_mapper.Map<Customers>(customersDto));

            // Eklenen müşteriyi CustomersDto'ya dönüştür
            var customerDto = _mapper.Map<CustomersDto>(customer);

            // Başarılı yanıt oluştur
            return CreateActionResult(CustomResponseDto<CustomersDto>.Success(201, customerDto));
        }
    }
}
