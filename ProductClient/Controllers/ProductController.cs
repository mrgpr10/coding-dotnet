using Microsoft.AspNetCore.Mvc;
using ProductClient.Models;
using ProductClient.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProductClient.Controllers
{
    public class ProductController : Controller
    {
        private readonly ProductService _productService;
        public ProductController(ProductService productService)
        {
            _productService = productService;
        }
        public async Task<IActionResult> Index()
        {
            var products = await
           _productService.GetProductsAsync();
            return View(products);
        }
    }

}

