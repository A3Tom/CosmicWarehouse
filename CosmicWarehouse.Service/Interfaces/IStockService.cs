using System.Collections.Generic;
using System.Threading.Tasks;
using CosmicWarehouse.Domain.Models;
using CosmicWarehouse.Domain.ViewModels;

namespace CosmicWarehouse.Service.Interfaces
{
    public interface IStockService
    {
        Task<IEnumerable<StockVM>> GetStockForItem(int itemId);
        Task<IEnumerable<StockVM>> GetStockInLocation(int locationId);
        Task<IEnumerable<StockVM>> GetStockInWarehouse(int warehouseId);
        Task AddStock(IEnumerable<StockDto> newStock);
        Task UpdateStock(StockDto newStock);
    }
}
