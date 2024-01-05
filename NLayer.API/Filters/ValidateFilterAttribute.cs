using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using NLayer.Core.DTOs;

namespace NLayer.API.Filters
{

    public class ValidateFilterAttribute : ActionFilterAttribute
    {

        public override void OnActionExecuting(ActionExecutingContext context)
        {  // burada errors mesajlarını sadece ilk hatayı dönderiyoruz  bunu da CutomReponseDto yapıyoruz

            if (!context.ModelState.IsValid)
            {
                var errors = context.ModelState.Values
                    .SelectMany(x => x.Errors)
                    .Select(x => x.ErrorMessage)
                    .FirstOrDefault(); // Take the first error message

                // Assuming CustomResponseDto<T> has a constructor that takes status code and a single error message
                var responseDto = CustomResponseDto<NoContentDto>.FailBadRequest( errors);

                context.Result = new BadRequestObjectResult(responseDto);
            }

            
            // burada bir eror mesajını ilk hatsını değil  birden çok errors mesajı varsa list şeklinde yazdığımızda tüm hataları dönderiyoruz bunu da CutomReponseDto yapıyoruz

            //if (!context.ModelState.IsValid)
            //{

            //    var errors = context.ModelState.Values.SelectMany(x => x.Errors)
            //    .Select(x => x.ErrorMessage).ToList();

            //    context.Result = new BadRequestObjectResult(CustomResponseDto<NoContentDto>.Fail(400, errors)
            //        );

            //}
        }


    }
}
