using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Shop2.Core.Domain;
using Shop2.Core.Dtos;
using Shop2.Core.ServiceInterface;
using Shop2.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop2.ApplicationServices.Services
{
    public class FileServices : IFileServices
    {
        private readonly Shop2DbContext _context;
        private readonly IWebHostEnvironment _env;
        public FileServices
            (
            Shop2DbContext context,
            IWebHostEnvironment env
            )
        {
            _context = context;
            _env = env;
        }
        public async Task<CarExistingFilePath> RemoveImage(CarExistingFilePathDto dto)
        {
            var imageId = await _context.CarExistingFilePaths
                .FirstOrDefaultAsync(x => x.FilePath == dto.FilePath);

            string photoPath = _env.WebRootPath + "\\carFileUpload\\" + dto.FilePath;
         
            File.Delete(photoPath);

            _context.CarExistingFilePaths.Remove(imageId);
            await _context.SaveChangesAsync();

            return imageId;

        }

        public async Task<CarExistingFilePath> RemoveImages(CarExistingFilePathDto[] dto)
        {
            foreach (var dtos in dto)
            {
                var fileId = await _context.CarExistingFilePaths
                .FirstOrDefaultAsync(x => x.FilePath == dtos.FilePath);

                string photoPath = _env.WebRootPath + "\\carFileUpload\\" + dtos.FilePath;
                
                File.Delete(photoPath);

                _context.CarExistingFilePaths.Remove(fileId);
                await _context.SaveChangesAsync();

            }
            return null;
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
