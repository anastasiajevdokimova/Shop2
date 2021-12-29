using System;
using System.IO;
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
        public CarServices
            (
            Shop2DbContext context
            )
        {
            _context = context;
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
    }
}
