using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportStore.Models
{
    public class StoreDbContext : DbContext 
    {
        public StoreDbContext(DbContextOptions<StoreDbContext> options)
            : base(options)
        {

        }

        public DbSet<Product> Products { get; set; }
    }
}
