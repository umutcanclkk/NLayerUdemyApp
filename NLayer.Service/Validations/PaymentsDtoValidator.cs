using FluentValidation;
using NLayer.Core.DTOs;

namespace NLayer.Service.Validations
{
    public class PaymentsDtoValidator : AbstractValidator<PaymentDto>
    {
        public PaymentsDtoValidator()
        {

            RuleFor(x => x.Id).NotEmpty().WithMessage("Id is required");
            RuleFor(x => x.Id).GreaterThan(0).WithMessage("Id must be greater than 0");

            RuleFor(x => x.PaymentMethod).NotEmpty().WithMessage("PaymentMethod cannot be empty");
            RuleFor(x => x.PaymentMethod).MinimumLength(5).WithMessage("PaymentMethod min 5 characters");

            RuleFor(x => x.Amount).GreaterThan(0).WithMessage("Amount must be greater than 0");
            RuleFor(x => x.Amount).NotEmpty().WithMessage("Amount cannot be empty");


            RuleFor(x => x.TransactionId).NotEmpty().WithMessage("{PropertyTransactionId}is required");
            RuleFor(x => x.TransactionId).Matches(@"^[A-Z0-9]+$").WithMessage("TransactionId must contain only uppercase letters and numbers");
            RuleFor(x=>x.TransactionId).MaximumLength(7).WithMessage("TransactionId must not exceed 7 characters");




        }
    }
}
