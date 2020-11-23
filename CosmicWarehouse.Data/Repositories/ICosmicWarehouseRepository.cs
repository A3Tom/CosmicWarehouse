using System.Collections.Generic;
using System.Threading.Tasks;
using CosmicWarehouse.Data.Models;

namespace CosmicWarehouse.Data.Repositories
{
    public interface ICosmicWarehouseRepository
    {
        #region Items

        Task<Item> GetStockForItem(int itemId);
        Task<IEnumerable<Item>> GetStockInWarehouse(int warehouseId);
        Task<IEnumerable<Item>> GetStockInLocation(int locationId);
        Task<IEnumerable<Item>> AddStock(IEnumerable<Item> itemStock);
        Task<Item> UpdateQuantity(int stockId, int quantity);

        #endregion


        #region Locations

        Task<Location> GetLocation(int locationId);
        Task<IEnumerable<Location>> GetLocationsForWarehouse(int? warehouseId);
        Task<Location> AddLocation(Location newEntity);
        Task<Location> UpdateLocation(Location entity);

        #endregion


        #region Warehouses

        Task<Warehouse> GetWarehouseById(int warehouseId);
        Task<IEnumerable<Warehouse>> GetAllWarehouses();
        Task<Warehouse> AddWarehouse(Warehouse newEntity);
        Task<Warehouse> UpdateWarehouse(Warehouse entity);

        #endregion
    }
}
