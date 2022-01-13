using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;
using Shop2.Data;
using Shop2.Models.Car;
using Shop2.Core.ServiceInterface;
using Shop2.Core.Dtos;
using Shop2.Models.Files;
using Microsoft.EntityFrameworkCore;
using Shop2.ApplicationServices.Services;

namespace Shop2.Controllers
{
    public class CarController : Controller

    {
        private readonly Shop2DbContext _context;
        private readonly ICarService _carService;
        private readonly IFileServices _fileService;


        public CarController
            (
                Shop2DbContext context,
                ICarService carService,
                IFileServices fileService
            )
        {
            _context = context;
            _carService = carService;
            _fileService = fileService;

        }
        public IActionResult Index()
        {
            var result = _context.Car
            .Select(x => new CarListViewModel
            {
                Id = x.Id,
                Make = x.Make,
                Model = x.Model,
                Bodytype = x.Bodytype,
                Year = x.Year,
                Power = x.Power,
                Mileage = x.Mileage,
                Fuel = x.Fuel,
                Transmission = x.Transmission,
                Drivetrain = x.Drivetrain,
                Price = x.Price

            });

            return View(result);
        }

        [HttpGet]
        public IActionResult Add()
        {
            CarViewModel cmodel = new CarViewModel();

            return View("Edit", cmodel);
        }
        [HttpPost]
        public async Task<IActionResult> Add(CarViewModel cmodel)
        {
            var dto = new CarDto()
            {
                Id = cmodel.Id,
                Make = cmodel.Make,
                Model = cmodel.Model,
                Bodytype = cmodel.Bodytype,
                Year = cmodel.Year,
                Power = cmodel.Power,
                Mileage = cmodel.Mileage,
                Fuel = cmodel.Fuel,
                Transmission = cmodel.Transmission,
                Drivetrain = cmodel.Drivetrain,
                Price = cmodel.Price,
                Files = cmodel.Files,
                CarExistingFilePaths = cmodel.CarExistingFilePaths
                .Select(x => new CarExistingFilePathDto
                {
                    PhotoId = x.PhotoId,
                    FilePath = x.FilePath,
                    CarId = x.CarId
                }).ToArray()
            };

            var result = await _carService.Add(dto);
            if (result == null)
            {
                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction("Index");
        }


        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var car = await _carService.Edit(id);

            if (car == null)
            {
                return NotFound();
            }

            var photos = await _context.CarExistingFilePaths
                .Where(x => x.CarId == id)
                .Select(y => new CarExistingFilePathViewModel
                {
                    FilePath = y.FilePath,
                    PhotoId = y.Id
                })
                .ToArrayAsync();


            var cmodel = new CarViewModel();

            cmodel.Id = car.Id;
            cmodel.Make = car.Make;
            cmodel.Model = car.Model;
            cmodel.Bodytype = car.Bodytype;
            cmodel.Year = car.Year;
            cmodel.Power = car.Power;
            cmodel.Mileage = car.Mileage;
            cmodel.Fuel = car.Fuel;
            cmodel.Transmission = car.Transmission;
            cmodel.Drivetrain = car.Drivetrain;
            cmodel.Price = car.Price;
            cmodel.CarExistingFilePaths.AddRange(photos);


            return View(cmodel);
        }
        [HttpPost]
        public async Task<IActionResult> Update(CarViewModel cmodel)
        {
            var dto = new CarDto()
            {
                Id = cmodel.Id,
                Make = cmodel.Make,
                Model = cmodel.Model,
                Bodytype = cmodel.Bodytype,
                Year = cmodel.Year,
                Power = cmodel.Power,
                Mileage = cmodel.Mileage,
                Fuel = cmodel.Fuel,
                Transmission = cmodel.Transmission,
                Drivetrain = cmodel.Drivetrain,
                Price = cmodel.Price,
                Files = cmodel.Files,
                CarExistingFilePaths = cmodel.CarExistingFilePaths
                .Select(x => new CarExistingFilePathDto
                {
                    PhotoId = x.PhotoId,
                    FilePath = x.FilePath,
                    CarId = x.CarId
                }).ToArray()

            };

            var result = await _carService.Update(dto);

            if (result == null)
            {
                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction(nameof(Index), cmodel);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(Guid id)
        {

            var car = await _carService.Delete(id);


            if (car == null)
            {
                RedirectToAction(nameof(Index));
            }
            return RedirectToAction(nameof(Index), car);
        }

        [HttpPost]
        public async Task<IActionResult> RemoveImage(CarExistingFilePathViewModel cmodel)
        {
            var dto = new CarExistingFilePathDto()
            {
                FilePath = cmodel.FilePath
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
