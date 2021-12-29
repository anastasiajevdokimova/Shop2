using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Shop2.Core.Domain;
using Shop2.Core.Dtos;
using Shop2.Core.ServiceInterface;
using Shop2.Data;

namespace Shop2.ApplicationServices.Services
{
    public class CarServices : ICarService
    {
        private readonly Shop2DbContext _context;
        private readonly IWebHostEnvironment _env;
        public CarServices
            (
            Shop2DbContext context,
            IWebHostEnvironment env
            )
        {
            _context = context;
            _env = env;
        }
        public async Task<Car> Add(CarDto dto)
        {
            Car car = new Car();

            car.Id = Guid.NewGuid();
            car.Make = dto.Make;
            car.Model = dto.Model;
            car.Bodytype = dto.Bodytype;
            car.Year = dto.Year;
            car.Power = dto.Power;
            car.Mileage = dto.Mileage;
            car.Fuel = dto.Fuel;
            car.Transmission = dto.Transmission;
            car.Drivetrain = dto.Drivetrain;
            car.Price = dto.Price;
            car.ModifiedAt = DateTime.Now;
            car.CreatedAt = DateTime.Now;
            ProcessUploadedFile(dto, car);

            await _context.Car.AddAsync(car);
            await _context.SaveChangesAsync();


            return car;
        }
        public async Task<Car> Edit(Guid id)
        {
            var result = await _context.Car
                .FirstOrDefaultAsync(x => x.Id == id);

            return result;
        }
        public async Task<Car> Update(CarDto dto)
        {
            Car car = new Car();

            car.Id = Guid.NewGuid();
            car.Make = dto.Make;
            car.Model = dto.Model;
            car.Bodytype = dto.Bodytype;
            car.Year = dto.Year;
            car.Power = dto.Power;
            car.Mileage = dto.Mileage;
            car.Fuel = dto.Fuel;
            car.Transmission = dto.Transmission;
            car.Drivetrain = dto.Drivetrain;
            car.Price = dto.Price;
            car.ModifiedAt = dto.ModifiedAt;
            car.CreatedAt = dto.CreatedAt;
            ProcessUploadedFile(dto, car);


            _context.Car.Update(car);
            await _context.SaveChangesAsync();

            return car;
        }
        public async Task<Car> Delete(Guid id)
        {
            var carId = await _context.Car
                .FirstOrDefaultAsync(x => x.Id == id);


            _context.Car.Remove(carId);
            await _context.SaveChangesAsync();

            return carId;
        }
        public async Task<CarExistingFilePath> RemoveImage(CarExistingFilePathDto dto)
        {
            var imageId = await _context.CarExistingFilePaths
                .FirstOrDefaultAsync(x => x.Id == dto.PhotoId);

            _context.CarExistingFilePaths.Remove(imageId);
            await _context.SaveChangesAsync();

            return imageId;

        }
        public string ProcessUploadedFile(CarDto dto, Car car)
        {
            string uniqueFileName = null;

            if (dto.Files != null && dto.Files.Count > 0)
            {
                if (!Directory.Exists(_env.WebRootPath + "\\carFileUpload\\"))
                {
                    Directory.CreateDirectory(_env.WebRootPath + "\\carFileUpload\\");
                }
                foreach (var photo in dto.Files)
                {
                    string uploadsFolder = Path.Combine(_env.WebRootPath, "carFileUpload");
                    uniqueFileName = Guid.NewGuid().ToString() + "_" + photo.FileName; //у каждого файла уникальное имя
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);

                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        photo.CopyTo(fileStream);

                        CarExistingFilePath paths = new CarExistingFilePath
                        {
                            Id = Guid.NewGuid(),
                            FilePath = uniqueFileName,
                            CarId = car.Id
                        };

                        _context.CarExistingFilePaths.Add(paths);
                    }
                }
            }

            return uniqueFileName;
        }
    }
}
