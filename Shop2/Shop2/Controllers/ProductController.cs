using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Shop2.Data;
using Shop2.Models.Product;
using Shop2.Core.ServiceInterface;

namespace Shop2.Controllers
{
    public class ProductController : Controller
    {
        private readonly Shop2DbContext _context;
        private readonly IProductService _productService;

        public ProductController
            (
                Shop2DbContext context,
                IProductService productService

            )
        {
            _context = context;
            _productService = productService;
        }
        public IActionResult Index()
        {
            var result = _context.Product
            .Select(x => new ProductListViewModel
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                Price = x.Price,
                Ammount = x.Ammount
            });

            return View(result);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(Guid id)
        {
            var product = await _productService.Delete(id);
            if (product == null)
            {
                RedirectToAction(nameof(Index));
            }
            return RedirectToAction(nameof(Index), product);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View("Edit");
        }
    }
}
