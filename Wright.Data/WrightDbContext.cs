using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Wright.Data.Entities;

namespace Wright.Data
{
    public class WrightDbContext : DbContext
    {
        public WrightDbContext(DbContextOptions<WrightDbContext> options) : base(options)
        {

        }

        public DbSet<CategoryEntity> Categories { get; set; }
        public DbSet<ListingEntity> Listings { get; set; }
        public DbSet<MowerTypeEntity> MowerTypes { get; set; }
        public DbSet<SalesInventoryEntity> SalesInventoryEntities { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}