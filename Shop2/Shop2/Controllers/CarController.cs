using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Shop2.Data;
using Shop2.Models.Car;

namespace Shop2.Controllers
{
    public class CarController : Controller

    {
        private readonly Shop2DbContext _context;
        
        public CarController
            (
                Shop2DbContext context
            )
    {
        _context = context;
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
}

}
