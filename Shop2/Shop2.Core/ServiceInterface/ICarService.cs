using Shop2.Core.Domain;
using Shop2.Core.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop2.Core.ServiceInterface
{
    public interface ICarService : IApplicationService
    {
        Task<Car> Add(CarDto dto);
        Task<Car> Edit(Guid id);
        Task<Car> Update(CarDto dto);
        Task<Car> Delete(Guid id);
    }
}
