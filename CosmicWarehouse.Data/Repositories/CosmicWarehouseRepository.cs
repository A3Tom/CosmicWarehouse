using System.Collections.Generic;
using System.Threading.Tasks;
using CosmicWarehouse.Data.Contexts;
using CosmicWarehouse.Data.Models;

namespace CosmicWarehouse.Data.Repositories
{
    public class CosmicWarehouseRepository : ICosmicWarehouseRepository
    {
        private readonly CosmicWarehouseDbContext _dbContext;

        public CosmicWarehouseRepository(CosmicWarehouseDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<IEnumerable<Item>> GetStockForItem(int itemId)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<Item>> GetStockInLocation(int locationId)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<Item>> GetStockInWarehouse(int warehouseId)
        {
            throw new System.NotImplementedException();
        }
    }
}
