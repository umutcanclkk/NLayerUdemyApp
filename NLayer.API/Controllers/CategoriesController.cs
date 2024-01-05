using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NLayer.Core;
using NLayer.Core.DTOs;
using NLayer.Core.Services;
using NLayer.Service.Validations;

namespace NLayer.API.Controllers
{


    public class CategoriesController : CustomBaseController
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;

        public CategoriesController(ICategoryService categoryService, IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }


        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var categories = await _categoryService.GetAllAsync();
            var categoryDtos = _mapper.Map<List<CategoryDto>>(categories.ToList());
            return CreateActionResult(CustomResponseDto<List<CategoryDto>>.Success(200, categoryDtos));

        }


        //api/categories/GetSingleCategoryByIdWithProducts/2   (idsi)
        [HttpGet("[action]/{categoryId}")]
        public async Task<IActionResult> GetSingleCategoryByIdWithProducts(int categoryId)
        {
            var result = await _categoryService.GetSingleCategoryByIdWithProductsAsync(categoryId);
            return CreateActionResult(result);
        }



    



        [HttpPost]
        public async Task<IActionResult> Save(CategoryDto categoryDto)
        {
            var category = await _categoryService.AddAsync(_mapper.Map<Category>(categoryDto));
            var validationResult = new CategoryDtoValidator().Validate(categoryDto);
            if (!validationResult.IsValid)
            {
                var errors = validationResult.Errors.Select(errors => $"{errors.PropertyName}: {errors.ErrorMessage}").ToList();
                return BadRequest(string.Join(", ", errors));
            }
            var categorydto = _mapper.Map<CategoryDto>(category);
            return CreateActionResult(CustomResponseDto<CategoryDto>.Success(201, categorydto));

        }


        [HttpPut]
       public async Task<IActionResult>Update (CategoryUpdateDto categoryUpdateDto)
        {
            var validationResult = new CategoryUpdateDtoValidator().Validate(categoryUpdateDto);
            if (!validationResult.IsValid)
            {
                var errors = validationResult.Errors.Select(error => $"{error.PropertyName}: {error.ErrorMessage}").ToList();
                return BadRequest(string.Join(", ", errors));
            }
            await _categoryService.UpdateAsync(_mapper.Map<Category>(categoryUpdateDto));
            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }



        [HttpDelete("{id}")]
        public async Task<IActionResult> Removet(int id)
        {
            var category = await _categoryService.GetByIdAsync(id);
            await _categoryService.RemoveAsync(category);

            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));// NoContentDto yazmamızın  sebebi geri birşey dönememiz

        }




    }

}
