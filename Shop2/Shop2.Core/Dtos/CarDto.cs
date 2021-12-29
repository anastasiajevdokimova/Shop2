using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop2.Core.Dtos
{
    public class CarDto
    {
        public Guid? Id { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public string Bodytype { get; set; }
        public int Year { get; set; }
        public double Power { get; set; }
        public double Mileage { get; set; }
        public string Fuel { get; set; }
        public string Transmission { get; set; }
        public string Drivetrain { get; set; }
        public double Price { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }
        public List<IFormFile> Files { get; set; }
        public IEnumerable<CarExistingFilePathDto> CarExistingFilePaths { get; set; } = new List<CarExistingFilePathDto>();
    }
}
