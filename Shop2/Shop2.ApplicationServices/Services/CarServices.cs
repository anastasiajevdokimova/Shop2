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
        private readonly IFileServices _file;
        public CarServices
            (
            Shop2DbContext context,
            IFileServices file
            )
        {
            _context = context;
            _file = file;
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
            _file.ProcessUploadedFile(dto, car);

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

            car.Id = dto.Id;
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
            _file.ProcessUploadedFile(dto, car);


            _context.Car.Update(car);
            await _context.SaveChangesAsync();

            return car;
        }
        public async Task<Car> Delete(Guid id)
        {
            var photos = await _context.CarExistingFilePaths
                .Where(x => x.CarId == id)
                .Select(y => new CarExistingFilePathDto
                {
                    CarId = y.CarId,
                    FilePath = y.FilePath,
                    PhotoId = y.Id
                })
                .ToArrayAsync();

            var carId = await _context.Car
                .Include(x => x.CarExistingFilePaths)
                .FirstOrDefaultAsync(x => x.Id == id);

            await _file.RemoveImages(photos);
            _context.Car.Remove(carId);
            await _context.SaveChangesAsync();

            return carId;
        }
       
    }
}
