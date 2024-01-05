using FluentValidation;
using NLayer.Core.DTOs;

namespace NLayer.Service.Validations
{
    public class CategoryUpdateDtoValidator : AbstractValidator<CategoryUpdateDto>
    {
        public CategoryUpdateDtoValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Id is required");
            RuleFor(x => x.Id).NotNull().WithMessage("Id is required");
            RuleFor(x => x.Id).GreaterThan(0).WithMessage("Id must be greater than 0");

            RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required");
            RuleFor(x => x.Name).NotNull().WithMessage("Name is requrired");

            

        }
    }
}
