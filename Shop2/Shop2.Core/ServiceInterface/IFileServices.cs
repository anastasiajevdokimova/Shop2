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
        string ProcessUploadedFile(ProductDto dto, Product product);

        Task<ExistingFilePath> RemoveImage(ExistingFilePathDto dto);
        Task<ExistingFilePath> RemoveImages(ExistingFilePathDto[] dto);
    }
}
