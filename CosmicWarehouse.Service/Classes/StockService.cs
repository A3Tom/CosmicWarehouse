using System.Collections.Generic;
using System.Threading.Tasks;
using CosmicWarehouse.Domain.Models;
using CosmicWarehouse.Service.Interfaces;

namespace CosmicWarehouse.Service.Classes
{
    public class StockService : IStockService
    {
        public Task AddStock(IEnumerable<StockDto> newStock)
        {
            throw new System.NotImplementedException();
        }

        public Task UpdateStock(StockDto newStock)
        {
            throw new System.NotImplementedException();
        }
    }
}
