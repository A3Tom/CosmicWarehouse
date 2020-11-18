using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CosmicWarehouse.Data.Models;
using CosmicWarehouse.Data.Repositories;
using CosmicWarehouse.Domain.Models;
using CosmicWarehouse.Domain.ViewModels;
using CosmicWarehouse.Service.Interfaces;

namespace CosmicWarehouse.Service.Classes
{
    public class StockService : IStockService
    {
        private readonly ICosmicWarehouseRepository _cosmicWarehouseRepo;

        public StockService(ICosmicWarehouseRepository cosmicWarehouseRepository)
        {
            _cosmicWarehouseRepo = cosmicWarehouseRepository;
        }

        public async Task<IEnumerable<StockVM>> GetStockForItem(int itemId)
        {
            var stock = await _cosmicWarehouseRepo.GetStockForItem(itemId);

            return GetStockAsViewModel(stock);
        }

        public async Task<IEnumerable<StockVM>> GetStockInLocation(int locationId)
        {
            var stock = await _cosmicWarehouseRepo.GetStockInLocation(locationId);

            return GetStockAsViewModel(stock);
        }

        public async Task<IEnumerable<StockVM>> GetStockInWarehouse(int warehouseId)
        {
            var stock = await _cosmicWarehouseRepo.GetStockInWarehouse(warehouseId);

            return GetStockAsViewModel(stock);
        }


        public Task AddStock(IEnumerable<StockDto> newStock)
        {
            throw new System.NotImplementedException();
        }

        public Task UpdateStock(StockDto newStock)
        {
            throw new System.NotImplementedException();
        }

        private static IEnumerable<StockVM> GetStockAsViewModel(IEnumerable<ItemStock> itemStock)
        {
            return itemStock.Select(x => (StockVM)itemStock);
        }
    }
}
