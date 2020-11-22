using System.Collections.Generic;
using System.Threading.Tasks;
using CosmicWarehouse.Domain.Models;
using CosmicWarehouse.Domain.ViewModels;

namespace CosmicWarehouse.Service.Interfaces
{
    public interface IStockService
    {
        Task<StockVM> GetItemStock(int itemId);
        Task<IEnumerable<StockVM>> AddStock(IEnumerable<StockDto> newStock);
        Task<StockVM> UpdateQuantity(int itemId, int quantityDiff);
    }
}
