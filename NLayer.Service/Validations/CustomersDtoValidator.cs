using FluentValidation;
using NLayer.Core.DTOs;
using System.Text.RegularExpressions;

namespace NLayer.Service.Validations
{
    public class CustomersDtoValidator : AbstractValidator<CustomersDto>
    {
        private bool BeAValidEmail(string email)
        {
            // E-posta adresi kontrolü burada yapılır
            // Örneğin: Regex veya başka bir yöntemle kontrol edilebilir.
            const string emailPattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
            return !string.IsNullOrEmpty(email) && Regex.IsMatch(email, emailPattern);
        }


        private bool BeValidName(string name)
        {
            // Özel bir doğrulama mantığı
            // Bu örnekte, sadece harfler içermesi gerektiği
            return name.All(char.IsLetter);
        }
        private bool BeValidNumeric(string phoneNumber)// mutlaka Sor
        {
            //Telefon numarasının takip etmesini istediğiniz belirli bir formatı burada tanımlayabilirsiniz
            // Bu örnekte, sadece sayısal karakterlerden oluşması ve en az 10, en fazla 15 karakter uzunluğunda olması gerekiyor
            string phoneNumberPattern = @"^\d{10,15}$";

            // Regex.Match metodu, verilen desene uygun bir eşleşme bulup bulmadığını kontrol eder
            Match match = Regex.Match(phoneNumber, phoneNumberPattern);

            // Eğer desene uygun bir eşleşme bulunduysa, telefon numarası geçerli kabul edilir
            return match.Success;
            //return phoneNumber.All(char.IsDigit);
        }

        public CustomersDtoValidator()
        {

            RuleFor(x => x.Name).NotEmpty().WithMessage("{PrppertyName} is required ");
            RuleFor(x => x.Name).NotNull().WithMessage("{PrppertyName} is required");
            RuleFor(x => x.Name).MinimumLength(2).WithMessage("{PrppertyName} Minimum 2 characters entered ");
            RuleFor(x => x.Name).Must(BeValidName).WithMessage("{PropertyName} must contain only letters.");

            RuleFor(x => x.SurName).NotEmpty().WithMessage("{PrppertySurName} is required");
            RuleFor(x => x.SurName).NotNull().WithMessage("{PrppertySurName} is required");
            RuleFor(x => x.SurName).MinimumLength(2).WithMessage("{PrppertySurName} Minimum 5 characters entered ");
            RuleFor(x => x.SurName).Must(BeValidName).WithMessage("{PrppertySurName} must contain only letters.");

            RuleFor(x => x.E_Mail).NotEmpty().WithMessage("{PrppertyE_Mail} is required");
            RuleFor(x => x.E_Mail).NotNull().WithMessage("{PrppertyE_Mail} is required");
            RuleFor(x => x.E_Mail).Must(BeAValidEmail).WithMessage("Invalid email address");

            RuleFor(x => x.PhoneNumber).NotEmpty().WithMessage("{PrppertyPhoneNumber} is required");
            RuleFor(x => x.PhoneNumber).NotNull().WithMessage("{PrppertyPhoneNumber} is required");


            RuleFor(x => x.PhoneNumber).Must(BeValidNumeric).WithMessage("{PrppertyPhoneNumber} is not a valid phone number.");




        }
    }
}
