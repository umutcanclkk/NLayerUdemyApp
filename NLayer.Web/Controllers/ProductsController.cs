﻿using Microsoft.AspNetCore.Mvc;
using NLayer.Core.Services;

namespace NLayer.Web.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        public async Task< IActionResult> Index()
        {
            var CutomRsponse = await _productService.GetProductsWitCategory();
            return View(CutomRsponse.Data);
        }
    }
}
