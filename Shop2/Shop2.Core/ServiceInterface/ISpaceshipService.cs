using Shop2.Core.Domain;
using Shop2.Core.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop2.Core.ServiceInterface
{
    public interface ISpaceshipService
    { 
        Task<Spaceship> Add(SpaceshipDto dto);
        Task<Spaceship> Edit(Guid id);
        Task<Spaceship> Update(SpaceshipDto dto);
        Task<Spaceship> Delete(Guid id);
    }
}
