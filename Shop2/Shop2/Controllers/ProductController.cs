using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Shop2.Data;
using Shop2.Models.Product;

namespace Shop2.Controllers
{
    public class ProductController : Controller
    {
        private readonly Shop2DbContext _context;

        public ProductController
            (
                Shop2DbContext context
            )
        {
            _context = context;
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
    }
}
