using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Shop2.Core.Domain;
using Shop2.Core.ServiceInterface;
using Shop2.Data;

namespace Shop2.ApplicationServices.Services
{
    public class ProductServices : IProductService
    {
        private readonly Shop2DbContext _context;
        public ProductServices
            (
            Shop2DbContext context
            )
        {
            _context = context;
        }
        public async Task<Product> Delete(Guid id)
        {
            var productId = await _context.Product
                .FirstOrDefaultAsync(x => x.Id == id);

            _context.Product.Remove(productId);
            await _context.SaveChangesAsync();

            return productId;
        }
    }
}
