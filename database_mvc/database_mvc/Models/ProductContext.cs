using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace database_mvc.Models
{
    public class ProductContext:DbContext
    {
        public ProductContext() { }
        public ProductContext(DbContextOptions<ProductContext> options)
        :base(options)
            { }

        public DbSet<Product> Products { get; set; }
        public DbSet<ProductCat>ProductCats { get; set; }

    }
}
