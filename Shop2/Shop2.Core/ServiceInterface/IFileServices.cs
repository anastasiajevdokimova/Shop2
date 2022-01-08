using Shop2.Core.Domain;
using Shop2.Core.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop2.Core.ServiceInterface
{
    public interface IFileServices : IApplicationService
    {
        string ProcessUploadedFile(CarDto dto, Car car);

        Task<CarExistingFilePath> RemoveImage(CarExistingFilePathDto dto);
        Task<CarExistingFilePath> RemoveImages(CarExistingFilePathDto[] dto);
    }
}
