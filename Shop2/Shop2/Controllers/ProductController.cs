﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;
using Shop2.Data;
using Shop2.Models.Product;
using Shop2.Core.ServiceInterface;
using Shop2.Core.Dtos;
using Shop2.Models.Files;
using Microsoft.EntityFrameworkCore;

namespace Shop2.Controllers
{
    public class ProductController : Controller
    {
        private readonly Shop2DbContext _context;
        private readonly IProductService _productService;
        private readonly IFileServices _fileService;

        public ProductController
            (
                Shop2DbContext context,
                IProductService productService,
                IFileServices fileService
            )
        {
            _context = context;
            _productService = productService;
            _fileService = fileService;
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
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Add()
        {
            ProductViewModel model = new ProductViewModel();

            return View("Edit", model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(ProductViewModel model)
        {
            var dto = new ProductDto()
            {
                Id = model.Id,
                Description = model.Description,
                Name = model.Name,
                Ammount = model.Ammount,
                Price = model.Price,
                ModifiedAt = model.ModifiedAt,
                CreatedAt = model.CreatedAt,
                Files = model.Files,
                ExistingFilePaths = model.ExistingFilePaths
                .Select(x => new ExistingFilePathDto
                {
                    PhotoId = x.PhotoId,
                    FilePath = x.FilePath,
                    ProductId = x.ProductId
                }).ToArray()
            };

            var result = await _productService.Add(dto);
            if (result == null)
            {
                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var product = await _productService.Edit(id);

            if (product == null)
            {
                return NotFound();
            }

            var photos = await _context.ExistingFilePaths
                .Where(x => x.ProductId == id)
                .Select(y => new ExistingFilePathViewModel
                {
                    FilePath = y.FilePath,
                    PhotoId = y.Id
                })
                .ToArrayAsync();

            var model = new ProductViewModel();

            model.Id = product.Id;
            model.Description = product.Description;
            model.Name = product.Name;
            model.Ammount = product.Ammount;
            model.Price = product.Price;
            model.ModifiedAt = product.ModifiedAt;
            model.CreatedAt = product.CreatedAt;
            model.ExistingFilePaths.AddRange(photos);


            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Update(ProductViewModel model)
        {
            var dto = new ProductDto()
            {
                Id = model.Id,
                Description = model.Description,
                Name = model.Name,
                Ammount = model.Ammount,
                Price = model.Price,
                ModifiedAt = model.ModifiedAt,
                CreatedAt = model.CreatedAt,
                Files = model.Files,
                ExistingFilePaths = model.ExistingFilePaths
                .Select(x => new ExistingFilePathDto
                {
                PhotoId = x.PhotoId,
                FilePath = x.FilePath,
                ProductId = x.ProductId
                }).ToArray()

            };

            var result = await _productService.Update(dto);

            if (result == null)
            {
                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction(nameof(Index), model);
        }

        [HttpPost]
        public async Task<IActionResult> RemoveImage(ExistingFilePathViewModel model)
        {
            var dto = new ExistingFilePathDto()
            {
               FilePath = model.FilePath
            };

            var image = await _fileService.RemoveImage(dto);
            if (image == null)
            {
                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
