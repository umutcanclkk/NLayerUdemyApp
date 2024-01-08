using Microsoft.AspNetCore.Mvc;
using NLayer.Core.DTOs;

namespace NLayer.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class CustomBaseController : ControllerBase
    {

        [NonAction]   // Bu metot, özel cevapları alıp uygun bir IActionResult nesnesine çevirir.

        public IActionResult CreateActionResult<T> (CustomResponseDto<T>response)
        {
            // Eğer cevap durumu 204 ise, NoContent (204) HTTP durum kodunu döndürür.
            if (response.StatusCode == 204)
                return new ObjectResult(null)
                {
                    StatusCode = response.StatusCode
                };

            return new ObjectResult(response)
            {
                // Diğer durumlarda, cevabı içeren bir ObjectResult nesnesi döndürülür.
                StatusCode = response.StatusCode
            };
        }

        

    }
}
