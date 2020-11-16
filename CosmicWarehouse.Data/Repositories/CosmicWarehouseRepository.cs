using CosmicWarehouse.Data.Models;

namespace CosmicWarehouse.Data.Repositories
{
    public class CosmicWarehouseRepository
    {
        private readonly CosmicWarehouseContext _dbContext;

        public CosmicWarehouseRepository(CosmicWarehouseContext dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
