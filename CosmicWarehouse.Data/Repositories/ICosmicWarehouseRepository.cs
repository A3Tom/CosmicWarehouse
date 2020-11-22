using System.Collections.Generic;
using System.Threading.Tasks;
using CosmicWarehouse.Data.Models;

namespace CosmicWarehouse.Data.Repositories
{
    public interface ICosmicWarehouseRepository
    {
        Task<Item> GetStockForItem(int itemId);
        Task<IEnumerable<Item>> GetStockInWarehouse(int warehouseId);
        Task<IEnumerable<Item>> GetStockInLocation(int locationId);
        Task<IEnumerable<Item>> AddStock(IEnumerable<Item> itemStock);
        Task<Item> UpdateQuantity(int stockId, int quantity);
    }
}
