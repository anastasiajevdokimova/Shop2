using Shop2.Core.Domain;
using Shop2.Core.Dtos;
using System;
using System.Threading.Tasks;

namespace Shop2.Core.ServiceInterface
{
    public interface IProductService
    {
        Task<Product> Delete(Guid id);

        Task<Product> Add(ProductDto dto);

        Task<Product> Edit(Guid id);

        Task<Product> Update(ProductDto dto);
    }
}
