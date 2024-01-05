using FluentValidation;
using NLayer.Core.DTOs;

namespace NLayer.Service.Validations
{
    public class ProductDtoValidator : AbstractValidator<ProductDto>
    {
        public ProductDtoValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Id is required");
            RuleFor(x => x.Id).NotNull().WithMessage("Id is required"); 

            RuleFor(x => x.Name).NotEmpty().WithMessage("{Name} is required ");
            RuleFor(x => x.Name).NotNull().WithMessage("{Name} is required ");

            RuleFor(x => x.Price).NotEmpty().WithMessage("Price is required");
            RuleFor(x => x.Price).InclusiveBetween(1, int.MaxValue).WithMessage("{Price} must be greater than 0.");

            RuleFor(x => x.Stock).NotEmpty().WithMessage("Stock is required");
            RuleFor(x => x.Stock).InclusiveBetween(1, int.MaxValue).WithMessage("{Stock} must be greater than 0.");


            RuleFor(x => x.CategoryId).InclusiveBetween(1, int.MaxValue).WithMessage("{CategoryId} must be greater than 0.");
            RuleFor(x => x.CategoryId).NotEmpty().WithMessage("CategoryId is required");

        }
    }
}
