using Microsoft.EntityFrameworkCore;
using Shop2.Core.Domain;
using Shop2.Core.Dtos;
using Shop2.Core.ServiceInterface;
using Shop2.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop2.ApplicationServices.Services
{
    public class SpaceshipServices : ISpaceshipService
    {
        private readonly Shop2DbContext _context;
        public SpaceshipServices
            (
            Shop2DbContext context
            )
        {
            _context = context;
        }
        public async Task<Spaceship> Add(SpaceshipDto dto)
        {
            Spaceship spaceship = new Spaceship();

            spaceship.Id = Guid.NewGuid();
            spaceship.Name = dto.Name;
            spaceship.Type = dto.Type;
            spaceship.Mass = dto.Mass;
            spaceship.Prize = dto.Prize;
            spaceship.Crew = dto.Crew;
            spaceship.ConstructedAt = dto.ConstructedAt;
            spaceship.CreatedAt = DateTime.Now;
            spaceship.ModifiedAt = DateTime.Now;

            await _context.Spaceship.AddAsync(spaceship);
            await _context.SaveChangesAsync();

            return spaceship;
        }
        public async Task<Spaceship> Edit(Guid id)
        {
            var result = await _context.Spaceship
                .FirstOrDefaultAsync(x => x.Id == id);

            return result;
        }
        public async Task<Spaceship> Update(SpaceshipDto dto)
        {
            Spaceship spaceship = new Spaceship();

            spaceship.Id = dto.Id;
            spaceship.Name = dto.Name;
            spaceship.Type = dto.Type;
            spaceship.Mass = dto.Mass;
            spaceship.Prize = dto.Prize;
            spaceship.Crew = dto.Crew;
            spaceship.ConstructedAt = dto.ConstructedAt;
            spaceship.CreatedAt = dto.CreatedAt;
            spaceship.ModifiedAt = dto.ModifiedAt; ;

            _context.Spaceship.Update(spaceship);
            await _context.SaveChangesAsync();

            return spaceship;
        }
        public async Task<Spaceship> Delete(Guid id)
        {
         
            var spaceshipId = await _context.Spaceship
                .FirstOrDefaultAsync(x => x.Id == id);

            _context.Spaceship.Remove(spaceshipId);
            await _context.SaveChangesAsync();

            return spaceshipId;
        }
    }
}
