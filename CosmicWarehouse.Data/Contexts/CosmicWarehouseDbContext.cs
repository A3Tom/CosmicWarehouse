using CosmicWarehouse.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace CosmicWarehouse.Data.Contexts
{
    public class CosmicWarehouseDbContext : DbContext
    {
        public DbSet<Item> Items { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Warehouse> Warehouses { get; set; }
        public DbSet<StockTransaction> StockTransactions { get; set; }


        public CosmicWarehouseDbContext(DbContextOptions<CosmicWarehouseDbContext> options)
            : base(options)
        {
        }
    }
}
