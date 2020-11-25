using System.Collections.Generic;
using System.Threading.Tasks;
using CosmicWarehouse.Domain.Models;
using CosmicWarehouse.Domain.ViewModels;

namespace CosmicWarehouse.Service.Interfaces
{
    public interface IWarehouseService
    {
        Task<WarehouseVM> GetWarehouse(int warehouseId);
        Task<IEnumerable<WarehouseVM>> GetAllWarehouses(bool includeInactive);
        Task<WarehouseVM> AddWarehouse(WarehouseDto newWarehouse);
        Task<WarehouseVM> RenameWarehouse(WarehouseDto warehouse);
        Task<WarehouseVM> ToggleActive(int warehouseId, bool active);
    }
}
