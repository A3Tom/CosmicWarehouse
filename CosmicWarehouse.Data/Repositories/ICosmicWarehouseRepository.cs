using System.Collections.Generic;
using System.Threading.Tasks;
using CosmicWarehouse.Data.Models;

namespace CosmicWarehouse.Data.Repositories
{
    public interface ICosmicWarehouseRepository
    {
        Task<IEnumerable<Item>> GetStockForItem(int itemId);
        Task<IEnumerable<Item>> GetStockInWarehouse(int warehouseId);
        Task<IEnumerable<Item>> GetStockInLocation(int locationId);
    }
}
