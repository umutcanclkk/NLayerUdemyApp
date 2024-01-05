using Microsoft.AspNetCore.Mvc;
using NLayer.Core.Services;

namespace NLayer.Web.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        public async Task< IActionResult> Index()
        {
            var CustomeResponse = await _productService.GetProductsWitCategory();

            return View(CustomeResponse.Data);
        }
    }
}
