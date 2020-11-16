using System.Collections.Generic;
using System.Threading.Tasks;
using CosmicWarehouse.Domain.Models;

namespace CosmicWarehouse.Service.Interfaces
{
    public interface IStockService
    {
        Task AddStock(IEnumerable<StockDto> newStock);
        Task UpdateStock(StockDto newStock);
    }
}
