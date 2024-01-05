using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NLayer.API.Filters;
using NLayer.Core;
using NLayer.Core.DTOs;
using NLayer.Core.Services;
using NLayer.Service.Validations;

namespace NLayer.API.Controllers
{

    public class ProductsController : CustomBaseController
    {
        private readonly IMapper _mapper;
        private readonly IProductService _service;

        public ProductsController(IMapper mapper, IProductService productSevice)
        {
            _mapper = mapper;
            _service = productSevice;
        }

        //burada  GetProductsWithCategory içine yazmazımızın sebebi httpget lerin çakışmaması!
        ////GET/api/products/GetProductsWithCategory
        //[HttpGet("[action]")]
        //public async Task<IActionResult> GetProductsWithCategory()
        //{
        //    return CreateActionResult(await _service.GetProductsWitCategory());

        //}

        //GET api/products
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var products = await _service.GetAllAsync();
            var productsDtos = _mapper.Map<List<ProductDto>>(products.ToList());
            return CreateActionResult(CustomResponseDto<List<ProductDto>>.Success(200, productsDtos));

        }


        [ServiceFilter(typeof(NotFoundFilter<Product>))]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var product = await _service.GetByIdAsync(id);
            var productsDto = _mapper.Map<ProductDto>(product);
            return CreateActionResult(CustomResponseDto<ProductDto>.Success(200, productsDto));

        }
        [HttpPost]
        public async Task<IActionResult> Save(ProductUpdateDto productUpdateDto)
        {
            // ProductDto'yu doğrula
            var validationResult = new ProductUpdateDtoValidator().Validate(productUpdateDto);

            // Doğrulama sonuçlarına göre işlem yap
            if (!validationResult.IsValid)
            {
                // Doğrulama başarısız olduğunda, hataları işle
                var errors = validationResult.Errors.Select(error => $"{error.PropertyName}: {error.ErrorMessage}").ToList();
                return BadRequest(string.Join(", ", errors));
            }

            // ProductDto doğrulama başarılı ise, ürün ekleme işlemini gerçekleştir
            var product = await _service.AddAsync(_mapper.Map<Product>(productUpdateDto));

            // Eklenen ürünü ProductDto'ya dönüştür
            var productUpdateDtoResult = _mapper.Map<ProductUpdateDto>(product);

            // Başarılı yanıt oluştur
            return Ok(CustomResponseDto<ProductUpdateDto>.Success(201, productUpdateDtoResult));
        }



        [HttpPut]
        public async Task<IActionResult> Update(ProductDto productDto)
        {   var validationResult =new ProductDtoValidator().Validate(productDto);

            if (!validationResult.IsValid)
            {
                var errors= validationResult.Errors.Select(errors=>$"{errors.PropertyName}: {errors.ErrorMessage}").ToList();
                return BadRequest(string.Join(",", errors));
                
            }

            await _service.UpdateAsync(_mapper.Map<Product>(productDto));

            return CreateActionResult(CustomResponseDto<ProductDto>.Success(204));

        }



        [HttpDelete("{id}")]
        public async Task<IActionResult> Removeet(int id)
        {
            var product = await _service.GetByIdAsync(id);
            await _service.RemoveAsync(product);

            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));// NoContentDto yazmamızın  sebebi geri birşey dönememiz

        }
    }
}
