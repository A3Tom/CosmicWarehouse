using System.Data;
using CosmicWarehouse.Data.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace CosmicWarehouse.Data.Contexts
{
    public class CosmicWarehouseDbContext : DbContext
    {
        public DbSet<Item> Items { get; set; }
        public DbSet<ItemStock> ItemStock { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Warehouse> Warehouses { get; set; }


        public CosmicWarehouseDbContext(DbContextOptions<CosmicWarehouseDbContext> options)
            : base(options)
        {
        }
    }
}
