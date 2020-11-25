using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CosmicWarehouse.Data.Models;
using CosmicWarehouse.Data.Repositories;
using CosmicWarehouse.Domain.Models;
using CosmicWarehouse.Domain.ViewModels;
using CosmicWarehouse.Service.Interfaces;
using Microsoft.Extensions.Logging;

namespace CosmicWarehouse.Service.Classes
{
    public class StockService : IStockService
    {
        private readonly ILogger<StockService> _logger;

        private readonly ICosmicWarehouseRepository _cosmicWarehouseRepo;

        public StockService(ILogger<StockService> logger,
            ICosmicWarehouseRepository cosmicWarehouseRepository)
        {
            _logger = logger;
            _cosmicWarehouseRepo = cosmicWarehouseRepository;
        }

        public async Task<StockVM> GetItemStock(int itemId)
        {
            try
            {
                var result = await _cosmicWarehouseRepo.GetStockForItem(itemId);

                return GetItemStockAsViewModel(result);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed getting details of item id {itemId}", ex);
                throw;
            }
        }

        public  async Task<IEnumerable<StockVM>> GetAllStock(int? warehouseId, int? locationId)
        {
            var result = await _cosmicWarehouseRepo.GetStock(warehouseId, locationId);

            return GetItemStockListAsViewModel(result);
        }

        public async Task<IEnumerable<StockVM>> AddStock(IEnumerable<StockDto> newStock)
        {
            var stockToAdd = new List<Item>();

            try
            {
                foreach (var stockDto in newStock)
                {
                    var newItem = new Item()
                    {
                        LocationId = stockDto.LocationId,
                        Weight = stockDto.Weight,
                        Quantity = stockDto.Quantity,
                        Name = stockDto.Name,
                        Description = stockDto.Description
                    };

                    stockToAdd.Add(newItem);
                }

                var newItemStock = await _cosmicWarehouseRepo.AddStock(stockToAdd);

                _logger.LogInformation($"Added {stockToAdd.Count} new stock.");

                return GetItemStockListAsViewModel(newItemStock);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed adding new stock", ex);
                throw;
            }
        }

        public async Task<StockVM> UpdateQuantity(int itemId, int quantityDiff)
        {
            try
            {
                var updatedItemStock = await _cosmicWarehouseRepo.UpdateQuantity(itemId, quantityDiff);

                _logger.LogInformation($"Updated item Id {itemId} by {quantityDiff}");

                return GetItemStockAsViewModel(updatedItemStock);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed updating item Id {itemId} by {quantityDiff}", ex);
                throw;
            }
        }

        private static IEnumerable<StockVM> GetItemStockListAsViewModel(IEnumerable<Item> itemStock)
        {
            return itemStock.Select(x => GetItemStockAsViewModel(x));
        }

        private static StockVM GetItemStockAsViewModel(Item itemStock)
        {
            return itemStock;
        }
    }
}
