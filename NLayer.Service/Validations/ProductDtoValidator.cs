using FluentValidation;
using NLayer.Core.DTOs;

namespace NLayer.Service.Validations
{
    public class ProductDtoValidator : AbstractValidator<ProductDto>
    {
        public ProductDtoValidator()
        {

            RuleFor(x => x.Name).NotEmpty().WithMessage("{PrppertyName} is required ");
            RuleFor(x => x.Name).NotNull().WithMessage("{PrppertyName} is required ");

            RuleFor(x => x.Price)
                .InclusiveBetween(1, int.MaxValue).WithMessage("{PrppertyName} must be greater than 0.");

            RuleFor(x => x.Stock)
                .InclusiveBetween(1, int.MaxValue).WithMessage("{PrppertyName} must be greater than 0.");


            RuleFor(x => x.CategoryId)
                .InclusiveBetween(1, int.MaxValue).WithMessage("{PrppertyName} must be greater than 0.");


        }
    }
}
