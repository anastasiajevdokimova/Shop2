using Shop2.Core.Domain;
using System;
using System.Threading.Tasks;

namespace Shop2.Core.ServiceInterface
{
    public interface ServiceInterface
    {
        Task<Product> Delete(Guid id);
    }
}
