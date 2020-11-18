using CosmicWarehouse.Data.Contexts;

namespace CosmicWarehouse.Data.Repositories
{
    public class CosmicWarehouseRepository
    {
        private readonly CosmicWarehouseDbContext _dbContext;

        public CosmicWarehouseRepository(CosmicWarehouseDbContext dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
