using FluentValidation;

public class TransactionIdValidator : AbstractValidator<string>
{
    public TransactionIdValidator()
    {

        RuleFor(x => x).NotEmpty().WithMessage("{PropertyTransactionId}is required");
        RuleFor(x => x).Matches(@"^[A-Z0-9]+$").WithMessage("TransactionId must contain only uppercase letters and numbers");
        RuleFor(x => x).MaximumLength(7).WithMessage("TransactionId must not exceed 7 characters");

    }
}
