﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shop2.Core.Dtos;
using Shop2.Core.ServiceInterface;
using Shop2.Data;
using Shop2.Models.Spaceship;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop2.Controllers
{
    public class SpaceshipController : Controller
    {
        private readonly ISpaceshipService _spaceshipService;
        private readonly Shop2DbContext _context;

        public SpaceshipController
            (
            ISpaceshipService spaceshipService,
            Shop2DbContext context
            )
        {
            _spaceshipService = spaceshipService;
            _context = context;
        }

        public IActionResult Index()
        {
            var result = _context.Spaceship
             .Select(x => new SpaceshipListViewModel
             {
                 Id = x.Id,
                 Name = x.Name,
                 Type = x.Type,
                 Mass = x.Mass,
                 Prize = x.Prize,
                 Crew = x.Crew,
                 ConstructedAt = x.ConstructedAt,
                 CreatedAt = x.CreatedAt,
                 ModifiedAt = x.ModifiedAt
                    
             });

            return View(result);
        }

        [HttpGet]
        public IActionResult Add()
        {
            SpaceshipViewModel model = new SpaceshipViewModel();

            return View("Edit", model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(SpaceshipViewModel model)
        {
            var dto = new SpaceshipDto()
            {
                Id = model.Id,
                Name = model.Name,
                Type = model.Type,
                Mass = model.Mass,
                Prize = model.Prize,
                Crew = model.Crew,
                ConstructedAt = model.ConstructedAt,
                CreatedAt = model.CreatedAt,
                ModifiedAt = model.ModifiedAt,
                Files = model.Files,
                Image = model.Image.Select(x => new FileToDatabaseDto
                {
                    Id = x.Id,
                    ImageData = x.ImageData,
                    ImageTitle = x.ImageTitle,
                    SpaceshipId= x.SpaceshipId
                }).ToArray()
            };

            var result = await _spaceshipService.Add(dto);
            if (result == null)
            {
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var spaceship = await _spaceshipService.Edit(id);

            if (spaceship == null)
            {
                return NotFound();
            }

            var photos = await _context.FileToDatabase
                .Where(x => x.SpaceshipId == id)
                .Select(m => new ImagesViewModel
                {
                    ImageData = m.ImageData,
                    Id = m.Id,
                    Image = string.Format("data:image/gif;base64,{0}", Convert.ToBase64String(m.ImageData)),
                    ImageTitle = m.ImageTitle,
                    SpaceshipId = m.Id
                }).ToArrayAsync();

            var model = new SpaceshipViewModel();

            model.Id = spaceship.Id;
            model.Name = spaceship.Name;
            model.Type = spaceship.Type;
            model.Mass = spaceship.Mass;
            model.Prize = spaceship.Prize;
            model.Crew = spaceship.Crew;
            model.ConstructedAt = spaceship.ConstructedAt;
            model.CreatedAt = spaceship.CreatedAt;
            model.ModifiedAt = spaceship.ModifiedAt;
            model.Image.AddRange(photos);

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Update(SpaceshipViewModel model)
        {
            var dto = new SpaceshipDto()
            {
                Id = model.Id,
                Name = model.Name,
                Type = model.Type,
                Mass = model.Mass,
                Prize = model.Prize,
                Crew = model.Crew,
                ConstructedAt = model.ConstructedAt,
                CreatedAt = model.CreatedAt,
                ModifiedAt = model.ModifiedAt,
                Image = model.Image.Select(x => new FileToDatabaseDto
                {
                    Id = x.Id,
                    ImageData = x.ImageData,
                    ImageTitle = x.ImageTitle,
                    SpaceshipId = x.SpaceshipId
                })

            };

            var result = await _spaceshipService.Update(dto);

            if (result == null)
            {
                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction(nameof(Index), model);

        }

        [HttpPost]
        public async Task<IActionResult> Delete(Guid id)
        {

            var spaceship = await _spaceshipService.Delete(id);


            if (spaceship == null)
            {
                RedirectToAction(nameof(Index));
            }
            return RedirectToAction(nameof(Index), spaceship);
        }
    }
}
