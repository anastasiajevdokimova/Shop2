using System;

namespace Shop2.Core.Dtos
{
    public class FileToDatabaseDto
    {
        public Guid Id { get; set; }
        public string ImageTitle { get; set; }
        public byte[] ImageData { get; set; }
        public Guid? SpaceshipId { get; set; }
    }
}
