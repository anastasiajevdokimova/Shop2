using System;

namespace Shop2.Models.Product
{
    public class ProductListViewModel
    {
        public  Guid? Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public int Ammount { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }

    }
}
