using System;
using Xunit;
using Shop2.Models.Spaceship;
using Shop2.Core.ServiceInterface;
using Shop2.Core.Dtos;

//namespace Spaceship.Test
//{
//    public class SpaceshipCreate
//    {
//        private readonly ISpaceshipService _spaceship;

//        public SpaceshipCreate
//            (
//                ISpaceshipService spaceship
//            )
//        {
//            spaceship = _spaceship;
//        }

//        [Fact]
//        public void When_CreateNewSpaceship_ThenWillAddNewData()
//        {
    
//            var spaceship = new SpaceshipDto
//            {
//                Name = "Superman",
//                Type = "Corvette",
//                Mass = 123,
//                Prize = 123,
//                ConstructedAt = DateTime.Now,
//                CreatedAt = DateTime.Now,
//                ModifiedAt = DateTime.Now,
//                Crew = 123
//            };

//            var result = _spaceship.Add(spaceship);

//            Assert.True(result);
//        }
//    }
//}
