using System.Collections.Generic;
using System.Threading.Tasks;
using CosmicWarehouse.Data.Models;

namespace CosmicWarehouse.Data.Repositories
{
    public interface ICosmicWarehouseRepository
    {
        Task<IEnumerable<ItemStock>> GetStockForItem(int itemId);
        Task<IEnumerable<ItemStock>> GetStockInWarehouse(int warehouseId);
        Task<IEnumerable<ItemStock>> GetStockInLocation(int locationId);
    }
}
