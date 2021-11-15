using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Shop2.Data;
using Shop2.Core.Domain;

namespace Shop2.Data
{
    public class Shop2DbContext : DbContext
    {
        public Shop2DbContext(DbContextOptions<Shop2DbContext> options)
            : base(options) { }

        public DbSet<Product> Product { get; set; }
    }
}
