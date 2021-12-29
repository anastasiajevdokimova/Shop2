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
        public DbSet<Car> Car { get; set; }
        public DbSet<ExistingFilePath> ExistingFilePaths { get; set; }
        public DbSet<CarExistingFilePath> CarExistingFilePaths { get; set; }
    }
}
